using p5rpc.lib.interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using System.Runtime.InteropServices;
using static p5rpc.lib.Components.FlowStruct;
using static p5rpc.lib.interfaces.FlowFunctions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace p5rpc.lib.Components
{
    internal unsafe class FlowCaller : IFlowCaller
    {
        private FlowContext** _flowContext;
        private FlowFunctionGroup* _flowFunctions;
        private FlowContext _sharedFlowContext = new();

        private IHook<MainLoopDelegate> _mainLoopHook;
        private Queue<FlowCallInfo> _callQueue = new();

        private Thread? _mainThread;

        internal FlowCaller(IStartupScanner startupScanner, IReloadedHooks hooks)
        {
            startupScanner.AddMainModuleScan("4C 8B 05 ?? ?? ?? ?? 41 8B 50 ?? 29 CA", result =>
            {
                if (!result.Found)
                {
                    Utils.LogError("Unable to find flow info, won't be able to use arguments or get outputs :(");
                    return;
                }
                _flowContext = (FlowContext**)Utils.GetGlobalAddress((nuint)result.Offset + (nuint)Utils.BaseAddress + 3);
                Utils.LogDebug($"Flow info is at 0x{(nuint)_flowContext:X}");
            });

            startupScanner.AddMainModuleScan("4C 8D 3D ?? ?? ?? ?? 8B F5", result =>
            {
                if (!result.Found)
                {
                    Utils.LogError("Unable to find call flow function, won't be able to call flow functions :(");
                    return;
                }
                Utils.LogDebug($"Found call flow function at 0x{result.Offset + Utils.BaseAddress:X}");
                _flowFunctions = (FlowFunctionGroup*)Utils.GetGlobalAddress((nuint)result.Offset + (nuint)Utils.BaseAddress + 3);
            });
            startupScanner.AddMainModuleScan("E8 ?? ?? ?? ?? FF 05 ?? ?? ?? ?? 83 0D ?? ?? ?? ?? 10", result =>
            {
                if (!result.Found)
                {
                    Utils.LogError("Unable to main loop ptr, won't be able to call flow functions :(");
                    return;
                }
                Utils.LogDebug($"Found main loop ptr at 0x{result.Offset + Utils.BaseAddress:X}");
                var address = Utils.GetGlobalAddress((UIntPtr)(result.Offset + Utils.BaseAddress + 1));
                Utils.LogDebug($"Found main loop at 0x{address:X}");
                _mainLoopHook = hooks.CreateHook<MainLoopDelegate>(MainLoop, (long)address).Activate();
            });
        }

        private void MainLoop()
        {
            if (_mainThread == null)
                _mainThread = Thread.CurrentThread;
            if (_callQueue.Count > 0)
            {
                var callInfo = _callQueue.Peek();
                FlowContext* previousContext = *_flowContext;
                *_flowContext = callInfo.Context;
                bool ret = false;
                ret = ((delegate* unmanaged[Stdcall]<nuint, bool>)callInfo.FunctionInfo.Function)(0);
                if (!ret)
                {
                    callInfo.Context->WaitingFlag = 0x7FFFFFFF;
                }
                else
                {
                    callInfo.CallFinished = true;
                    _callQueue.Dequeue();
                }
                *_flowContext = previousContext;
            }
            _mainLoopHook.OriginalFunction();
        }

        [Function(CallingConventions.Microsoft)]
        private delegate void MainLoopDelegate();

        public bool Ready()
        {
            return _flowFunctions != null;
        }

        public float CallFloatFlowFunction(FlowFunction function, bool emitSharedContext, bool useSharedContext, params object[] arguments)
        {
            return CallFloatFlowFunction((FlowFunctionGroupType)((int)function >> 0xc & 0xf), (int)function & 0xfff, emitSharedContext, useSharedContext, arguments);
        }
        public float CallFloatFlowFunction(FlowFunction function, params object[] arguments) => CallFloatFlowFunction(function, false, false, arguments);

        public int CallFlowFunction(FlowFunction function, bool emitSharedContext, bool useSharedContext, params object[] arguments)
        {
            return CallFlowFunction((FlowFunctionGroupType)((int)function >> 0xc & 0xf), (int)function & 0xfff, emitSharedContext, useSharedContext, arguments);
        }
        public int CallFlowFunction(FlowFunction function, params object[] arguments) => CallFlowFunction(function, false, false, arguments);

        public int CallFlowFunction(FlowFunctionGroupType group, int functionId, bool emitSharedContext, bool useSharedContext, params object[] arguments)
        {
            FlowContext context = InternalCallFlowFunction(group, functionId, useSharedContext, emitSharedContext, arguments);
            return context.IntReturnValue;
        }
        public int CallFlowFunction(FlowFunctionGroupType group, int functionId, params object[] arguments) => CallFlowFunction(group, functionId, false, false, arguments);

        public float CallFloatFlowFunction(FlowFunctionGroupType group, int functionId, bool emitSharedContext, bool useSharedContext, params object[] arguments)
        {
            FlowContext context = InternalCallFlowFunction(group, functionId, useSharedContext, emitSharedContext, arguments);
            return context.FloatReturnValue;
        }
        public float CallFloatFlowFunction(FlowFunctionGroupType group, int functionId, params object[] arguments) => CallFloatFlowFunction(group, functionId, false, false, arguments);

        private FlowContext InternalCallFlowFunction(FlowFunctionGroupType group, int functionId, bool useSharedContext, bool emitSharedContext, params object[] arguments)
        {
            if (!Ready())
            {
                Utils.LogError($"Flow caller is not ready yet. The mod that called it should check Ready() before calling it.");
                return new FlowContext();
            }
            if (functionId > _flowFunctions[(int)group].NumFunctions)
            {
                Utils.LogError($"Function id {functionId} is out of range for group {group}");
                return new FlowContext();
            }
            FlowFunctionInfo function = _flowFunctions[(int)group].Functions[functionId];
            string name = Marshal.PtrToStringAnsi((nint)function.Name);
            if (function.NumArguments != arguments.Length)
            {
                Utils.LogError($"{name} expects {function.NumArguments} arguments, but {arguments.Length} were provided");
                return new FlowContext();
            }

            FlowContext context = useSharedContext ? _sharedFlowContext : new FlowContext();
            SetArgs(ref context, arguments);

            if (_mainThread == null || Thread.CurrentThread != _mainThread)
            {
                // Calls not from the main thread are queued so they are run on it to avoid collisions with other flow functions
                Utils.LogDebug($"Queuing call for flow function {name} with id {functionId} at 0x{function.Function:X} with {function.NumArguments} arguments");

                FlowCallInfo callInfo = new FlowCallInfo(function, &context);
                _callQueue.Enqueue(callInfo);

                while (!callInfo.CallFinished)
                    Thread.Sleep(1);
            }
            else
            {
                // Calls from the main thread must be run immediately, if they were queued it would softlock the game
                Utils.LogDebug($"Calling flow function {name} with id {functionId} at 0x{function.Function:X} with {function.NumArguments} arguments");
                
                FlowContext* previousContext = *_flowContext;
                *_flowContext = &context;
                ((delegate* unmanaged[Stdcall]<nuint, bool>)function.Function)(0);
                *_flowContext = previousContext;
            }

            if (emitSharedContext) _sharedFlowContext = context;
            return context;
        }

        private void SetArgs(ref FlowContext context, params object[] arguments)
        {
            context.NumArgs = (short)arguments.Length;
            for (int i = 0; i < arguments.Length; i++)
                SetArg(ref context, i, arguments[i]);
        }

        private void SetArg(ref FlowContext context, int argNum, object value)
        {
            if (value is int)
            {
                context.Arguments[context.NumArgs - argNum] = (int)value;
                context.ArgTypes[context.NumArgs - argNum - 1] = (byte)ArgType.Integer;
            }
            else if (value is float)
            {
                context.Arguments[context.NumArgs - argNum] = BitConverter.SingleToInt32Bits((float)value);
                context.ArgTypes[context.NumArgs - argNum - 1] = (byte)ArgType.Float;
            }
        }

        // Flow functions!
        public int AI_RND(int param1) { return CallFlowFunction(FlowFunction.AI_RND, false, false, param1); }
        public void AI_ACT_ATTACK() { CallFlowFunction(FlowFunction.AI_ACT_ATTACK, false, false); }
        public int AI_TAR_RND() { return CallFlowFunction(FlowFunction.AI_TAR_RND, false, false); }
        public void AI_ACT_SKILL(int param1) { CallFlowFunction(FlowFunction.AI_ACT_SKILL, false, false, param1); }
        public void AI_DEBUG_PRINT(string param1) { CallFlowFunction(FlowFunction.AI_DEBUG_PRINT, false, false, param1); }
        public void AI_DEBUG_PRINT_VALUE(int param1, float param2) { CallFlowFunction(FlowFunction.AI_DEBUG_PRINT_VALUE, false, false, param1, param2); }
        public int AI_CHK_FRID_VOID() { return CallFlowFunction(FlowFunction.AI_CHK_FRID_VOID, false, false); }
        public int AI_CHK_MYHP(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYHP, false, false, param1); }
        public int AI_CHK_MYMP(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYMP, false, false, param1); }
        public int AI_CHK_FRHP(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRHP, false, false, param1); }
        public int AI_CHK_ENHP(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENHP, false, false, param1); }
        public int AI_CHK_ENHP_O(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENHP_O, false, false, param1); }
        public int AI_CHK_MYLV_O(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYLV_O, false, false, param1); }
        public int AI_CHK_FRLV_O(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRLV_O, false, false, param1); }
        public int AI_CHK_EN_LV_O(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_EN_LV_O, false, false, param1); }
        public int AI_CHK_FRCNT(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRCNT, false, false, param1); }
        public int AI_CHK_ENCNT(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENCNT, false, false, param1); }
        public int AI_CHK_MYBAD(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYBAD, false, false, param1); }
        public int AI_CHK_FRBAD(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRBAD, false, false, param1); }
        public int AI_CHK_ENBAD(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENBAD, false, false, param1); }
        public int AI_CHK_FRID(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRID, false, false, param1); }
        public int AI_CHK_ENID(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENID, false, false, param1); }
        public int AI_CHK_FRHOJO(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRHOJO, false, false, param1); }
        public int AI_CHK_ENHOJO(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENHOJO, false, false, param1); }
        public int AI_CHK_ESCAPE() { return CallFlowFunction(FlowFunction.AI_CHK_ESCAPE, false, false); }
        public int AI_CHK_SUMMON() { return CallFlowFunction(FlowFunction.AI_CHK_SUMMON, false, false); }
        public int AI_CHK_SENSEI() { return CallFlowFunction(FlowFunction.AI_CHK_SENSEI, false, false); }
        public int AI_CHK_MYHANSYA(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYHANSYA, false, false, param1); }
        public int AI_CHK_FRHANSYA(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRHANSYA, false, false, param1); }
        public int AI_CHK_ENHANSYA(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENHANSYA, false, false, param1); }
        public int AI_CHK_MYKYUSYU(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYKYUSYU, false, false, param1); }
        public int AI_CHK_FRKYUSYU(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRKYUSYU, false, false, param1); }
        public int AI_CHK_ENKYUSYU(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENKYUSYU, false, false, param1); }
        public int AI_CHK_MYMUKOU(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYMUKOU, false, false, param1); }
        public int AI_CHK_FRMUKOU(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRMUKOU, false, false, param1); }
        public int AI_CHK_ENMUKOU(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENMUKOU, false, false, param1); }
        public int AI_CHK_MYWEAK(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYWEAK, false, false, param1); }
        public int AI_CHK_FRWEAK(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRWEAK, false, false, param1); }
        public int AI_CHK_ENWEAK(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENWEAK, false, false, param1); }
        public int AI_CHK_MYUSEATTR(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYUSEATTR, false, false, param1); }
        public int AI_CHK_FRUSEATTR(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRUSEATTR, false, false, param1); }
        public int AI_CHK_ENUSEATTR(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENUSEATTR, false, false, param1); }
        public int AI_CHK_MYUSESKIL(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYUSESKIL, false, false, param1); }
        public int AI_CHK_FRUSESKIL(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRUSESKIL, false, false, param1); }
        public int AI_CHK_ENUSESKIL(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENUSESKIL, false, false, param1); }
        public int AI_CHK_MYGROUP() { return CallFlowFunction(FlowFunction.AI_CHK_MYGROUP, false, false); }
        public int AI_CHK_FRGROUP() { return CallFlowFunction(FlowFunction.AI_CHK_FRGROUP, false, false); }
        public int AI_CHK_ENGROUP() { return CallFlowFunction(FlowFunction.AI_CHK_ENGROUP, false, false); }
        public int AI_CHK_TURN(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_TURN, false, false, param1); }
        public int AI_CHK_TURN_O(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_TURN_O, false, false, param1); }
        public int AI_CHK_MYHREC() { return CallFlowFunction(FlowFunction.AI_CHK_MYHREC, false, false); }
        public int AI_CHK_MORE() { return CallFlowFunction(FlowFunction.AI_CHK_MORE, false, false); }
        public int AI_CHK_FRHANSYA_ST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRHANSYA_ST, false, false, param1); }
        public int AI_CHK_ENHANSYA_ST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENHANSYA_ST, false, false, param1); }
        public int AI_CHK_FRKYUSYU_ST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRKYUSYU_ST, false, false, param1); }
        public int AI_CHK_ENKYUSYU_ST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENKYUSYU_ST, false, false, param1); }
        public int AI_CHK_FRMUKOU_ST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRMUKOU_ST, false, false, param1); }
        public int AI_CHK_ENMUKOU_ST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENMUKOU_ST, false, false, param1); }
        public int AI_CHK_FRWEAK_ST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRWEAK_ST, false, false, param1); }
        public int AI_CHK_ENWEAK_ST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENWEAK_ST, false, false, param1); }
        public int AI_CHK_FRIDHP(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDHP, false, false, param1, param2); }
        public int AI_CHK_FRIDMP(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDMP, false, false, param1, param2); }
        public int AI_CHK_FRIDLV_O(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDLV_O, false, false, param1, param2); }
        public int AI_CHK_FRIDBAD(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDBAD, false, false, param1, param2); }
        public int AI_CHK_FRIDBAD_ALL(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDBAD_ALL, false, false, param1, param2); }
        public int AI_CHK_FRIDHOJO(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDHOJO, false, false, param1, param2); }
        public int AI_CHK_FRIDHANSYA(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDHANSYA, false, false, param1, param2); }
        public int AI_CHK_FRIDKYUSYU(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDKYUSYU, false, false, param1, param2); }
        public int AI_CHK_FRIDMUKOU(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDMUKOU, false, false, param1, param2); }
        public int AI_CHK_FRIDWEAK(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDWEAK, false, false, param1, param2); }
        public int AI_CHK_FRIDUSEATTR(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDUSEATTR, false, false, param1, param2); }
        public int AI_CHK_FRIDUSESKIL(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDUSESKIL, false, false, param1, param2); }
        public int AI_CHK_FRIDUSEGROUP(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDUSEGROUP, false, false, param1); }
        public int AI_CHK_FRIDHREC(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDHREC, false, false, param1); }
        public int AI_CHK_ENIDHP(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDHP, false, false, param1, param2); }
        public int AI_CHK_ENIDMP(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDMP, false, false, param1, param2); }
        public int AI_CHK_ENIDLV_O(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDLV_O, false, false, param1, param2); }
        public int AI_CHK_ENIDBAD(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDBAD, false, false, param1, param2); }
        public int AI_CHK_ENIDBAD_ALL(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDBAD_ALL, false, false, param1, param2); }
        public int AI_CHK_ENIDHOJO(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDHOJO, false, false, param1, param2); }
        public int AI_CHK_ENIDHANSYA(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDHANSYA, false, false, param1, param2); }
        public int AI_CHK_ENIDKYUSYU(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDKYUSYU, false, false, param1, param2); }
        public int AI_CHK_ENIDMUKOU(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDMUKOU, false, false, param1, param2); }
        public int AI_CHK_ENIDWEAK(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDWEAK, false, false, param1, param2); }
        public int AI_CHK_ENIDUSEATTR(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDUSEATTR, false, false, param1, param2); }
        public int AI_CHK_ENIDUSESKIL(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDUSESKIL, false, false, param1, param2); }
        public int AI_CHK_ENIDUSEGROUP(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDUSEGROUP, false, false, param1); }
        public int AI_CHK_ENIDHREC(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDHREC, false, false, param1); }
        public int AI_CHK_ID(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ID, false, false, param1); }
        public int AI_CHK_FRALLHP(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRALLHP, false, false, param1); }
        public int AI_CHK_ENALLHP(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENALLHP, false, false, param1); }
        public int AI_CHK_MYABLESKIL(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYABLESKIL, false, false, param1); }
        public int AI_CHK_MYATTRSKIL(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYATTRSKIL, false, false, param1); }
        public int AI_CHK_ELEMENT_HITSUB(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ELEMENT_HITSUB, false, false, param1); }
        public int AI_CHK_ELEMENT_HIT(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ELEMENT_HIT, false, false, param1); }
        public int AI_CHK_ELEMENT_RESIST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ELEMENT_RESIST, false, false, param1); }
        public int AI_CHK_ELEMENT_NULLIFY(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ELEMENT_NULLIFY, false, false, param1); }
        public int AI_CHK_ANALYZE(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ANALYZE, false, false, param1); }
        public int AI_CHK_DOWN(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_DOWN, false, false, param1); }
        public int AI_CHK_SLIP(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_SLIP, false, false, param1); }
        public int AI_CHK_ENOVERLV(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENOVERLV, false, false, param1); }
        public int AI_CHK_WALL(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_WALL, false, false, param1); }
        public int AI_CHK_NONE(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_NONE, false, false, param1); }
        public int AI_TAR_AI() { return CallFlowFunction(FlowFunction.AI_TAR_AI, false, false); }
        public int AI_TAR_HPMIN() { return CallFlowFunction(FlowFunction.AI_TAR_HPMIN, false, false); }
        public int AI_TAR_LVMIN() { return CallFlowFunction(FlowFunction.AI_TAR_LVMIN, false, false); }
        public int AI_TAR_MPMAX() { return CallFlowFunction(FlowFunction.AI_TAR_MPMAX, false, false); }
        public int AI_TAR_BAD(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_BAD, false, false, param1); }
        public int AI_TAR_NOTBAD(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTBAD, false, false, param1); }
        public int AI_TAR_ID(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_ID, false, false, param1); }
        public int AI_TAR_MINE() { return CallFlowFunction(FlowFunction.AI_TAR_MINE, false, false); }
        public int AI_TAR_MYAI() { return CallFlowFunction(FlowFunction.AI_TAR_MYAI, false, false); }
        public int AI_TAR_HANSYA(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_HANSYA, false, false, param1); }
        public int AI_TAR_KYUSYU(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_KYUSYU, false, false, param1); }
        public int AI_TAR_MUKOU(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_MUKOU, false, false, param1); }
        public int AI_TAR_WEAK(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_WEAK, false, false, param1); }
        public int AI_TAR_NOTHANSYA(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTHANSYA, false, false, param1); }
        public int AI_TAR_NOTKYUSYU(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTKYUSYU, false, false, param1); }
        public int AI_TAR_NOTMUKOU(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTMUKOU, false, false, param1); }
        public int AI_TAR_NOTWEAK(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTWEAK, false, false, param1); }
        public int AI_TAR_APPOINT() { return CallFlowFunction(FlowFunction.AI_TAR_APPOINT, false, false); }
        public int AI_TAR_DOWN() { return CallFlowFunction(FlowFunction.AI_TAR_DOWN, false, false); }
        public int AI_TAR_STAND() { return CallFlowFunction(FlowFunction.AI_TAR_STAND, false, false); }
        public int AI_TAR_HANSYA_ST(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_HANSYA_ST, false, false, param1); }
        public int AI_TAR_KYUSYU_ST(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_KYUSYU_ST, false, false, param1); }
        public int AI_TAR_MUKOU_ST(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_MUKOU_ST, false, false, param1); }
        public int AI_TAR_WEAK_ST(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_WEAK_ST, false, false, param1); }
        public int AI_TAR_NOTHANSYA_ST(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTHANSYA_ST, false, false, param1); }
        public int AI_TAR_NOTKYUSYU_ST(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTKYUSYU_ST, false, false, param1); }
        public int AI_TAR_NOTMUKOU_ST(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTMUKOU_ST, false, false, param1); }
        public int AI_TAR_NOTWEAK_ST(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTWEAK_ST, false, false, param1); }
        public int AI_TAR_HERO(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_HERO, false, false, param1); }
        public int AI_TAR_NOTID(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTID, false, false, param1); }
        public int AI_TAR_HOJO(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_HOJO, false, false, param1); }
        public int AI_TAR_NOTHOJO(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTHOJO, false, false, param1); }
        public int AI_SET_AFFINITY(int param1) { return CallFlowFunction(FlowFunction.AI_SET_AFFINITY, false, false, param1); }
        public int AI_SET_DOWN(int param1) { return CallFlowFunction(FlowFunction.AI_SET_DOWN, false, false, param1); }
        public int AI_SET_SLIP(int param1) { return CallFlowFunction(FlowFunction.AI_SET_SLIP, false, false, param1); }
        public int AI_SET_DROPITEM(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_SET_DROPITEM, false, false, param1, param2); }
        public int AI_GET_AFFINITY() { return CallFlowFunction(FlowFunction.AI_GET_AFFINITY, false, false); }
        public int AI_GET_FRIDTURN(int param1) { return CallFlowFunction(FlowFunction.AI_GET_FRIDTURN, false, false, param1); }
        public int AI_GET_ENIDTURN(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ENIDTURN, false, false, param1); }
        public int AI_GET_FRHOJO_ON(int param1) { return CallFlowFunction(FlowFunction.AI_GET_FRHOJO_ON, false, false, param1); }
        public int AI_GET_FRHOJO_OFF(int param1) { return CallFlowFunction(FlowFunction.AI_GET_FRHOJO_OFF, false, false, param1); }
        public int AI_GET_ENHOJO_ON(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ENHOJO_ON, false, false, param1); }
        public int AI_GET_FRBAD_ON(int param1) { return CallFlowFunction(FlowFunction.AI_GET_FRBAD_ON, false, false, param1); }
        public int AI_GET_ENBAD_ON(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ENBAD_ON, false, false, param1); }
        public int AI_GET_FRHP(int param1) { return CallFlowFunction(FlowFunction.AI_GET_FRHP, false, false, param1); }
        public int AI_GET_FRLV() { return CallFlowFunction(FlowFunction.AI_GET_FRLV, false, false); }
        public int AI_GET_ENLV() { return CallFlowFunction(FlowFunction.AI_GET_ENLV, false, false); }
        public int AI_GET_SKILATTR(int param1) { return CallFlowFunction(FlowFunction.AI_GET_SKILATTR, false, false, param1); }
        public int AI_GET_FRCNT(int param1) { return CallFlowFunction(FlowFunction.AI_GET_FRCNT, false, false, param1); }
        public int AI_GET_UNI(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_GET_UNI, false, false, param1, param2); }
        public int AI_GET_UNIHPMIN() { return CallFlowFunction(FlowFunction.AI_GET_UNIHPMIN, false, false); }
        public int AI_GET_UNIWEAK(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIWEAK, false, false, param1); }
        public int AI_GET_UNIWEAK_ST(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIWEAK_ST, false, false, param1); }
        public int AI_GET_UNIWEAK_DW(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIWEAK_DW, false, false, param1); }
        public int AI_GET_UNIWEAKHPMIN(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIWEAKHPMIN, false, false, param1); }
        public int AI_GET_UNIWEAKHPMIN_ST(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIWEAKHPMIN_ST, false, false, param1); }
        public int AI_GET_UNIWEAKHPMIN_DW(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIWEAKHPMIN_DW, false, false, param1); }
        public int AI_GET_UNINOMALHPMIN(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNINOMALHPMIN, false, false, param1); }
        public int AI_GET_UNINOMALHPMIN_ST(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNINOMALHPMIN_ST, false, false, param1); }
        public int AI_GET_UNINOMALHPMIN_DW(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNINOMALHPMIN_DW, false, false, param1); }
        public int AI_GET_UNIBESTATTRSKIL(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.AI_GET_UNIBESTATTRSKIL, false, false, param1, param2, param3); }
        public int AI_GET_UNIBESTATTRITEM(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.AI_GET_UNIBESTATTRITEM, false, false, param1, param2, param3); }
        public int AI_GET_UNIBESTATKSKIL(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.AI_GET_UNIBESTATKSKIL, false, false, param1, param2, param3); }
        public int AI_GET_UNIAPPOINT() { return CallFlowFunction(FlowFunction.AI_GET_UNIAPPOINT, false, false); }
        public int AI_GET_UNIWEAKATTRSKIL(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIWEAKATTRSKIL, false, false, param1); }
        public int AI_GET_UNIHERO() { return CallFlowFunction(FlowFunction.AI_GET_UNIHERO, false, false); }
        public int AI_GET_UNIATAB(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIATAB, false, false, param1); }
        public int AI_GET_UNIATAB_ST(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIATAB_ST, false, false, param1); }
        public int AI_GET_UNIATAB_DW(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIATAB_DW, false, false, param1); }
        public int AI_GET_UNICND_FR(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.AI_GET_UNICND_FR, false, false, param1, param2, param3); }
        public int AI_GET_UNIHOJO_OFF_FR(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIHOJO_OFF_FR, false, false, param1); }
        public int AI_GET_UNIHOJO_OFF_EN(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIHOJO_OFF_EN, false, false, param1); }
        public int AI_GET_UNILVMAX_EN() { return CallFlowFunction(FlowFunction.AI_GET_UNILVMAX_EN, false, false); }
        public int AI_GET_UNINOMALLVMAXHPMAX(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNINOMALLVMAXHPMAX, false, false, param1); }
        public int AI_GET_UNINOMALNOTBAD(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNINOMALNOTBAD, false, false, param1); }
        public int AI_GET_UNINOTNOMAL(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNINOTNOMAL, false, false, param1); }
        public int AI_GET_MY_ID() { return CallFlowFunction(FlowFunction.AI_GET_MY_ID, false, false); }
        public int AI_GET_P_MAX_HP(int param1) { return CallFlowFunction(FlowFunction.AI_GET_P_MAX_HP, false, false, param1); }
        public int AI_GET_P_NOW_HP(int param1) { return CallFlowFunction(FlowFunction.AI_GET_P_NOW_HP, false, false, param1); }
        public int AI_GET_NEXT_ID() { return CallFlowFunction(FlowFunction.AI_GET_NEXT_ID, false, false); }
        public int AI_GET_P_ORDER(int param1) { return CallFlowFunction(FlowFunction.AI_GET_P_ORDER, false, false, param1); }
        public int AI_GET_P_MAX_SP(int param1) { return CallFlowFunction(FlowFunction.AI_GET_P_MAX_SP, false, false, param1); }
        public int AI_GET_P_NOW_SP(int param1) { return CallFlowFunction(FlowFunction.AI_GET_P_NOW_SP, false, false, param1); }
        public int AI_GET_UNIHOJO_ON_EN(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIHOJO_ON_EN, false, false, param1); }
        public int AI_GET_UNIHANSYA(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIHANSYA, false, false, param1); }
        public int AI_GET_UNIKYUSYU(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIKYUSYU, false, false, param1); }
        public int AI_GET_UNIMUKOU(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIMUKOU, false, false, param1); }
        public int AI_GET_UNIRESIST(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIRESIST, false, false, param1); }
        public int AI_GET_UNIWEAKHPMAX(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIWEAKHPMAX, false, false, param1); }
        public int AI_GET_UNIWEAKHPMAX_ST(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIWEAKHPMAX_ST, false, false, param1); }
        public int AI_GET_UNIWEAKHPMAX_DW(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIWEAKHPMAX_DW, false, false, param1); }
        public int AI_GET_UNIBADHPMAX(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIBADHPMAX, false, false, param1); }
        public int AI_GET_UNIBADHPMIN(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIBADHPMIN, false, false, param1); }
        public int AI_GET_UNIRANDOM() { return CallFlowFunction(FlowFunction.AI_GET_UNIRANDOM, false, false); }
        public int AI_DEB_PRI_TARUNI_ID() { return CallFlowFunction(FlowFunction.AI_DEB_PRI_TARUNI_ID, false, false); }
        public int AI_CHK_ISENEMY() { return CallFlowFunction(FlowFunction.AI_CHK_ISENEMY, false, false); }
        public int AI_SET_BADSTATUS(int param1) { return CallFlowFunction(FlowFunction.AI_SET_BADSTATUS, false, false, param1); }
        public int AI_CHG_CAMERA_FIX(float param1, float param2, float param3, float param4, float param5, float param6) { return CallFlowFunction(FlowFunction.AI_CHG_CAMERA_FIX, false, false, param1, param2, param3, param4, param5, param6); }
        public int AI_SET_CAMERA_ANM_S(float param1, float param2, float param3, float param4, float param5, float param6) { return CallFlowFunction(FlowFunction.AI_SET_CAMERA_ANM_S, false, false, param1, param2, param3, param4, param5, param6); }
        public int AI_SET_CAMERA_ANM_E(float param1, float param2, float param3, float param4, float param5, float param6) { return CallFlowFunction(FlowFunction.AI_SET_CAMERA_ANM_E, false, false, param1, param2, param3, param4, param5, param6); }
        public int AI_SET_CAMERA_ANM_TIME(int param1) { return CallFlowFunction(FlowFunction.AI_SET_CAMERA_ANM_TIME, false, false, param1); }
        public int AI_CHG_CAMERA_ANM(int param1) { return CallFlowFunction(FlowFunction.AI_CHG_CAMERA_ANM, false, false, param1); }
        public int AI_SET_CAMERA_ANM_TYPE(int param1) { return CallFlowFunction(FlowFunction.AI_SET_CAMERA_ANM_TYPE, false, false, param1); }
        public void CALL_BATTLE(int param1) { CallFlowFunction(FlowFunction.CALL_BATTLE, false, false, param1); }
        public void WAIT_BATTLE() { CallFlowFunction(FlowFunction.WAIT_BATTLE, false, false); }
        public void BTL_FADE_IN() { CallFlowFunction(FlowFunction.BTL_FADE_IN, false, false); }
        public void BTL_FADE_SYNC() { CallFlowFunction(FlowFunction.BTL_FADE_SYNC, false, false); }
        public int BTL_CUTSCENE_LOAD(int param1, int param2) { return CallFlowFunction(FlowFunction.BTL_CUTSCENE_LOAD, false, false, param1, param2); }
        public void BTL_CUTSCENE_LOADSYNC(int param1) { CallFlowFunction(FlowFunction.BTL_CUTSCENE_LOADSYNC, false, false, param1); }
        public void BTL_CUTSCENE_PLAY(int param1, int param2, int param3, int param4, int param5) { CallFlowFunction(FlowFunction.BTL_CUTSCENE_PLAY, false, false, param1, param2, param3, param4, param5); }
        public void BTL_CUTSCENE_SYNC(int param1) { CallFlowFunction(FlowFunction.BTL_CUTSCENE_SYNC, false, false, param1); }
        public void BTL_CUTSCENE_END(int param1) { CallFlowFunction(FlowFunction.BTL_CUTSCENE_END, false, false, param1); }
        public void AI_ACT_WAIT() { CallFlowFunction(FlowFunction.AI_ACT_WAIT, false, false); }
        public int AI_CHK_PLAYER_ID(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_PLAYER_ID, false, false, param1); }
        public int AI_CHK_MYID(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_MYID, false, false, param1, param2); }
        public int AI_GET_MYATTRATTACK() { return CallFlowFunction(FlowFunction.AI_GET_MYATTRATTACK, false, false); }
        public int AI_GET_E_NUM() { return CallFlowFunction(FlowFunction.AI_GET_E_NUM, false, false); }
        public int AI_GET_UNI_NOANALYZE(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNI_NOANALYZE, false, false, param1); }
        public int AI_CHK_UNIHOJO(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_UNIHOJO, false, false, param1, param2); }
        public int AI_CHK_ENRESIST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENRESIST, false, false, param1); }
        public int AI_GET_ATTRSKIL(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_GET_ATTRSKIL, false, false, param1, param2); }
        public int AI_CHK_BOSS() { return CallFlowFunction(FlowFunction.AI_CHK_BOSS, false, false); }
        public int AI_CHK_UNIATTACK(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_UNIATTACK, false, false, param1); }
        public int AI_ACT_UNIBESTATKSKIL_ALL(int param1) { return CallFlowFunction(FlowFunction.AI_ACT_UNIBESTATKSKIL_ALL, false, false, param1); }
        public int AI_CHK_UNIRESIST(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_UNIRESIST, false, false, param1, param2); }
        public int AI_CHK_UNIBAD(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_UNIBAD, false, false, param1, param2); }
        public int AI_CHK_UNINOMAL(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_UNINOMAL, false, false, param1, param2); }
        public int AI_CHK_P_ABLE_SKILL(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_P_ABLE_SKILL, false, false, param1, param2); }
        public int AI_GET_ENBADOFF(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ENBADOFF, false, false, param1); }
        public int AI_GET_UNINOBADOFF(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNINOBADOFF, false, false, param1); }
        public int AI_CHK_UNIHP(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_UNIHP, false, false, param1, param2); }
        public int AI_CHK_FRIDABLESKIL(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDABLESKIL, false, false, param1, param2); }
        public int AI_CHK_MYRESIST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYRESIST, false, false, param1); }
        public int AI_CHK_MYHOJO(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYHOJO, false, false, param1); }
        public int AI_GET_FIRST_ACTION() { return CallFlowFunction(FlowFunction.AI_GET_FIRST_ACTION, false, false); }
        public int AI_GET_GLOBAL(int param1) { return CallFlowFunction(FlowFunction.AI_GET_GLOBAL, false, false, param1); }
        public int AI_GET_P_NUM() { return CallFlowFunction(FlowFunction.AI_GET_P_NUM, false, false); }
        public void AI_SET_ASSISTSKILL_MODE(int param1) { CallFlowFunction(FlowFunction.AI_SET_ASSISTSKILL_MODE, false, false, param1); }
        public int AI_CHK_FRALLSP(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRALLSP, false, false, param1); }
        public int AI_SET_GLOBAL(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_SET_GLOBAL, false, false, param1, param2); }
        public int AI_SET_CAMERA_END(int param1) { return CallFlowFunction(FlowFunction.AI_SET_CAMERA_END, false, false, param1); }
        public int AI_GET_UNI_TALKCHARA() { return CallFlowFunction(FlowFunction.AI_GET_UNI_TALKCHARA, false, false); }
        public int AI_CHK_ID_PSTOCK(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ID_PSTOCK, false, false, param1); }
        public void AI_SET_TALKRESULT(int param1) { CallFlowFunction(FlowFunction.AI_SET_TALKRESULT, false, false, param1); }
        public void AI_SET_CAMERA_FOV_S(float param1) { CallFlowFunction(FlowFunction.AI_SET_CAMERA_FOV_S, false, false, param1); }
        public void AI_SET_CAMERA_ROTANM_S(float param1) { CallFlowFunction(FlowFunction.AI_SET_CAMERA_ROTANM_S, false, false, param1); }
        public void AI_SET_CAMERA_ROTANM_E(float param1) { CallFlowFunction(FlowFunction.AI_SET_CAMERA_ROTANM_E, false, false, param1); }
        public void AI_SET_CAMERA_RESET() { CallFlowFunction(FlowFunction.AI_SET_CAMERA_RESET, false, false); }
        public void AI_SET_CAMERA_FOV_E(float param1) { CallFlowFunction(FlowFunction.AI_SET_CAMERA_FOV_E, false, false, param1); }
        public int AI_GET_ID_TALKCHARA() { return CallFlowFunction(FlowFunction.AI_GET_ID_TALKCHARA, false, false); }
        public int AI_GET_IDLV(int param1) { return CallFlowFunction(FlowFunction.AI_GET_IDLV, false, false, param1); }
        public void AI_SET_CAMERA_SHAKE_S(int param1, float param2, float param3, float param4) { CallFlowFunction(FlowFunction.AI_SET_CAMERA_SHAKE_S, false, false, param1, param2, param3, param4); }
        public void AI_SET_CAMERA_SHAKE_E(float param1) { CallFlowFunction(FlowFunction.AI_SET_CAMERA_SHAKE_E, false, false, param1); }
        public int AI_CHK_PBOOK_REGIST(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_PBOOK_REGIST, false, false, param1); }
        public int AI_GET_ID_TALK_TYPE(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ID_TALK_TYPE, false, false, param1); }
        public int AI_GET_ID_TALK_PERSON(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ID_TALK_PERSON, false, false, param1); }
        public int AI_GET_ID_TALK_MONEYMIN(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ID_TALK_MONEYMIN, false, false, param1); }
        public int AI_GET_ID_TALK_MONEYMAX(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ID_TALK_MONEYMAX, false, false, param1); }
        public int AI_GET_ID_TALK_ITEM(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_GET_ID_TALK_ITEM, false, false, param1, param2); }
        public int AI_GET_ID_TALK_ITEM_RARE(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_GET_ID_TALK_ITEM_RARE, false, false, param1, param2); }
        public void AI_SET_TALK_SPEAKER(int param1) { CallFlowFunction(FlowFunction.AI_SET_TALK_SPEAKER, false, false, param1); }
        public void AI_SET_ADD_FACEANIM(int param1, int param2, float param3) { CallFlowFunction(FlowFunction.AI_SET_ADD_FACEANIM, false, false, param1, param2, param3); }
        public int AI_SET_GLOBAL_EVENT(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_SET_GLOBAL_EVENT, false, false, param1, param2); }
        public int AI_GET_GLOBAL_EVENT(int param1) { return CallFlowFunction(FlowFunction.AI_GET_GLOBAL_EVENT, false, false, param1); }
        public int BTL_CUTSCENE_LOAD_TALK(int param1) { return CallFlowFunction(FlowFunction.BTL_CUTSCENE_LOAD_TALK, false, false, param1); }
        public int AI_SET_LOCAL_PARAM(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_SET_LOCAL_PARAM, false, false, param1, param2); }
        public int AI_GET_LOCAL_PARAM(int param1) { return CallFlowFunction(FlowFunction.AI_GET_LOCAL_PARAM, false, false, param1); }
        public void BTL_CUTSCENE_CANCEL(int param1) { CallFlowFunction(FlowFunction.BTL_CUTSCENE_CANCEL, false, false, param1); }
        public void AI_ACT_WAIT3(int param1) { CallFlowFunction(FlowFunction.AI_ACT_WAIT3, false, false, param1); }
        public void BTL_CUTSCENE_REMOVE(int param1) { CallFlowFunction(FlowFunction.BTL_CUTSCENE_REMOVE, false, false, param1); }
        public void BTL_RELOCATION() { CallFlowFunction(FlowFunction.BTL_RELOCATION, false, false); }
        public int AI_CHK_ID_FRTARGET(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ID_FRTARGET, false, false, param1); }
        public int AI_TAR_UID(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_UID, false, false, param1); }
        public int AI_SET_ENIDAFFINITY(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_SET_ENIDAFFINITY, false, false, param1, param2); }
        public int AI_GET_ENIDAFFINITY(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ENIDAFFINITY, false, false, param1); }
        public int AI_CHK_ABLEWEAK(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ABLEWEAK, false, false, param1); }
        public int AI_ACT_TAKEOVER(int param1) { return CallFlowFunction(FlowFunction.AI_ACT_TAKEOVER, false, false, param1); }
        public int AI_CHK_TAKEOVER(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_TAKEOVER, false, false, param1); }
        public int AI_SET_ENID_MAXSERIAL(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_SET_ENID_MAXSERIAL, false, false, param1, param2); }
        public int AI_GET_ENID_MAXSERIAL(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ENID_MAXSERIAL, false, false, param1); }
        public int AI_GET_ENID_CURRENTSERIAL(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ENID_CURRENTSERIAL, false, false, param1); }
        public void AI_SET_TALKCUTSCENE_PLAY(int param1) { CallFlowFunction(FlowFunction.AI_SET_TALKCUTSCENE_PLAY, false, false, param1); }
        public void AI_SET_TALKMESS_SCENE(int param1) { CallFlowFunction(FlowFunction.AI_SET_TALKMESS_SCENE, false, false, param1); }
        public void AI_SET_TALKMESS_WAIT() { CallFlowFunction(FlowFunction.AI_SET_TALKMESS_WAIT, false, false); }
        public void AI_SET_TALKMESS_PARAM() { CallFlowFunction(FlowFunction.AI_SET_TALKMESS_PARAM, false, false); }
        public void AI_SET_TALKMESS_EN_PARAM() { CallFlowFunction(FlowFunction.AI_SET_TALKMESS_EN_PARAM, false, false); }
        public void AI_SET_TALKMESS_STATE(int param1) { CallFlowFunction(FlowFunction.AI_SET_TALKMESS_STATE, false, false, param1); }
        public void CALL_EVENTBATTLE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.CALL_EVENTBATTLE, false, false, param1, param2, param3); }
        public void AI_SET_TALKMESS_OBTAIN(int param1) { CallFlowFunction(FlowFunction.AI_SET_TALKMESS_OBTAIN, false, false, param1); }
        public int AI_CHK_TALKMESS_INFODATA() { return CallFlowFunction(FlowFunction.AI_CHK_TALKMESS_INFODATA, false, false); }
        public void AI_SET_TALKMESS_MASK(int param1) { CallFlowFunction(FlowFunction.AI_SET_TALKMESS_MASK, false, false, param1); }
        public void AI_SET_TALKMESS_DOUBLE() { CallFlowFunction(FlowFunction.AI_SET_TALKMESS_DOUBLE, false, false); }
        public int AI_CHK_TALKMESS_CRITICAL() { return CallFlowFunction(FlowFunction.AI_CHK_TALKMESS_CRITICAL, false, false); }
        public int AI_CHK_TALKMESS_SURRENDER() { return CallFlowFunction(FlowFunction.AI_CHK_TALKMESS_SURRENDER, false, false); }
        public void AI_SET_TALKMESS_COOP(int param1) { CallFlowFunction(FlowFunction.AI_SET_TALKMESS_COOP, false, false, param1); }
        public void BTL_CUTSCENE_CAPTURE_ENDFRAME(int param1) { CallFlowFunction(FlowFunction.BTL_CUTSCENE_CAPTURE_ENDFRAME, false, false, param1); }
        public int AI_CHK_UNIANALYZE_OPEN(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_UNIANALYZE_OPEN, false, false, param1, param2); }
        public int AI_CHK_GUN() { return CallFlowFunction(FlowFunction.AI_CHK_GUN, false, false); }
        public void AI_ACT_GUN() { CallFlowFunction(FlowFunction.AI_ACT_GUN, false, false); }
        public int AI_ACT_HIGHSKILL(int param1) { return CallFlowFunction(FlowFunction.AI_ACT_HIGHSKILL, false, false, param1); }
        public int AI_ACT_REZ() { return CallFlowFunction(FlowFunction.AI_ACT_REZ, false, false); }
        public int AI_ACT_BADSTATE() { return CallFlowFunction(FlowFunction.AI_ACT_BADSTATE, false, false); }
        public int AI_ACT_BOSS_PRESIDENT_SUMMON() { return CallFlowFunction(FlowFunction.AI_ACT_BOSS_PRESIDENT_SUMMON, false, false); }
        public int AI_CHK_TURN_EQUAL(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_TURN_EQUAL, false, false, param1); }
        public int AI_CHK_TURN_DIVI(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_TURN_DIVI, false, false, param1); }
        public int AI_CHK_NOTMYBAD(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_NOTMYBAD, false, false, param1); }
        public int AI_CHK_NOTFRBAD(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_NOTFRBAD, false, false, param1); }
        public int AI_CHK_NOTENBAD(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_NOTENBAD, false, false, param1); }
        public int AI_CHK_NOTMYHOJO(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_NOTMYHOJO, false, false, param1); }
        public int AI_CHK_NOTFRHOJO(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_NOTFRHOJO, false, false, param1); }
        public int AI_CHK_NOTENHOJO(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_NOTENHOJO, false, false, param1); }
        public int AI_CHK_PREV_ATK() { return CallFlowFunction(FlowFunction.AI_CHK_PREV_ATK, false, false); }
        public int AI_CHK_PREV_WAIT() { return CallFlowFunction(FlowFunction.AI_CHK_PREV_WAIT, false, false); }
        public void BTL_SYSTEM_MESS(int param1) { CallFlowFunction(FlowFunction.BTL_SYSTEM_MESS, false, false, param1); }
        public int AI_CHK_EXTENDEDWAIT() { return CallFlowFunction(FlowFunction.AI_CHK_EXTENDEDWAIT, false, false); }
        public int AI_CHK_ENEMY_ABLEWEAK(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENEMY_ABLEWEAK, false, false, param1); }
        public int AI_ACT_ENTAKEOVER(int param1) { return CallFlowFunction(FlowFunction.AI_ACT_ENTAKEOVER, false, false, param1); }
        public int BTL_ROULETTE_BET() { return CallFlowFunction(FlowFunction.BTL_ROULETTE_BET, false, false); }
        public int AI_GET_UIDTOID(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UIDTOID, false, false, param1); }
        public int AI_GET_ENHP(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ENHP, false, false, param1); }
        public int AI_CHK_ENALLDOWN() { return CallFlowFunction(FlowFunction.AI_CHK_ENALLDOWN, false, false); }
        public int AI_GET_BOSSDAMAGE() { return CallFlowFunction(FlowFunction.AI_GET_BOSSDAMAGE, false, false); }
        public void AI_CLEAR_BOSSDAMAGE() { CallFlowFunction(FlowFunction.AI_CLEAR_BOSSDAMAGE, false, false); }
        public int AI_GET_ACTUID() { return CallFlowFunction(FlowFunction.AI_GET_ACTUID, false, false); }
        public void AI_SET_VOICE(int param1) { CallFlowFunction(FlowFunction.AI_SET_VOICE, false, false, param1); }
        public int AI_GET_UNI_DARK(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNI_DARK, false, false, param1); }
        public void BTL_ADD_SERIES(int param1) { CallFlowFunction(FlowFunction.BTL_ADD_SERIES, false, false, param1); }
        public int BTL_GET_SERIES() { return CallFlowFunction(FlowFunction.BTL_GET_SERIES, false, false); }
        public int AI_CHK_ID_TALK_FLAG(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ID_TALK_FLAG, false, false, param1); }
        public void AI_SET_TALK_ITEM(int param1) { CallFlowFunction(FlowFunction.AI_SET_TALK_ITEM, false, false, param1); }
        public void AI_SET_TALK_ITEM_RARE(int param1) { CallFlowFunction(FlowFunction.AI_SET_TALK_ITEM_RARE, false, false, param1); }
        public int AI_ACT_DEBUFF(int param1) { return CallFlowFunction(FlowFunction.AI_ACT_DEBUFF, false, false, param1); }
        public int AI_ACT_UNKNOWN_ATTR(int param1) { return CallFlowFunction(FlowFunction.AI_ACT_UNKNOWN_ATTR, false, false, param1); }
        public int AI_GET_TALK_MAJOR() { return CallFlowFunction(FlowFunction.AI_GET_TALK_MAJOR, false, false); }
        public int AI_CHK_EXCEPTION() { return CallFlowFunction(FlowFunction.AI_CHK_EXCEPTION, false, false); }
        public void BTL_REQ_ASSIST(int param1, int param2) { CallFlowFunction(FlowFunction.BTL_REQ_ASSIST, false, false, param1, param2); }
        public void BTL_CLS_ASSIST() { CallFlowFunction(FlowFunction.BTL_CLS_ASSIST, false, false); }
        public int AI_CHK_ROUNDUP() { return CallFlowFunction(FlowFunction.AI_CHK_ROUNDUP, false, false); }
        public void AI_SET_MSGVAR(int param1) { CallFlowFunction(FlowFunction.AI_SET_MSGVAR, false, false, param1); }
        public int AI_GET_UNIHPMIN_EN() { return CallFlowFunction(FlowFunction.AI_GET_UNIHPMIN_EN, false, false); }
        public void AI_ACT_ESCAPE() { CallFlowFunction(FlowFunction.AI_ACT_ESCAPE, false, false); }
        public int BTL_CHK_ENCOUNTFLAG(int param1) { return CallFlowFunction(FlowFunction.BTL_CHK_ENCOUNTFLAG, false, false, param1); }
        public int AI_GET_UNI_SKIMMING(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNI_SKIMMING, false, false, param1); }
        public int AI_GET_UNI_TALKCONTACT(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNI_TALKCONTACT, false, false, param1); }
        public int AI_SET_FRID_MAXSERIAL(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_SET_FRID_MAXSERIAL, false, false, param1, param2); }
        public int AI_GET_FRID_MAXSERIAL(int param1) { return CallFlowFunction(FlowFunction.AI_GET_FRID_MAXSERIAL, false, false, param1); }
        public void AI_ACT_DEFENSE() { CallFlowFunction(FlowFunction.AI_ACT_DEFENSE, false, false); }
        public int AI_ACT_FIXED() { return CallFlowFunction(FlowFunction.AI_ACT_FIXED, false, false); }
        public int AI_ACT_HEAL(int param1) { return CallFlowFunction(FlowFunction.AI_ACT_HEAL, false, false, param1); }
        public void BTL_TALK_ADDWANTED(int param1) { CallFlowFunction(FlowFunction.BTL_TALK_ADDWANTED, false, false, param1); }
        public int BTL_TALK_PERSONAGET_LOADREQ() { return CallFlowFunction(FlowFunction.BTL_TALK_PERSONAGET_LOADREQ, false, false); }
        public int BTL_TALK_PERSONAGET_LOADWAIT() { return CallFlowFunction(FlowFunction.BTL_TALK_PERSONAGET_LOADWAIT, false, false); }
        public int AI_ACT_GUARDORDER() { return CallFlowFunction(FlowFunction.AI_ACT_GUARDORDER, false, false); }
        public int AI_SET_GUARDORDER(int param1) { return CallFlowFunction(FlowFunction.AI_SET_GUARDORDER, false, false, param1); }
        public int AI_GET_UNI_ATTACK() { return CallFlowFunction(FlowFunction.AI_GET_UNI_ATTACK, false, false); }
        public int BTL_CHK_DUNGEONMATCH() { return CallFlowFunction(FlowFunction.BTL_CHK_DUNGEONMATCH, false, false); }
        public int BTL_SET_STARTDUNGEONMATCH() { return CallFlowFunction(FlowFunction.BTL_SET_STARTDUNGEONMATCH, false, false); }
        public int BTL_WAIT_DUNGEONMATCH() { return CallFlowFunction(FlowFunction.BTL_WAIT_DUNGEONMATCH, false, false); }
        public void AI_ENID_SUSPEND(int param1) { CallFlowFunction(FlowFunction.AI_ENID_SUSPEND, false, false, param1); }
        public void AI_ENID_RESUME(int param1) { CallFlowFunction(FlowFunction.AI_ENID_RESUME, false, false, param1); }
        public int AI_CHK_EXCEPT_ENCOUNT(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_EXCEPT_ENCOUNT, false, false, param1); }
        public void AI_FRID_SUSPEND(int param1) { CallFlowFunction(FlowFunction.AI_FRID_SUSPEND, false, false, param1); }
        public void AI_FRID_RESUME(int param1) { CallFlowFunction(FlowFunction.AI_FRID_RESUME, false, false, param1); }
        public int BTL_TALK_WEATHER_ITEM(int param1) { return CallFlowFunction(FlowFunction.BTL_TALK_WEATHER_ITEM, false, false, param1); }
        public int BTL_TALK_CHECK_NO_YOU() { return CallFlowFunction(FlowFunction.BTL_TALK_CHECK_NO_YOU, false, false); }
        public int BTL_TALK_NO_YOU() { return CallFlowFunction(FlowFunction.BTL_TALK_NO_YOU, false, false); }
        public void PREPARE_FIELDBATTLE(int param1) { CallFlowFunction(FlowFunction.PREPARE_FIELDBATTLE, false, false, param1); }
        public void CALL_FIELDBATTLE() { CallFlowFunction(FlowFunction.CALL_FIELDBATTLE, false, false); }
        public int BTL_TALK_ICON_PLAY(int param1) { return CallFlowFunction(FlowFunction.BTL_TALK_ICON_PLAY, false, false, param1); }
        public void BTL_SET_MSG_SPEAKER(int param1) { CallFlowFunction(FlowFunction.BTL_SET_MSG_SPEAKER, false, false, param1); }
        public int BTL_TALK_GET_SELECTNO() { return CallFlowFunction(FlowFunction.BTL_TALK_GET_SELECTNO, false, false); }
        public void BTL_BOSSSE_PLAY(int param1) { CallFlowFunction(FlowFunction.BTL_BOSSSE_PLAY, false, false, param1); }
        public int BTL_TALK_SET_RESETCAMERA() { return CallFlowFunction(FlowFunction.BTL_TALK_SET_RESETCAMERA, false, false); }
        public int BTL_TALK_SET_ASSIST(int param1) { return CallFlowFunction(FlowFunction.BTL_TALK_SET_ASSIST, false, false, param1); }
        public void BTL_CUTSCENE_BOSS999_PLAY(int param1, int param2, int param3, int param4, int param5) { CallFlowFunction(FlowFunction.BTL_CUTSCENE_BOSS999_PLAY, false, false, param1, param2, param3, param4, param5); }
        public int BTL_TALK_GET_YOSHIDACOOP() { return CallFlowFunction(FlowFunction.BTL_TALK_GET_YOSHIDACOOP, false, false); }
        public int BTL_TALK_CHK_USONAKI() { return CallFlowFunction(FlowFunction.BTL_TALK_CHK_USONAKI, false, false); }
        public void BTL_MISSION_ADD(int param1) { CallFlowFunction(FlowFunction.BTL_MISSION_ADD, false, false, param1); }
        public void BTL_MISSION_REMOVE(int param1) { CallFlowFunction(FlowFunction.BTL_MISSION_REMOVE, false, false, param1); }
        public void BTL_LETTERBOX_IN(int param1) { CallFlowFunction(FlowFunction.BTL_LETTERBOX_IN, false, false, param1); }
        public void BTL_LETTERBOX_OUT(int param1) { CallFlowFunction(FlowFunction.BTL_LETTERBOX_OUT, false, false, param1); }
        public int BTL_CHK_NOTPHYSICAL() { return CallFlowFunction(FlowFunction.BTL_CHK_NOTPHYSICAL, false, false); }
        public void BTL_ROULETTE_BET_LOAD() { CallFlowFunction(FlowFunction.BTL_ROULETTE_BET_LOAD, false, false); }
        public void AI_ACT_DANGERUP() { CallFlowFunction(FlowFunction.AI_ACT_DANGERUP, false, false); }
        public void BTL_SYNC_ASSIST() { CallFlowFunction(FlowFunction.BTL_SYNC_ASSIST, false, false); }
        public int AI_ACT_TECHNICAL() { return CallFlowFunction(FlowFunction.AI_ACT_TECHNICAL, false, false); }
        public int AI_TAR_HPMAX() { return CallFlowFunction(FlowFunction.AI_TAR_HPMAX, false, false); }
        public int AI_CHK_FMTPINCH() { return CallFlowFunction(FlowFunction.AI_CHK_FMTPINCH, false, false); }
        public int AI_CHK_ID_ENTARGET(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ID_ENTARGET, false, false, param1); }
        public int AI_GET_UID_IDBAD(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_GET_UID_IDBAD, false, false, param1, param2); }
        public int AI_GET_UID_IDSUPPORT(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_GET_UID_IDSUPPORT, false, false, param1, param2); }
        public int AI_GET_UID_IDNOTBAD(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_GET_UID_IDNOTBAD, false, false, param1, param2); }
        public int AI_GET_UID_IDNOTSUPPORT(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_GET_UID_IDNOTSUPPORT, false, false, param1, param2); }
        public int BTL_CUTIN_CREATE(int param1) { return CallFlowFunction(FlowFunction.BTL_CUTIN_CREATE, false, false, param1); }
        public int BTL_CUTIN_SYNC() { return CallFlowFunction(FlowFunction.BTL_CUTIN_SYNC, false, false); }
        public int BTL_CUTIN_START() { return CallFlowFunction(FlowFunction.BTL_CUTIN_START, false, false); }
        public int BTL_CUTIN_START_SYNC() { return CallFlowFunction(FlowFunction.BTL_CUTIN_START_SYNC, false, false); }
        public int BTL_CUTIN_END_SYNC() { return CallFlowFunction(FlowFunction.BTL_CUTIN_END_SYNC, false, false); }
        public int BTL_CUTIN_DELETE() { return CallFlowFunction(FlowFunction.BTL_CUTIN_DELETE, false, false); }
        public int BTL_TALK_EXIST_BLANK() { return CallFlowFunction(FlowFunction.BTL_TALK_EXIST_BLANK, false, false); }
        public int AI_GET_ENTALK_ITEM() { return CallFlowFunction(FlowFunction.AI_GET_ENTALK_ITEM, false, false); }
        public int AI_GET_ENTALK_MONEY() { return CallFlowFunction(FlowFunction.AI_GET_ENTALK_MONEY, false, false); }
        public void BTL_TALK_ALLY_SPEAKER(int param1) { CallFlowFunction(FlowFunction.BTL_TALK_ALLY_SPEAKER, false, false, param1); }
        public void AI_ADD_REINFORCEMENT(int param1) { CallFlowFunction(FlowFunction.AI_ADD_REINFORCEMENT, false, false, param1); }
        public void BTL_TALK_REQ_JYOKYO(int param1) { CallFlowFunction(FlowFunction.BTL_TALK_REQ_JYOKYO, false, false, param1); }
        public void BTL_TALK_REQ_SKILLNAME(int param1) { CallFlowFunction(FlowFunction.BTL_TALK_REQ_SKILLNAME, false, false, param1); }
        public int AI_ACT_ATTACK_WEAK(int param1) { return CallFlowFunction(FlowFunction.AI_ACT_ATTACK_WEAK, false, false, param1); }
        public int AI_CHK_DEATHMARCH() { return CallFlowFunction(FlowFunction.AI_CHK_DEATHMARCH, false, false); }
        public int AI_CHK_FRHOJO2(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRHOJO2, false, false, param1); }
        public int AI_CHK_ENHOJO2(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ENHOJO2, false, false, param1); }
        public int AI_CHK_FRIDHOJO2(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDHOJO2, false, false, param1, param2); }
        public int AI_CHK_ENIDHOJO2(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_ENIDHOJO2, false, false, param1, param2); }
        public int AI_TAR_HOJO2(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_HOJO2, false, false, param1); }
        public int AI_TAR_NOTHOJO2(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_NOTHOJO2, false, false, param1); }
        public int AI_GET_FRHOJO2_ON(int param1) { return CallFlowFunction(FlowFunction.AI_GET_FRHOJO2_ON, false, false, param1); }
        public int AI_GET_FRHOJO2_OFF(int param1) { return CallFlowFunction(FlowFunction.AI_GET_FRHOJO2_OFF, false, false, param1); }
        public int AI_GET_ENHOJO2_ON(int param1) { return CallFlowFunction(FlowFunction.AI_GET_ENHOJO2_ON, false, false, param1); }
        public int AI_GET_UNIHOJO2_OFF_FR(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIHOJO2_OFF_FR, false, false, param1); }
        public int AI_GET_UNIHOJO2_OFF_EN(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIHOJO2_OFF_EN, false, false, param1); }
        public int AI_GET_UNIHOJO2_ON_EN(int param1) { return CallFlowFunction(FlowFunction.AI_GET_UNIHOJO2_ON_EN, false, false, param1); }
        public int AI_CHK_UNIHOJO2(int param1, int param2) { return CallFlowFunction(FlowFunction.AI_CHK_UNIHOJO2, false, false, param1, param2); }
        public int AI_CHK_MYHOJO2(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_MYHOJO2, false, false, param1); }
        public int AI_CHK_NOTMYHOJO2(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_NOTMYHOJO2, false, false, param1); }
        public int AI_CHK_NOTFRHOJO2(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_NOTFRHOJO2, false, false, param1); }
        public int AI_CHK_NOTENHOJO2(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_NOTENHOJO2, false, false, param1); }
        public int AI_CHK_MYUNSTABLE() { return CallFlowFunction(FlowFunction.AI_CHK_MYUNSTABLE, false, false); }
        public int AI_CHK_UNSTABLE_UID(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_UNSTABLE_UID, false, false, param1); }
        public int BTL_GET_CURRENT_CHARAID() { return CallFlowFunction(FlowFunction.BTL_GET_CURRENT_CHARAID, false, false); }
        public int AI_CHK_FRIDTECH(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_FRIDTECH, false, false, param1); }
        public int AI_GET_BULLET() { return CallFlowFunction(FlowFunction.AI_GET_BULLET, false, false); }
        public int AI_TAR_UNSTABLE() { return CallFlowFunction(FlowFunction.AI_TAR_UNSTABLE, false, false); }
        public int AI_TAR_NUNSTABLE() { return CallFlowFunction(FlowFunction.AI_TAR_NUNSTABLE, false, false); }
        public int AI_TAR_HOUMA() { return CallFlowFunction(FlowFunction.AI_TAR_HOUMA, false, false); }
        public int AI_TAR_NHOUMA() { return CallFlowFunction(FlowFunction.AI_TAR_NHOUMA, false, false); }
        public int AI_CHK_UNSTABLE() { return CallFlowFunction(FlowFunction.AI_CHK_UNSTABLE, false, false); }
        public int AI_CHK_HOUMA() { return CallFlowFunction(FlowFunction.AI_CHK_HOUMA, false, false); }
        public int AI_CHK_UNSTABLE_BAD(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_UNSTABLE_BAD, false, false, param1); }
        public int AI_CHK_UNSTABLE_NBAD(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_UNSTABLE_NBAD, false, false, param1); }
        public int AI_TAR_UNSTABLE_BAD(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_UNSTABLE_BAD, false, false, param1); }
        public int AI_TAR_UNSTABLE_NBAD(int param1) { return CallFlowFunction(FlowFunction.AI_TAR_UNSTABLE_NBAD, false, false, param1); }
        public int AI_CHK_GUN_KILL_EN() { return CallFlowFunction(FlowFunction.AI_CHK_GUN_KILL_EN, false, false); }
        public int AI_TAR_GUN_KILL_EN() { return CallFlowFunction(FlowFunction.AI_TAR_GUN_KILL_EN, false, false); }
        public int AI_CHK_SP_ATTACK() { return CallFlowFunction(FlowFunction.AI_CHK_SP_ATTACK, false, false); }
        public void AI_ACT_SP_ATTACK() { CallFlowFunction(FlowFunction.AI_ACT_SP_ATTACK, false, false); }
        public int BTL_GET_CHALLENGE_REWARD(int param1, int param2) { return CallFlowFunction(FlowFunction.BTL_GET_CHALLENGE_REWARD, false, false, param1, param2); }
        public void BTL_REQ_ASSIST_SEQ(int param1, int param2) { CallFlowFunction(FlowFunction.BTL_REQ_ASSIST_SEQ, false, false, param1, param2); }
        public int AI_ACT_BADSKILL() { return CallFlowFunction(FlowFunction.AI_ACT_BADSKILL, false, false); }
        public int AI_CHK_ID_STRONG_FLAG(int param1) { return CallFlowFunction(FlowFunction.AI_CHK_ID_STRONG_FLAG, false, false, param1); }
        public int BTL_GET_CHALLENGE_MODE(int param1) { return CallFlowFunction(FlowFunction.BTL_GET_CHALLENGE_MODE, false, false, param1); }
        public int BTL_GET_CHALLENGE_NUMBER(int param1) { return CallFlowFunction(FlowFunction.BTL_GET_CHALLENGE_NUMBER, false, false, param1); }
        public int BTL_GET_CHALLENGE_REWARD_TYPE(int param1, int param2) { return CallFlowFunction(FlowFunction.BTL_GET_CHALLENGE_REWARD_TYPE, false, false, param1, param2); }
        public int BTL_GER_TALK_ABI_MEMBER_ID(int param1) { return CallFlowFunction(FlowFunction.BTL_GER_TALK_ABI_MEMBER_ID, false, false, param1); }
        public void BTL_ITEM_STORAGE_SAVE() { CallFlowFunction(FlowFunction.BTL_ITEM_STORAGE_SAVE, false, false); }
        public void BTL_ITEM_STORAGE_LOAD() { CallFlowFunction(FlowFunction.BTL_ITEM_STORAGE_LOAD, false, false); }
        public void BTL_ITEM_STORAGE_CLEAR() { CallFlowFunction(FlowFunction.BTL_ITEM_STORAGE_CLEAR, false, false); }
        public int BTL_ITEM_STORAGE_CHECK() { return CallFlowFunction(FlowFunction.BTL_ITEM_STORAGE_CHECK, false, false); }
        public void AI_CANCEL_GUARDORDER(int param1) { CallFlowFunction(FlowFunction.AI_CANCEL_GUARDORDER, false, false, param1); }
        public int BTL_GET_ASSIST_PC_ID() { return CallFlowFunction(FlowFunction.BTL_GET_ASSIST_PC_ID, false, false); }
        public void SYNC() { CallFlowFunction(FlowFunction.SYNC, false, false); }
        public void WAIT(int param1) { CallFlowFunction(FlowFunction.WAIT, false, false, param1); }
        public void PUT(int param1) { CallFlowFunction(FlowFunction.PUT, false, false, param1); }
        public void PUTS(string param1) { CallFlowFunction(FlowFunction.PUTS, false, false, param1); }
        public void PUTF(float param1) { CallFlowFunction(FlowFunction.PUTF, false, false, param1); }
        public void MSG(int param1, int param2) { CallFlowFunction(FlowFunction.MSG, false, false, param1, param2); }
        public void NULL() { CallFlowFunction(FlowFunction.NULL, false, false); }
        public void FADEIN(int param1, int param2) { CallFlowFunction(FlowFunction.FADEIN, false, false, param1, param2); }
        public void FADEOUT(int param1, int param2) { CallFlowFunction(FlowFunction.FADEOUT, false, false, param1, param2); }
        public void FADEEND_CHECK() { CallFlowFunction(FlowFunction.FADEEND_CHECK, false, false); }
        public void FADE_SYNC() { CallFlowFunction(FlowFunction.FADE_SYNC, false, false); }
        public void FADE_COLOR(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FADE_COLOR, false, false, param1, param2, param3); }
        public int BIT_CHK(int param1) { return CallFlowFunction(FlowFunction.BIT_CHK, false, false, param1); }
        public void BIT_ON(int param1) { CallFlowFunction(FlowFunction.BIT_ON, false, false, param1); }
        public void BIT_OFF(int param1) { CallFlowFunction(FlowFunction.BIT_OFF, false, false, param1); }
        public int GET_COUNT(int param1) { return CallFlowFunction(FlowFunction.GET_COUNT, false, false, param1); }
        public void SET_COUNT(int param1, int param2) { CallFlowFunction(FlowFunction.SET_COUNT, false, false, param1, param2); }
        public int RND(int param1) { return CallFlowFunction(FlowFunction.RND, false, false, param1); }
        public void LIFESIM_SET_IMAGE(int param1, int param2) { CallFlowFunction(FlowFunction.LIFESIM_SET_IMAGE, false, false, param1, param2); }
        public void MDL_VISIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.MDL_VISIBLE, false, false, param1, param2); }
        public void LIFESIM_SHOW_BUSTUP(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.LIFESIM_SHOW_BUSTUP, false, false, param1, param2, param3, param4); }
        public void LIFESIM_HIDE_BUSTUP(int param1) { CallFlowFunction(FlowFunction.LIFESIM_HIDE_BUSTUP, false, false, param1); }
        public void LIFESIM_MOUSEANIM_ENABLE(int param1, int param2) { CallFlowFunction(FlowFunction.LIFESIM_MOUSEANIM_ENABLE, false, false, param1, param2); }
        public void MDL_ANIM(int param1, int param2, int param3, int param4, float param5) { CallFlowFunction(FlowFunction.MDL_ANIM, false, false, param1, param2, param3, param4, param5); }
        public void MDL_ANIM_SYNC(int param1) { CallFlowFunction(FlowFunction.MDL_ANIM_SYNC, false, false, param1); }
        public void CALL_CALENDAR() { CallFlowFunction(FlowFunction.CALL_CALENDAR, false, false); }
        public void SET_NEXT_DAY(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.SET_NEXT_DAY, false, false, param1, param2, param3); }
        public int GET_DAY() { return CallFlowFunction(FlowFunction.GET_DAY, false, false); }
        public int GET_TIME() { return CallFlowFunction(FlowFunction.GET_TIME, false, false); }
        public int CHK_DAYS(int param1, int param2) { return CallFlowFunction(FlowFunction.CHK_DAYS, false, false, param1, param2); }
        public int GET_DAYOFWEEK() { return CallFlowFunction(FlowFunction.GET_DAYOFWEEK, false, false); }
        public void SCENE_CHANGE_WAIT() { CallFlowFunction(FlowFunction.SCENE_CHANGE_WAIT, false, false); }
        public void MOVIE_PLAY(int param1) { CallFlowFunction(FlowFunction.MOVIE_PLAY, false, false, param1); }
        public void MOVIE_SYNC() { CallFlowFunction(FlowFunction.MOVIE_SYNC, false, false); }
        public void MSG_WND_DSP() { CallFlowFunction(FlowFunction.MSG_WND_DSP, false, false); }
        public void MSG_WND_CLS() { CallFlowFunction(FlowFunction.MSG_WND_CLS, false, false); }
        public int SEL(int param1) { return CallFlowFunction(FlowFunction.SEL, false, false, param1); }
        public void SEL_WND_DSP() { CallFlowFunction(FlowFunction.SEL_WND_DSP, false, false); }
        public void SEL_WND_CLS() { CallFlowFunction(FlowFunction.SEL_WND_CLS, false, false); }
        public void SET_MSG_VAR(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.SET_MSG_VAR, false, false, param1, param2, param3); }
        public void SEL_DEFKEY(int param1, int param2) { CallFlowFunction(FlowFunction.SEL_DEFKEY, false, false, param1, param2); }
        public void SEL_MASK(int param1) { CallFlowFunction(FlowFunction.SEL_MASK, false, false, param1); }
        public void MSG_SYSTEM(int param1) { CallFlowFunction(FlowFunction.MSG_SYSTEM, false, false, param1); }
        public int CAMERA_READ(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.CAMERA_READ, false, false, param1, param2, param3); }
        public void CAMERA_READ_SYNC(int param1) { CallFlowFunction(FlowFunction.CAMERA_READ_SYNC, false, false, param1); }
        public void CAMERA_FREE(int param1) { CallFlowFunction(FlowFunction.CAMERA_FREE, false, false, param1); }
        public void CAMERA_SET(int param1) { CallFlowFunction(FlowFunction.CAMERA_SET, false, false, param1); }
        public void CAMERA_RESET() { CallFlowFunction(FlowFunction.CAMERA_RESET, false, false); }
        public void CAMERA_ANIM(int param1, int param2, int param3, int param4, float param5) { CallFlowFunction(FlowFunction.CAMERA_ANIM, false, false, param1, param2, param3, param4, param5); }
        public void CAMERA_ANIM_SYNC(int param1) { CallFlowFunction(FlowFunction.CAMERA_ANIM_SYNC, false, false, param1); }
        public void MDL_ANIM_SEEK(int param1, float param2) { CallFlowFunction(FlowFunction.MDL_ANIM_SEEK, false, false, param1, param2); }
        public void MDL_ANIM_FRAMESYNC(int param1, float param2) { CallFlowFunction(FlowFunction.MDL_ANIM_FRAMESYNC, false, false, param1, param2); }
        public void MDL_SET_SCALE(int param1, float param2) { CallFlowFunction(FlowFunction.MDL_SET_SCALE, false, false, param1, param2); }
        public int ADD_PC_MONEY(int param1) { return CallFlowFunction(FlowFunction.ADD_PC_MONEY, false, false, param1); }
        public int GET_SMN_LEVEL(int param1) { return CallFlowFunction(FlowFunction.GET_SMN_LEVEL, false, false, param1); }
        public int GET_HP(int param1) { return CallFlowFunction(FlowFunction.GET_HP, false, false, param1); }
        public int GET_MAXHP(int param1) { return CallFlowFunction(FlowFunction.GET_MAXHP, false, false, param1); }
        public void SET_HP(int param1, int param2) { CallFlowFunction(FlowFunction.SET_HP, false, false, param1, param2); }
        public int GET_SP(int param1) { return CallFlowFunction(FlowFunction.GET_SP, false, false, param1); }
        public int GET_MAXSP(int param1) { return CallFlowFunction(FlowFunction.GET_MAXSP, false, false, param1); }
        public void SET_SP(int param1, int param2) { CallFlowFunction(FlowFunction.SET_SP, false, false, param1, param2); }
        public int GET_ITEM_NUM(int param1) { return CallFlowFunction(FlowFunction.GET_ITEM_NUM, false, false, param1); }
        public void SET_ITEM_NUM(int param1, int param2) { CallFlowFunction(FlowFunction.SET_ITEM_NUM, false, false, param1, param2); }
        public int GET_EQUIP(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_EQUIP, false, false, param1, param2); }
        public void SET_EQUIP(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.SET_EQUIP, false, false, param1, param2, param3); }
        public void PARTY_IN(int param1) { CallFlowFunction(FlowFunction.PARTY_IN, false, false, param1); }
        public void PARTY_OUT(int param1) { CallFlowFunction(FlowFunction.PARTY_OUT, false, false, param1); }
        public int GET_PARTY(int param1) { return CallFlowFunction(FlowFunction.GET_PARTY, false, false, param1); }
        public void RECOVERY_ALL() { CallFlowFunction(FlowFunction.RECOVERY_ALL, false, false); }
        public int GET_AND(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_AND, false, false, param1, param2); }
        public int GET_OR(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_OR, false, false, param1, param2); }
        public int GET_XOR(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_XOR, false, false, param1, param2); }
        public int GET_L_SHIFT(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_L_SHIFT, false, false, param1, param2); }
        public int GET_R_SHIFT(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_R_SHIFT, false, false, param1, param2); }
        public int REM(int param1, int param2) { return CallFlowFunction(FlowFunction.REM, false, false, param1, param2); }
        public int SCRIPT_READ(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.SCRIPT_READ, true, false, param1, param2, param3); }
        public void SCRIPT_READ_SYNC(int param1) { CallFlowFunction(FlowFunction.SCRIPT_READ_SYNC, false, true, param1); }
        public void SCRIPT_FREE(int param1) { CallFlowFunction(FlowFunction.SCRIPT_FREE, false, true, param1); }
        public void SCRIPT_EXEC(int param1, int param2) { CallFlowFunction(FlowFunction.SCRIPT_EXEC, false, true, param1, param2); }
        public int SCRIPT_SEARCH(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.SCRIPT_SEARCH, false, false, param1, param2, param3); }
        public void CAMERA_SET_HELPERPOS(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.CAMERA_SET_HELPERPOS, false, false, param1, param2, param3); }
        public void RUMBLE_START_L(int param1, int param2, int param3, int param4, int param5) { CallFlowFunction(FlowFunction.RUMBLE_START_L, false, false, param1, param2, param3, param4, param5); }
        public void RUMBLE_STOP_L() { CallFlowFunction(FlowFunction.RUMBLE_STOP_L, false, false); }
        public void RUMBLE_START_S(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.RUMBLE_START_S, false, false, param1, param2, param3, param4); }
        public void RUMBLE_STOP_S() { CallFlowFunction(FlowFunction.RUMBLE_STOP_S, false, false); }
        public void RUMBLE_STOP() { CallFlowFunction(FlowFunction.RUMBLE_STOP, false, false); }
        public void RUMBLE_CHECK() { CallFlowFunction(FlowFunction.RUMBLE_CHECK, false, false); }
        public int CHK_DAYS_STARTEND(int param1, int param2, int param3, int param4) { return CallFlowFunction(FlowFunction.CHK_DAYS_STARTEND, false, false, param1, param2, param3, param4); }
        public void SAVE() { CallFlowFunction(FlowFunction.SAVE, false, false); }
        public int SAVE_SYNC() { return CallFlowFunction(FlowFunction.SAVE_SYNC, false, false); }
        public void SAVE_MENU() { CallFlowFunction(FlowFunction.SAVE_MENU, false, false); }
        public void SAVE_MENU_SYNC() { CallFlowFunction(FlowFunction.SAVE_MENU_SYNC, false, false); }
        public void BGM(int param1) { CallFlowFunction(FlowFunction.BGM, false, false, param1); }
        public void PAD_TRIG(int param1) { CallFlowFunction(FlowFunction.PAD_TRIG, false, false, param1); }
        public void PAD_PRESS(int param1) { CallFlowFunction(FlowFunction.PAD_PRESS, false, false, param1); }
        public int MSG_SELECT(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.MSG_SELECT, false, false, param1, param2, param3); }
        public void MSG_TUTORIAL(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.MSG_TUTORIAL, false, false, param1, param2, param3); }
        public void DATE_DISP(int param1) { CallFlowFunction(FlowFunction.DATE_DISP, false, false, param1); }
        public void BGM_STOP(int param1) { CallFlowFunction(FlowFunction.BGM_STOP, false, false, param1); }
        public void SET_DBG_DAY(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.SET_DBG_DAY, false, false, param1, param2, param3); }
        public void MDL_ANIM_SPEED(int param1, float param2) { CallFlowFunction(FlowFunction.MDL_ANIM_SPEED, false, false, param1, param2); }
        public void MDL_ANIM_NEXT(int param1, int param2, int param3, int param4, float param5) { CallFlowFunction(FlowFunction.MDL_ANIM_NEXT, false, false, param1, param2, param3, param4, param5); }
        public int MDL_ICON(int param1, int param2) { return CallFlowFunction(FlowFunction.MDL_ICON, false, false, param1, param2); }
        public int GET_PC_PARAM(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_PC_PARAM, false, false, param1, param2); }
        public int GET_PC_PARAM_LV(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_PC_PARAM_LV, false, false, param1, param2); }
        public void DBG_SET_PC_PARAM(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.DBG_SET_PC_PARAM, false, false, param1, param2, param3); }
        public void UPDATE_ENQUETE() { CallFlowFunction(FlowFunction.UPDATE_ENQUETE, false, false); }
        public void DBG_PUT(int param1) { CallFlowFunction(FlowFunction.DBG_PUT, false, false, param1); }
        public void ADD_PC_PARAM_SYNC() { CallFlowFunction(FlowFunction.ADD_PC_PARAM_SYNC, false, false); }
        public void SET_SUSPICION() { CallFlowFunction(FlowFunction.SET_SUSPICION, false, false); }
        public void ADD_SUSPICION_START() { CallFlowFunction(FlowFunction.ADD_SUSPICION_START, false, false); }
        public void ADD_SUSPICION_SYNC() { CallFlowFunction(FlowFunction.ADD_SUSPICION_SYNC, false, false); }
        public void GET_SUSPICION() { CallFlowFunction(FlowFunction.GET_SUSPICION, false, false); }
        public void GET_SUSPICION_LV() { CallFlowFunction(FlowFunction.GET_SUSPICION_LV, false, false); }
        public void DBG_SCRIPT_MENU(int param1) { CallFlowFunction(FlowFunction.DBG_SCRIPT_MENU, false, false, param1); }
        public int GET_TOTAL_DAY() { return CallFlowFunction(FlowFunction.GET_TOTAL_DAY, false, false); }
        public int GET_MONTH() { return CallFlowFunction(FlowFunction.GET_MONTH, false, false); }
        public int GET_WEATHER() { return CallFlowFunction(FlowFunction.GET_WEATHER, false, false); }
        public int GET_MOON_AGE() { return CallFlowFunction(FlowFunction.GET_MOON_AGE, false, false); }
        public void ADD_SUSPICION() { CallFlowFunction(FlowFunction.ADD_SUSPICION, false, false); }
        public void DISP_CAUTION() { CallFlowFunction(FlowFunction.DISP_CAUTION, false, false); }
        public int PAD_CHK_TRIG(int param1) { return CallFlowFunction(FlowFunction.PAD_CHK_TRIG, false, false, param1); }
        public int PAD_CHK_PRESS(int param1) { return CallFlowFunction(FlowFunction.PAD_CHK_PRESS, false, false, param1); }
        public void EVERY_MORNING_NETWORK() { CallFlowFunction(FlowFunction.EVERY_MORNING_NETWORK, false, false); }
        public void ZEAL_TEX_READ(int param1, int param2) { CallFlowFunction(FlowFunction.ZEAL_TEX_READ, false, false, param1, param2); }
        public void ZEAL_TEX_SYNC(int param1) { CallFlowFunction(FlowFunction.ZEAL_TEX_SYNC, false, false, param1); }
        public void ZEAL_TEX_DISP(int param1, int param2) { CallFlowFunction(FlowFunction.ZEAL_TEX_DISP, false, false, param1, param2); }
        public void ZEAL_TEX_FREE(int param1, int param2) { CallFlowFunction(FlowFunction.ZEAL_TEX_FREE, false, false, param1, param2); }
        public void BGENV_SE_PLAY(int param1) { CallFlowFunction(FlowFunction.BGENV_SE_PLAY, false, false, param1); }
        public void BGENV_SE_FADEOUT(int param1, int param2) { CallFlowFunction(FlowFunction.BGENV_SE_FADEOUT, false, false, param1, param2); }
        public void BGENV_SE_STOP(int param1) { CallFlowFunction(FlowFunction.BGENV_SE_STOP, false, false, param1); }
        public int BGENV_SE_CHECK(int param1) { return CallFlowFunction(FlowFunction.BGENV_SE_CHECK, false, false, param1); }
        public void MESSAGE_REF(int param1, int param2) { CallFlowFunction(FlowFunction.MESSAGE_REF, false, false, param1, param2); }
        public void MSG_CAPTION(int param1) { CallFlowFunction(FlowFunction.MSG_CAPTION, false, false, param1); }
        public void MSG_MIND(int param1, int param2) { CallFlowFunction(FlowFunction.MSG_MIND, false, false, param1, param2); }
        public void SET_SUSPICION_LV() { CallFlowFunction(FlowFunction.SET_SUSPICION_LV, false, false); }
        public void COMSE_PLAY(int param1) { CallFlowFunction(FlowFunction.COMSE_PLAY, false, false, param1); }
        public void COMSE_STOP(int param1) { CallFlowFunction(FlowFunction.COMSE_STOP, false, false, param1); }
        public void LOGICTREE_OPEN(int param1) { CallFlowFunction(FlowFunction.LOGICTREE_OPEN, false, false, param1); }
        public void LOGICTREE_OPEN_SYNC() { CallFlowFunction(FlowFunction.LOGICTREE_OPEN_SYNC, false, false); }
        public void LOGICTREE_CLOSE() { CallFlowFunction(FlowFunction.LOGICTREE_CLOSE, false, false); }
        public void LOGICTREE_CLOSE_SYNC() { CallFlowFunction(FlowFunction.LOGICTREE_CLOSE_SYNC, false, false); }
        public void LOGICTREE_SET_BRANCH(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.LOGICTREE_SET_BRANCH, false, false, param1, param2, param3); }
        public void LOGICTREE_RESET_BRANCH(int param1) { CallFlowFunction(FlowFunction.LOGICTREE_RESET_BRANCH, false, false, param1); }
        public void LOGICTREE_CLEAR_BRANCH() { CallFlowFunction(FlowFunction.LOGICTREE_CLEAR_BRANCH, false, false); }
        public int MDL_GET_ANIM(int param1) { return CallFlowFunction(FlowFunction.MDL_GET_ANIM, false, false, param1); }
        public void CHAT_WND_DSP() { CallFlowFunction(FlowFunction.CHAT_WND_DSP, false, false); }
        public void CHAT_WND_CLS() { CallFlowFunction(FlowFunction.CHAT_WND_CLS, false, false); }
        public void MSG_TREE_SET_ROOT(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.MSG_TREE_SET_ROOT, false, false, param1, param2, param3); }
        public void MSG_TREE_SET_NODE(int param1, int param2, int param3, int param4, int param5, int param6, int param7) { CallFlowFunction(FlowFunction.MSG_TREE_SET_NODE, false, false, param1, param2, param3, param4, param5, param6, param7); }
        public void MSG_TREE_OPEN() { CallFlowFunction(FlowFunction.MSG_TREE_OPEN, false, false); }
        public int MSG_TREE_GET_MISS_COUNT() { return CallFlowFunction(FlowFunction.MSG_TREE_GET_MISS_COUNT, false, false); }
        public void CAMERA_QUAKE_START(float param1, float param2, float param3, float param4, float param5) { CallFlowFunction(FlowFunction.CAMERA_QUAKE_START, false, false, param1, param2, param3, param4, param5); }
        public void CAMERA_QUAKE_STOP(float param1) { CallFlowFunction(FlowFunction.CAMERA_QUAKE_STOP, false, false, param1); }
        public void MDL_ANIM_BLENDSYNC(int param1) { CallFlowFunction(FlowFunction.MDL_ANIM_BLENDSYNC, false, false, param1); }
        public void TIMER_SETUP() { CallFlowFunction(FlowFunction.TIMER_SETUP, false, false); }
        public void TIMER_SETUP_SYNC() { CallFlowFunction(FlowFunction.TIMER_SETUP_SYNC, false, false); }
        public void TIMER_DESTROY() { CallFlowFunction(FlowFunction.TIMER_DESTROY, false, false); }
        public void TIMER_SET_VISIBLE(int param1) { CallFlowFunction(FlowFunction.TIMER_SET_VISIBLE, false, false, param1); }
        public int TIMER_GET_VISIBLE() { return CallFlowFunction(FlowFunction.TIMER_GET_VISIBLE, false, false); }
        public void TIMER_SET_PAUSE(int param1) { CallFlowFunction(FlowFunction.TIMER_SET_PAUSE, false, false, param1); }
        public int TIMER_GET_PAUSE() { return CallFlowFunction(FlowFunction.TIMER_GET_PAUSE, false, false); }
        public void TIMER_SET_TIME(int param1) { CallFlowFunction(FlowFunction.TIMER_SET_TIME, false, false, param1); }
        public void TIMER_ADD_TIME(int param1) { CallFlowFunction(FlowFunction.TIMER_ADD_TIME, false, false, param1); }
        public int TIMER_GET_TIME() { return CallFlowFunction(FlowFunction.TIMER_GET_TIME, false, false); }
        public int MDL_GET_ITEM_RESHND(int param1, int param2) { return CallFlowFunction(FlowFunction.MDL_GET_ITEM_RESHND, false, false, param1, param2); }
        public void MDL_ADD_ANIM(int param1, int param2, int param3, int param4, float param5) { CallFlowFunction(FlowFunction.MDL_ADD_ANIM, false, false, param1, param2, param3, param4, param5); }
        public void MDL_ADD_ANIM_NEXT(int param1, int param2, int param3, int param4, float param5) { CallFlowFunction(FlowFunction.MDL_ADD_ANIM_NEXT, false, false, param1, param2, param3, param4, param5); }
        public void MDL_ADD_SYNC(int param1, int param2) { CallFlowFunction(FlowFunction.MDL_ADD_SYNC, false, false, param1, param2); }
        public int SEL_TIME_LIMIT(int param1, float param2) { return CallFlowFunction(FlowFunction.SEL_TIME_LIMIT, false, false, param1, param2); }
        public int MDL_GET_ANIM_COUNT(int param1) { return CallFlowFunction(FlowFunction.MDL_GET_ANIM_COUNT, false, false, param1); }
        public void MSG_WND_SET_POS(float param1, float param2, float param3) { CallFlowFunction(FlowFunction.MSG_WND_SET_POS, false, false, param1, param2, param3); }
        public void MSG_WND_RESET_POS() { CallFlowFunction(FlowFunction.MSG_WND_RESET_POS, false, false); }
        public void CAMERA_SHAKE_START(int param1, int param2, float param3) { CallFlowFunction(FlowFunction.CAMERA_SHAKE_START, false, false, param1, param2, param3); }
        public void CAMERA_SHAKE_PAUSE() { CallFlowFunction(FlowFunction.CAMERA_SHAKE_PAUSE, false, false); }
        public void CAMERA_SHAKE_STOP() { CallFlowFunction(FlowFunction.CAMERA_SHAKE_STOP, false, false); }
        public void CAMERA_SHAKE_SCALE(float param1) { CallFlowFunction(FlowFunction.CAMERA_SHAKE_SCALE, false, false, param1); }
        public void CAMERA_SHAKE_SPEED(float param1) { CallFlowFunction(FlowFunction.CAMERA_SHAKE_SPEED, false, false, param1); }
        public int ANALOG_ASTICK_CHECK(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.ANALOG_ASTICK_CHECK, false, false, param1, param2, param3); }
        public void MDL_TRACK_ADD_ANIM(int param1, int param2, int param3, int param4, int param5, float param6) { CallFlowFunction(FlowFunction.MDL_TRACK_ADD_ANIM, false, false, param1, param2, param3, param4, param5, param6); }
        public void MDL_TRACK_ADD_ANIM_NEXT(int param1, int param2, int param3, int param4, int param5, float param6) { CallFlowFunction(FlowFunction.MDL_TRACK_ADD_ANIM_NEXT, false, false, param1, param2, param3, param4, param5, param6); }
        public void MDL_TRACK_ADD_ANIM_SYNC(int param1, int param2) { CallFlowFunction(FlowFunction.MDL_TRACK_ADD_ANIM_SYNC, false, false, param1, param2); }
        public float SIN(float param1) { return CallFloatFlowFunction(FlowFunction.SIN, false, false, param1); }
        public float COS(float param1) { return CallFloatFlowFunction(FlowFunction.COS, false, false, param1); }
        public float TAN(float param1) { return CallFloatFlowFunction(FlowFunction.TAN, false, false, param1); }
        public float ASIN(float param1) { return CallFloatFlowFunction(FlowFunction.ASIN, false, false, param1); }
        public float ACOS(float param1) { return CallFloatFlowFunction(FlowFunction.ACOS, false, false, param1); }
        public float ATAN(float param1) { return CallFloatFlowFunction(FlowFunction.ATAN, false, false, param1); }
        public float ATAN2(float param1, float param2) { return CallFloatFlowFunction(FlowFunction.ATAN2, false, false, param1, param2); }
        public float SQRT(float param1) { return CallFloatFlowFunction(FlowFunction.SQRT, false, false, param1); }
        public void PUSH_UNIFORM(int param1, int param2) { CallFlowFunction(FlowFunction.PUSH_UNIFORM, false, false, param1, param2); }
        public void POP_UNIFORM(int param1) { CallFlowFunction(FlowFunction.POP_UNIFORM, false, false, param1); }
        public void CLEAR_UNIFORM() { CallFlowFunction(FlowFunction.CLEAR_UNIFORM, false, false); }
        public void PUSH_WEATHER(int param1) { CallFlowFunction(FlowFunction.PUSH_WEATHER, false, false, param1); }
        public void POP_WEATHER() { CallFlowFunction(FlowFunction.POP_WEATHER, false, false); }
        public void CLEAR_WEATHER() { CallFlowFunction(FlowFunction.CLEAR_WEATHER, false, false); }
        public void BGENV_SE_PLAY_CUEID(int param1) { CallFlowFunction(FlowFunction.BGENV_SE_PLAY_CUEID, false, false, param1); }
        public void BGENV_SE_FADEOUT_CUEID(int param1, int param2) { CallFlowFunction(FlowFunction.BGENV_SE_FADEOUT_CUEID, false, false, param1, param2); }
        public void BGENV_SE_STOP_CUEID(int param1) { CallFlowFunction(FlowFunction.BGENV_SE_STOP_CUEID, false, false, param1); }
        public int BGENV_SE_CHECK_CUEID(int param1) { return CallFlowFunction(FlowFunction.BGENV_SE_CHECK_CUEID, false, false, param1); }
        public void SKILL_ADD(int param1, int param2) { CallFlowFunction(FlowFunction.SKILL_ADD, false, false, param1, param2); }
        public void SKILL_ADD_CMM(int param1, int param2) { CallFlowFunction(FlowFunction.SKILL_ADD_CMM, false, false, param1, param2); }
        public int FRIEND_SKILL_ADD(int param1, int param2) { return CallFlowFunction(FlowFunction.FRIEND_SKILL_ADD, false, false, param1, param2); }
        public int CHK_FRIEND_SKILL_ADD(int param1, int param2) { return CallFlowFunction(FlowFunction.CHK_FRIEND_SKILL_ADD, false, false, param1, param2); }
        public int NEXT_SKILL_ADD(int param1) { return CallFlowFunction(FlowFunction.NEXT_SKILL_ADD, false, false, param1); }
        public int CHK_NEXT_SKILL_ADD() { return CallFlowFunction(FlowFunction.CHK_NEXT_SKILL_ADD, false, false); }
        public void TEST_TEX_READ(int param1, int param2) { CallFlowFunction(FlowFunction.TEST_TEX_READ, false, false, param1, param2); }
        public void TEST_TEX_SYNC(int param1) { CallFlowFunction(FlowFunction.TEST_TEX_SYNC, false, false, param1); }
        public void TEST_TEX_DISP(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.TEST_TEX_DISP, false, false, param1, param2, param3, param4); }
        public void TEST_TEX_FREE(int param1, int param2) { CallFlowFunction(FlowFunction.TEST_TEX_FREE, false, false, param1, param2); }
        public int GET_MONTH_TOTAL_DAY(int param1) { return CallFlowFunction(FlowFunction.GET_MONTH_TOTAL_DAY, false, false, param1); }
        public int GET_DAY_TOTAL_DAY(int param1) { return CallFlowFunction(FlowFunction.GET_DAY_TOTAL_DAY, false, false, param1); }
        public void BIT_SYNC(int param1) { CallFlowFunction(FlowFunction.BIT_SYNC, false, false, param1); }
        public int GET_WEATHER_DETAIL() { return CallFlowFunction(FlowFunction.GET_WEATHER_DETAIL, false, false); }
        public void SET_HUMAN_LV(int param1, int param2) { CallFlowFunction(FlowFunction.SET_HUMAN_LV, false, false, param1, param2); }
        public void SET_PERSONA_LV(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.SET_PERSONA_LV, false, false, param1, param2, param3); }
        public void CLEAR_PERSONA_STOCK() { CallFlowFunction(FlowFunction.CLEAR_PERSONA_STOCK, false, false); }
        public void ADD_PERSONA_STOCK(int param1) { CallFlowFunction(FlowFunction.ADD_PERSONA_STOCK, false, false, param1); }
        public void ADD_PC_ALL_PARAM(int param1, int param2, int param3, int param4, int param5) { CallFlowFunction(FlowFunction.ADD_PC_ALL_PARAM, false, false, param1, param2, param3, param4, param5); }
        public void SKILL_ADD_ARSENE(int param1) { CallFlowFunction(FlowFunction.SKILL_ADD_ARSENE, false, false, param1); }
        public int MDL_GET_MAJOR_ID(int param1) { return CallFlowFunction(FlowFunction.MDL_GET_MAJOR_ID, false, false, param1); }
        public int MDL_GET_MINOR_ID(int param1) { return CallFlowFunction(FlowFunction.MDL_GET_MINOR_ID, false, false, param1); }
        public int MDL_GET_SUB_ID(int param1) { return CallFlowFunction(FlowFunction.MDL_GET_SUB_ID, false, false, param1); }
        public void ADD_MAIN_PERSONA_PARAM(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.ADD_MAIN_PERSONA_PARAM, false, false, param1, param2, param3); }
        public int GET_MAIN_PERSONA_PARAM(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_MAIN_PERSONA_PARAM, false, false, param1, param2); }
        public void ADD_EQUIP_PERSONA_PARAM(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.ADD_EQUIP_PERSONA_PARAM, false, false, param1, param2, param3); }
        public void ADD_EQUIP_PERSONA_PARAM_INC(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.ADD_EQUIP_PERSONA_PARAM_INC, false, false, param1, param2, param3); }
        public int GET_EQUIP_PERSONA_PARAM(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_EQUIP_PERSONA_PARAM, false, false, param1, param2); }
        public void KTAI_MENU_START() { CallFlowFunction(FlowFunction.KTAI_MENU_START, false, false); }
        public void KTAI_MENU_VISIBLE(int param1) { CallFlowFunction(FlowFunction.KTAI_MENU_VISIBLE, false, false, param1); }
        public void KTAI_MENU_FADE(int param1) { CallFlowFunction(FlowFunction.KTAI_MENU_FADE, false, false, param1); }
        public void KTAI_MENU_FADE_SYNC() { CallFlowFunction(FlowFunction.KTAI_MENU_FADE_SYNC, false, false); }
        public int KTAI_MENU_GET_PAD() { return CallFlowFunction(FlowFunction.KTAI_MENU_GET_PAD, false, false); }
        public void KTAI_MENU_EXIT() { CallFlowFunction(FlowFunction.KTAI_MENU_EXIT, false, false); }
        public void DBG_PUTS(string param1) { CallFlowFunction(FlowFunction.DBG_PUTS, false, false, param1); }
        public float GET_MAX(float param1, float param2) { return CallFloatFlowFunction(FlowFunction.GET_MAX, false, false, param1, param2); }
        public float GET_MIN(float param1, float param2) { return CallFloatFlowFunction(FlowFunction.GET_MIN, false, false, param1, param2); }
        public void ADD_PERSONA_SKILL(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.ADD_PERSONA_SKILL, false, false, param1, param2, param3); }
        public void REMOVE_PERSONA_SKILL(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.REMOVE_PERSONA_SKILL, false, false, param1, param2, param3); }
        public void BGENV_SE_PLAY_CUEID_ALL(int param1) { CallFlowFunction(FlowFunction.BGENV_SE_PLAY_CUEID_ALL, false, false, param1); }
        public void BGENV_SE_FADEOUT_CUEID_ALL(int param1, int param2) { CallFlowFunction(FlowFunction.BGENV_SE_FADEOUT_CUEID_ALL, false, false, param1, param2); }
        public void BGENV_SE_STOP_CUEID_ALL(int param1) { CallFlowFunction(FlowFunction.BGENV_SE_STOP_CUEID_ALL, false, false, param1); }
        public void SND_VOICE_FACILITY_SETUP(int param1) { CallFlowFunction(FlowFunction.SND_VOICE_FACILITY_SETUP, false, false, param1); }
        public void SND_VOICE_FACILITY_SYNC() { CallFlowFunction(FlowFunction.SND_VOICE_FACILITY_SYNC, false, false); }
        public void BGENV_LINK_BGOBJ(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.BGENV_LINK_BGOBJ, false, false, param1, param2, param3); }
        public void BGENV_UNLINK_BGOBJ(int param1) { CallFlowFunction(FlowFunction.BGENV_UNLINK_BGOBJ, false, false, param1); }
        public int NPC_BIT_CHK(int param1) { return CallFlowFunction(FlowFunction.NPC_BIT_CHK, false, false, param1); }
        public void NPC_BIT_ON(int param1) { CallFlowFunction(FlowFunction.NPC_BIT_ON, false, false, param1); }
        public void NPC_BIT_OFF(int param1) { CallFlowFunction(FlowFunction.NPC_BIT_OFF, false, false, param1); }
        public void ADD_MAXHP_UP(int param1, int param2) { CallFlowFunction(FlowFunction.ADD_MAXHP_UP, false, false, param1, param2); }
        public int GET_MAXHP_UP(int param1) { return CallFlowFunction(FlowFunction.GET_MAXHP_UP, false, false, param1); }
        public void ADD_MAXSP_UP(int param1, int param2) { CallFlowFunction(FlowFunction.ADD_MAXSP_UP, false, false, param1, param2); }
        public int GET_MAXSP_UP(int param1) { return CallFlowFunction(FlowFunction.GET_MAXSP_UP, false, false, param1); }
        public void BGENV_LINE_SE_PLAY(int param1) { CallFlowFunction(FlowFunction.BGENV_LINE_SE_PLAY, false, false, param1); }
        public void BGENV_LINE_SE_FADEOUT(int param1, int param2) { CallFlowFunction(FlowFunction.BGENV_LINE_SE_FADEOUT, false, false, param1, param2); }
        public void BGENV_LINE_SE_STOP(int param1) { CallFlowFunction(FlowFunction.BGENV_LINE_SE_STOP, false, false, param1); }
        public int BGENV_LINE_SE_CHECK(int param1) { return CallFlowFunction(FlowFunction.BGENV_LINE_SE_CHECK, false, false, param1); }
        public void BGENV_DEF_SE_PLAY(int param1) { CallFlowFunction(FlowFunction.BGENV_DEF_SE_PLAY, false, false, param1); }
        public void BGENV_DEF_SE_FADEOUT(int param1, int param2) { CallFlowFunction(FlowFunction.BGENV_DEF_SE_FADEOUT, false, false, param1, param2); }
        public void BGENV_DEF_SE_STOP(int param1) { CallFlowFunction(FlowFunction.BGENV_DEF_SE_STOP, false, false, param1); }
        public int BGENV_DEF_SE_CHECK(int param1) { return CallFlowFunction(FlowFunction.BGENV_DEF_SE_CHECK, false, false, param1); }
        public int NPC_EXIST_VALUE(int param1) { return CallFlowFunction(FlowFunction.NPC_EXIST_VALUE, false, false, param1); }
        public int NPC_EXIST_VALUE_MD(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.NPC_EXIST_VALUE_MD, false, false, param1, param2, param3); }
        public int NPC_QUEST_GET_NUM() { return CallFlowFunction(FlowFunction.NPC_QUEST_GET_NUM, false, false); }
        public int NPC_QUEST_GET_ID(int param1) { return CallFlowFunction(FlowFunction.NPC_QUEST_GET_ID, false, false, param1); }
        public int SEL_GENERIC(int param1, int param2) { return CallFlowFunction(FlowFunction.SEL_GENERIC, false, false, param1, param2); }
        public void GET_DBG_NUM() { CallFlowFunction(FlowFunction.GET_DBG_NUM, false, false); }
        public void NPC_QUEST_START(int param1) { CallFlowFunction(FlowFunction.NPC_QUEST_START, false, false, param1); }
        public void NPC_QUEST_END(int param1) { CallFlowFunction(FlowFunction.NPC_QUEST_END, false, false, param1); }
        public void NPC_QUEST_CLEAR() { CallFlowFunction(FlowFunction.NPC_QUEST_CLEAR, false, false); }
        public void COMENV_PLAY(int param1) { CallFlowFunction(FlowFunction.COMENV_PLAY, false, false, param1); }
        public void COMENV_STOP(int param1) { CallFlowFunction(FlowFunction.COMENV_STOP, false, false, param1); }
        public void VOICE1_PLAY(int param1) { CallFlowFunction(FlowFunction.VOICE1_PLAY, false, false, param1); }
        public void VOICE1_STOP(int param1) { CallFlowFunction(FlowFunction.VOICE1_STOP, false, false, param1); }
        public void VOICE2_PLAY(int param1) { CallFlowFunction(FlowFunction.VOICE2_PLAY, false, false, param1); }
        public void VOICE2_STOP(int param1) { CallFlowFunction(FlowFunction.VOICE2_STOP, false, false, param1); }
        public void VOICE3_PLAY(int param1) { CallFlowFunction(FlowFunction.VOICE3_PLAY, false, false, param1); }
        public void VOICE3_STOP(int param1) { CallFlowFunction(FlowFunction.VOICE3_STOP, false, false, param1); }
        public int TBL_365_VALUE(int param1) { return CallFlowFunction(FlowFunction.TBL_365_VALUE, false, false, param1); }
        public int TBL_365_VALUE_MD(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.TBL_365_VALUE_MD, false, false, param1, param2, param3); }
        public void NEXT_TIME() { CallFlowFunction(FlowFunction.NEXT_TIME, false, false); }
        public void MDL_SET_LOOKAT(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.MDL_SET_LOOKAT, false, false, param1, param2, param3); }
        public void MDL_RESET_LOOKAT(int param1, int param2) { CallFlowFunction(FlowFunction.MDL_RESET_LOOKAT, false, false, param1, param2); }
        public int CHK_PERSONA_EXIST(int param1, int param2) { return CallFlowFunction(FlowFunction.CHK_PERSONA_EXIST, false, false, param1, param2); }
        public int GET_DAY_WEATHER(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_DAY_WEATHER, false, false, param1, param2); }
        public int GET_DAY_WEATHER_DETAIL(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_DAY_WEATHER_DETAIL, false, false, param1, param2); }
        public int CHK_EXIST_WEATHER(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.CHK_EXIST_WEATHER, false, false, param1, param2, param3); }
        public int CHK_EXIST_WEATHER_DETAIL(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.CHK_EXIST_WEATHER_DETAIL, false, false, param1, param2, param3); }
        public void SEL_OPEN(int param1) { CallFlowFunction(FlowFunction.SEL_OPEN, false, false, param1); }
        public void MDL_ANIM_NO_SE(int param1, int param2, int param3, int param4, float param5) { CallFlowFunction(FlowFunction.MDL_ANIM_NO_SE, false, false, param1, param2, param3, param4, param5); }
        public void TROPHY_REQUEST(int param1, int param2) { CallFlowFunction(FlowFunction.TROPHY_REQUEST, false, false, param1, param2); }
        public void PERSONA_EVOLUTION(int param1) { CallFlowFunction(FlowFunction.PERSONA_EVOLUTION, false, false, param1); }
        public int GET_PC_PARAM_DIFFERENCE(int param1) { return CallFlowFunction(FlowFunction.GET_PC_PARAM_DIFFERENCE, false, false, param1); }
        public int SEL_GENERIC_NOT_CANCEL(int param1, int param2) { return CallFlowFunction(FlowFunction.SEL_GENERIC_NOT_CANCEL, false, false, param1, param2); }
        public void FOOTSTEP_SE_PLAYER_CREATE(int param1) { CallFlowFunction(FlowFunction.FOOTSTEP_SE_PLAYER_CREATE, false, false, param1); }
        public void FOOTSTEP_SE_ENABLE(int param1, int param2) { CallFlowFunction(FlowFunction.FOOTSTEP_SE_ENABLE, false, false, param1, param2); }
        public void FOOTSTEP_EFFECT_ENABLE(int param1, int param2) { CallFlowFunction(FlowFunction.FOOTSTEP_EFFECT_ENABLE, false, false, param1, param2); }
        public void FOOTSTEP_EFFECT2_ENABLE(int param1, int param2) { CallFlowFunction(FlowFunction.FOOTSTEP_EFFECT2_ENABLE, false, false, param1, param2); }
        public void FOOTSTEP_EFFECT_SCALE(int param1, float param2) { CallFlowFunction(FlowFunction.FOOTSTEP_EFFECT_SCALE, false, false, param1, param2); }
        public void BGTEX_STRIP_ENABLE(int param1) { CallFlowFunction(FlowFunction.BGTEX_STRIP_ENABLE, false, false, param1); }
        public void BGENV_LINK_BGOBJ_INDEX(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.BGENV_LINK_BGOBJ_INDEX, false, false, param1, param2, param3); }
        public void RESET_PC_PARAM_UP() { CallFlowFunction(FlowFunction.RESET_PC_PARAM_UP, false, false); }
        public void DISP_PC_PARAM_METER() { CallFlowFunction(FlowFunction.DISP_PC_PARAM_METER, false, false); }
        public int GET_HERO_WANTED_EXP(int param1) { return CallFlowFunction(FlowFunction.GET_HERO_WANTED_EXP, false, false, param1); }
        public void DISP_PC_PARAM_RANK_UP() { CallFlowFunction(FlowFunction.DISP_PC_PARAM_RANK_UP, false, false); }
        public void SAVE_UI_SYNC() { CallFlowFunction(FlowFunction.SAVE_UI_SYNC, false, false); }
        public int CHK_PC_PARAM_RANKUP(int param1) { return CallFlowFunction(FlowFunction.CHK_PC_PARAM_RANKUP, false, false, param1); }
        public void GET_ITEM_WINDOW(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.GET_ITEM_WINDOW, false, false, param1, param2, param3); }
        public void GET_MONEY_WINDOW(int param1, int param2) { CallFlowFunction(FlowFunction.GET_MONEY_WINDOW, false, false, param1, param2); }
        public void GET_PERSONA_WINDOW(int param1, int param2) { CallFlowFunction(FlowFunction.GET_PERSONA_WINDOW, false, false, param1, param2); }
        public void MSG_PERFORMANCE(int param1) { CallFlowFunction(FlowFunction.MSG_PERFORMANCE, false, false, param1); }
        public int CALL_STAMP_SAVE(int param1) { return CallFlowFunction(FlowFunction.CALL_STAMP_SAVE, false, false, param1); }
        public int CALL_CLEAR_SAVE() { return CallFlowFunction(FlowFunction.CALL_CLEAR_SAVE, false, false); }
        public void BULLET_RECOVERY(int param1) { CallFlowFunction(FlowFunction.BULLET_RECOVERY, false, false, param1); }
        public void BGENV_AISAC_FADEOUT(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.BGENV_AISAC_FADEOUT, false, false, param1, param2, param3); }
        public void BGENV_AISAC_FADEIN(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.BGENV_AISAC_FADEIN, false, false, param1, param2, param3); }
        public void BGENV_AISAC_FADESYNC(int param1) { CallFlowFunction(FlowFunction.BGENV_AISAC_FADESYNC, false, false, param1); }
        public void BGM_FADEIN(int param1) { CallFlowFunction(FlowFunction.BGM_FADEIN, false, false, param1); }
        public void TEST_TEX_DISP2(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.TEST_TEX_DISP2, false, false, param1, param2, param3, param4); }
        public void DAY_DISP(int param1) { CallFlowFunction(FlowFunction.DAY_DISP, false, false, param1); }
        public void SND_VOICE_DNGEVT_SETUP(int param1, int param2) { CallFlowFunction(FlowFunction.SND_VOICE_DNGEVT_SETUP, false, false, param1, param2); }
        public void SND_VOICE_DNGEVT_SYNC() { CallFlowFunction(FlowFunction.SND_VOICE_DNGEVT_SYNC, false, false); }
        public void SND_VOICE_DNGEVT_FREE() { CallFlowFunction(FlowFunction.SND_VOICE_DNGEVT_FREE, false, false); }
        public void TEST_TEX_DISP3(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.TEST_TEX_DISP3, false, false, param1, param2, param3); }
        public void TEST_TEX_MOVE(int param1, int param2) { CallFlowFunction(FlowFunction.TEST_TEX_MOVE, false, false, param1, param2); }
        public void DISABLE_SHARE_PLAY(int param1) { CallFlowFunction(FlowFunction.DISABLE_SHARE_PLAY, false, false, param1); }
        public void ENABLE_SHARE_PLAY(int param1) { CallFlowFunction(FlowFunction.ENABLE_SHARE_PLAY, false, false, param1); }
        public void ALL_ENABLE_SHARE_PLAY() { CallFlowFunction(FlowFunction.ALL_ENABLE_SHARE_PLAY, false, false); }
        public void MDL_SET_LOOKAT_LIMIT(int param1, int param2) { CallFlowFunction(FlowFunction.MDL_SET_LOOKAT_LIMIT, false, false, param1, param2); }
        public void SND_VOICE_BGMOB_DISABLE(int param1) { CallFlowFunction(FlowFunction.SND_VOICE_BGMOB_DISABLE, false, false, param1); }
        public void GOOD_GAUGE_DISP_ON() { CallFlowFunction(FlowFunction.GOOD_GAUGE_DISP_ON, false, false); }
        public void GOOD_GAUGE_DISP_OFF() { CallFlowFunction(FlowFunction.GOOD_GAUGE_DISP_OFF, false, false); }
        public void GET_ITEMS_WINDOW(int param1) { CallFlowFunction(FlowFunction.GET_ITEMS_WINDOW, false, false, param1); }
        public void GET_ITEM_BUF_SET(int param1, int param2) { CallFlowFunction(FlowFunction.GET_ITEM_BUF_SET, false, false, param1, param2); }
        public void GET_ITEM_BUF_RESET() { CallFlowFunction(FlowFunction.GET_ITEM_BUF_RESET, false, false); }
        public int CHK_PERSONA_IS_JAIL(int param1) { return CallFlowFunction(FlowFunction.CHK_PERSONA_IS_JAIL, false, false, param1); }
        public void MDL_EMOTE_ANIM(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.MDL_EMOTE_ANIM, false, false, param1, param2, param3, param4); }
        public int SEL_GENERIC_EX(int param1, int param2, int param3, int param4) { return CallFlowFunction(FlowFunction.SEL_GENERIC_EX, false, false, param1, param2, param3, param4); }
        public int SEL_GENERIC_NOT_HELP(int param1, int param2) { return CallFlowFunction(FlowFunction.SEL_GENERIC_NOT_HELP, false, false, param1, param2); }
        public void MDL_SET_LOOKAT_MOTION(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.MDL_SET_LOOKAT_MOTION, false, false, param1, param2, param3, param4); }
        public void MDL_SET_LOOKAT_HORIZON(int param1, int param2, float param3) { CallFlowFunction(FlowFunction.MDL_SET_LOOKAT_HORIZON, false, false, param1, param2, param3); }
        public int GET_CLOTH_TYPE() { return CallFlowFunction(FlowFunction.GET_CLOTH_TYPE, false, false); }
        public int GET_YASUMI_SET_DAYS(float param1, float param2) { return CallFlowFunction(FlowFunction.GET_YASUMI_SET_DAYS, false, false, param1, param2); }
        public int GET_TOTALDAY_SET_DAYS(float param1, float param2) { return CallFlowFunction(FlowFunction.GET_TOTALDAY_SET_DAYS, false, false, param1, param2); }
        public void CAMERA_SET_RESRC(int param1, int param2) { CallFlowFunction(FlowFunction.CAMERA_SET_RESRC, false, false, param1, param2); }
        public void MSG_TRIVIA(int param1) { CallFlowFunction(FlowFunction.MSG_TRIVIA, false, false, param1); }
        public void MDL_ANIM_LOOPSYNC(int param1) { CallFlowFunction(FlowFunction.MDL_ANIM_LOOPSYNC, false, false, param1); }
        public void CHAT_MSG(int param1, int param2) { CallFlowFunction(FlowFunction.CHAT_MSG, false, false, param1, param2); }
        public int CHAT_SEL(int param1) { return CallFlowFunction(FlowFunction.CHAT_SEL, false, false, param1); }
        public void MDL_ANIM_LINK_SE(int param1, int param2) { CallFlowFunction(FlowFunction.MDL_ANIM_LINK_SE, false, false, param1, param2); }
        public void MDL_ANIM_UNLINK_SE(int param1) { CallFlowFunction(FlowFunction.MDL_ANIM_UNLINK_SE, false, false, param1); }
        public void MDL_SET_LOOKAT_POS(int param1, float param2, float param3, float param4, int param5) { CallFlowFunction(FlowFunction.MDL_SET_LOOKAT_POS, false, false, param1, param2, param3, param4, param5); }
        public void LOADING_ICON_DISP(int param1) { CallFlowFunction(FlowFunction.LOADING_ICON_DISP, false, false, param1); }
        public void GOOD_GAUGE_START(int param1) { CallFlowFunction(FlowFunction.GOOD_GAUGE_START, false, false, param1); }
        public void GOOD_GAUGE_END() { CallFlowFunction(FlowFunction.GOOD_GAUGE_END, false, false); }
        public int GET_SEASON() { return CallFlowFunction(FlowFunction.GET_SEASON, false, false); }
        public void GOOD_GAUGE_START_EX() { CallFlowFunction(FlowFunction.GOOD_GAUGE_START_EX, false, false); }
        public void INIT_ITEM_SELECT() { CallFlowFunction(FlowFunction.INIT_ITEM_SELECT, false, false); }
        public void SET_ITEM_SELECT(int param1) { CallFlowFunction(FlowFunction.SET_ITEM_SELECT, false, false, param1); }
        public int START_ITEM_SELECT(int param1) { return CallFlowFunction(FlowFunction.START_ITEM_SELECT, false, false, param1); }
        public void CAMERA_QUAKE_2_START(float param1, float param2, float param3, float param4, float param5, int param6) { CallFlowFunction(FlowFunction.CAMERA_QUAKE_2_START, false, false, param1, param2, param3, param4, param5, param6); }
        public void CAMERA_QUAKE_2_STOP(float param1) { CallFlowFunction(FlowFunction.CAMERA_QUAKE_2_STOP, false, false, param1); }
        public void MDL_ICON_END(int param1, int param2) { CallFlowFunction(FlowFunction.MDL_ICON_END, false, false, param1, param2); }
        public int MDL_ICON_EX(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.MDL_ICON_EX, false, false, param1, param2, param3); }
        public void MDL_ICON_SET_SCALE(int param1, float param2) { CallFlowFunction(FlowFunction.MDL_ICON_SET_SCALE, false, false, param1, param2); }
        public void CLEAR_INHERIT_DATA() { CallFlowFunction(FlowFunction.CLEAR_INHERIT_DATA, false, false); }
        public void GOOD_GAUGE_LOAD_EX(int param1, int param2) { CallFlowFunction(FlowFunction.GOOD_GAUGE_LOAD_EX, false, false, param1, param2); }
        public void GOOD_GAUGE_SYNC_EX() { CallFlowFunction(FlowFunction.GOOD_GAUGE_SYNC_EX, false, false); }
        public void GOOD_GAUGE_END_SYNC() { CallFlowFunction(FlowFunction.GOOD_GAUGE_END_SYNC, false, false); }
        public void MDL_TRACK_CLEAR_ANIM(int param1, int param2) { CallFlowFunction(FlowFunction.MDL_TRACK_CLEAR_ANIM, false, false, param1, param2); }
        public void START_PLAY_GO_CHECK() { CallFlowFunction(FlowFunction.START_PLAY_GO_CHECK, false, false); }
        public int SYNC_PLAY_GO_CHECK() { return CallFlowFunction(FlowFunction.SYNC_PLAY_GO_CHECK, false, false); }
        public void NET_DISCONNECT_MATCH() { CallFlowFunction(FlowFunction.NET_DISCONNECT_MATCH, false, false); }
        public void SEL_SELNO(int param1) { CallFlowFunction(FlowFunction.SEL_SELNO, false, false, param1); }
        public void SEL_GENERIC_MASK(int param1, int param2) { CallFlowFunction(FlowFunction.SEL_GENERIC_MASK, false, false, param1, param2); }
        public void SEL_GENERIC_DISABLE(int param1, int param2) { CallFlowFunction(FlowFunction.SEL_GENERIC_DISABLE, false, false, param1, param2); }
        public int CHK_EX_SEASON(int param1) { return CallFlowFunction(FlowFunction.CHK_EX_SEASON, false, false, param1); }
        public void PERSONA_EVOLUTION_02(int param1) { CallFlowFunction(FlowFunction.PERSONA_EVOLUTION_02, false, false, param1); }
        public int GET_PLAYER_LV(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_PLAYER_LV, false, false, param1, param2); }
        public int GET_EQUIP_PERSONA_ID(int param1) { return CallFlowFunction(FlowFunction.GET_EQUIP_PERSONA_ID, false, false, param1); }
        public void MSG_DEVIL(int param1, int param2) { CallFlowFunction(FlowFunction.MSG_DEVIL, false, false, param1, param2); }
        public int CHK_CMB_SPECIAL_TIME() { return CallFlowFunction(FlowFunction.CHK_CMB_SPECIAL_TIME, false, false); }
        public void FAKE_DATE_SET(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FAKE_DATE_SET, false, false, param1, param2, param3, param4); }
        public void FAKE_DATE_RESET() { CallFlowFunction(FlowFunction.FAKE_DATE_RESET, false, false); }
        public void SND_VOICE_DLYEVT_SETUP(int param1, int param2) { CallFlowFunction(FlowFunction.SND_VOICE_DLYEVT_SETUP, false, false, param1, param2); }
        public void SND_VOICE_DLYEVT_SYNC() { CallFlowFunction(FlowFunction.SND_VOICE_DLYEVT_SYNC, false, false); }
        public void SND_VOICE_DLYEVT_FREE() { CallFlowFunction(FlowFunction.SND_VOICE_DLYEVT_FREE, false, false); }
        public int GET_ITEM_TYPE(int param1) { return CallFlowFunction(FlowFunction.GET_ITEM_TYPE, false, false, param1); }
        public int GET_EQUIP_ENABLE_PLAYER(int param1) { return CallFlowFunction(FlowFunction.GET_EQUIP_ENABLE_PLAYER, false, false, param1); }
        public int GET_ITEM_ATTACK(int param1) { return CallFlowFunction(FlowFunction.GET_ITEM_ATTACK, false, false, param1); }
        public int CHANGE_EQUIP_ITEM(int param1, int param2) { return CallFlowFunction(FlowFunction.CHANGE_EQUIP_ITEM, false, false, param1, param2); }
        public void DAY_DISP_CHANGE_TYPE(int param1) { CallFlowFunction(FlowFunction.DAY_DISP_CHANGE_TYPE, false, false, param1); }
        public int CHK_PERSONA_EVOLUTION(int param1) { return CallFlowFunction(FlowFunction.CHK_PERSONA_EVOLUTION, false, false, param1); }
        public void VOICE1_SYNC() { CallFlowFunction(FlowFunction.VOICE1_SYNC, false, false); }
        public void VOICE2_SYNC() { CallFlowFunction(FlowFunction.VOICE2_SYNC, false, false); }
        public void VOICE3_SYNC() { CallFlowFunction(FlowFunction.VOICE3_SYNC, false, false); }
        public void SET_EQUIP_PERSONA(int param1) { CallFlowFunction(FlowFunction.SET_EQUIP_PERSONA, false, false, param1); }
        public void AWARD_REQUEST(int param1, int param2) { CallFlowFunction(FlowFunction.AWARD_REQUEST, false, false, param1, param2); }
        public int GET_OPERATION(int param1) { return CallFlowFunction(FlowFunction.GET_OPERATION, false, false, param1); }
        public void SET_OPERATION(int param1, int param2) { CallFlowFunction(FlowFunction.SET_OPERATION, false, false, param1, param2); }
        public int CHECK_EXIST_BEFORE_SAVEDATA() { return CallFlowFunction(FlowFunction.CHECK_EXIST_BEFORE_SAVEDATA, false, false); }
        public void PURGE_RESRC_CACHE(int param1) { CallFlowFunction(FlowFunction.PURGE_RESRC_CACHE, false, false, param1); }
        public int SEL_HERO(int param1, int param2) { return CallFlowFunction(FlowFunction.SEL_HERO, false, false, param1, param2); }
        public void SEL_HERO_MASK(int param1) { CallFlowFunction(FlowFunction.SEL_HERO_MASK, false, false, param1); }
        public void SEL_HERO_NOTSEL(int param1) { CallFlowFunction(FlowFunction.SEL_HERO_NOTSEL, false, false, param1); }
        public int GET_PC_PARAM_EXP(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_PC_PARAM_EXP, false, false, param1, param2); }
        public int GET_LOCAL_TIME(int param1) { return CallFlowFunction(FlowFunction.GET_LOCAL_TIME, false, false, param1); }
        public int GET_AWARD_UNLOCK_COUNT() { return CallFlowFunction(FlowFunction.GET_AWARD_UNLOCK_COUNT, false, false); }
        public int CHECK_AWARD_UNLOCK(int param1) { return CallFlowFunction(FlowFunction.CHECK_AWARD_UNLOCK, false, false, param1); }
        public int CHECK_MYP_CONTENTS_COMPLETE(int param1) { return CallFlowFunction(FlowFunction.CHECK_MYP_CONTENTS_COMPLETE, false, false, param1); }
        public int GET_SYS_SCRIPT_FLAG(int param1) { return CallFlowFunction(FlowFunction.GET_SYS_SCRIPT_FLAG, false, false, param1); }
        public void SET_SYS_SCRIPT_FLAG(int param1, int param2) { CallFlowFunction(FlowFunction.SET_SYS_SCRIPT_FLAG, false, false, param1, param2); }
        public void CHAT_WND_CLS_WAIT() { CallFlowFunction(FlowFunction.CHAT_WND_CLS_WAIT, false, false); }
        public int CHECK_DISABLE_SHARE_PLAY(int param1) { return CallFlowFunction(FlowFunction.CHECK_DISABLE_SHARE_PLAY, false, false, param1); }
        public int GET_PC_LEVEL(int param1) { return CallFlowFunction(FlowFunction.GET_PC_LEVEL, false, false, param1); }
        public void START_PC_LEVEL_UP(int param1, int param2) { CallFlowFunction(FlowFunction.START_PC_LEVEL_UP, false, false, param1, param2); }
        public int FRIEND_GET_SP_SKILL(int param1, int param2) { return CallFlowFunction(FlowFunction.FRIEND_GET_SP_SKILL, false, false, param1, param2); }
        public void FLAG_DATA_INPUT(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLAG_DATA_INPUT, false, false, param1, param2, param3); }
        public void MDL_ANIM_LINK_STOP_SE(int param1, int param2) { CallFlowFunction(FlowFunction.MDL_ANIM_LINK_STOP_SE, false, false, param1, param2); }
        public void FLAG_DATA_INPUT_SYNC() { CallFlowFunction(FlowFunction.FLAG_DATA_INPUT_SYNC, false, false); }
        public void E_LIGHT_RESET() { CallFlowFunction(FlowFunction.E_LIGHT_RESET, false, false); }
        public int GET_PLATFORM() { return CallFlowFunction(FlowFunction.GET_PLATFORM, false, false); }
        public int GET_TEXT_PLATFORM() { return CallFlowFunction(FlowFunction.GET_TEXT_PLATFORM, false, false); }
        public void PRESS_WIRE() { CallFlowFunction(FlowFunction.PRESS_WIRE, false, false); }
        public void CALL_WEAPON_SHOP() { CallFlowFunction(FlowFunction.CALL_WEAPON_SHOP, false, false); }
        public void CALL_ITEM_SHOP() { CallFlowFunction(FlowFunction.CALL_ITEM_SHOP, false, false); }
        public void CALL_COMBINE_SHOP() { CallFlowFunction(FlowFunction.CALL_COMBINE_SHOP, false, false); }
        public void CALL_QUEST_DAYTIME() { CallFlowFunction(FlowFunction.CALL_QUEST_DAYTIME, false, false); }
        public void SET_QUEST_BEFORE_DUNGEON() { CallFlowFunction(FlowFunction.SET_QUEST_BEFORE_DUNGEON, false, false); }
        public void RESET_QUEST_AFTER_DUNGEON() { CallFlowFunction(FlowFunction.RESET_QUEST_AFTER_DUNGEON, false, false); }
        public void CHECK_CONSET_QUEST() { CallFlowFunction(FlowFunction.CHECK_CONSET_QUEST, false, false); }
        public void START_QUEST_CLEAR_EFFECT() { CallFlowFunction(FlowFunction.START_QUEST_CLEAR_EFFECT, false, false); }
        public void CHECK_QUEST_CLEAR_ENEMY() { CallFlowFunction(FlowFunction.CHECK_QUEST_CLEAR_ENEMY, false, false); }
        public void CHECK_QUEST_CLEAR_BOSS() { CallFlowFunction(FlowFunction.CHECK_QUEST_CLEAR_BOSS, false, false); }
        public void CHECK_QUEST_CLEAR_ITEM() { CallFlowFunction(FlowFunction.CHECK_QUEST_CLEAR_ITEM, false, false); }
        public int GET_COMB_MATPER_MAJOR(int param1) { return CallFlowFunction(FlowFunction.GET_COMB_MATPER_MAJOR, false, false, param1); }
        public int GET_COMB_MATPER_MINOR(int param1) { return CallFlowFunction(FlowFunction.GET_COMB_MATPER_MINOR, false, false, param1); }
        public int GET_COMB_RETPER_MAJOR() { return CallFlowFunction(FlowFunction.GET_COMB_RETPER_MAJOR, false, false); }
        public int GET_COMB_RETPER_MINOR() { return CallFlowFunction(FlowFunction.GET_COMB_RETPER_MINOR, false, false); }
        public void CALL_NAME_ENTRY() { CallFlowFunction(FlowFunction.CALL_NAME_ENTRY, false, false); }
        public void FCL_SHOP_CHANGE_FLAG() { CallFlowFunction(FlowFunction.FCL_SHOP_CHANGE_FLAG, false, false); }
        public void UI_MISSION_OFFER(int param1) { CallFlowFunction(FlowFunction.UI_MISSION_OFFER, false, false, param1); }
        public void UI_MISSION_END(int param1) { CallFlowFunction(FlowFunction.UI_MISSION_END, false, false, param1); }
        public int UI_MISSION_CHECK_OFFER(int param1) { return CallFlowFunction(FlowFunction.UI_MISSION_CHECK_OFFER, false, false, param1); }
        public int UI_MISSION_CHECK_END(int param1) { return CallFlowFunction(FlowFunction.UI_MISSION_CHECK_END, false, false, param1); }
        public void MISSION_START_EFFECT() { CallFlowFunction(FlowFunction.MISSION_START_EFFECT, false, false); }
        public void MISSION_COMPLETE_EFFECT() { CallFlowFunction(FlowFunction.MISSION_COMPLETE_EFFECT, false, false); }
        public void CALL_ROUTE_MAP(int param1, int param2, int param3, int param4, int param5) { CallFlowFunction(FlowFunction.CALL_ROUTE_MAP, false, false, param1, param2, param3, param4, param5); }
        public void CALL_ITEM_SHOP_EX() { CallFlowFunction(FlowFunction.CALL_ITEM_SHOP_EX, false, false); }
        public void CALL_WEAPON_SHOP_EX() { CallFlowFunction(FlowFunction.CALL_WEAPON_SHOP_EX, false, false); }
        public int MISSION_GET_STATE(int param1) { return CallFlowFunction(FlowFunction.MISSION_GET_STATE, false, false, param1); }
        public void MISSION_SET_STATE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.MISSION_SET_STATE, false, false, param1, param2, param3); }
        public void MISSION_UPDATE_EVERY_DAY() { CallFlowFunction(FlowFunction.MISSION_UPDATE_EVERY_DAY, false, false); }
        public int CALL_PUBLIC_SHOP(int param1) { return CallFlowFunction(FlowFunction.CALL_PUBLIC_SHOP, false, false, param1); }
        public void CALL_DIARY() { CallFlowFunction(FlowFunction.CALL_DIARY, false, false); }
        public int CHECK_PUBLIC_SHOP_STOCK(int param1) { return CallFlowFunction(FlowFunction.CHECK_PUBLIC_SHOP_STOCK, false, false, param1); }
        public void CALL_CHAT_CHECK() { CallFlowFunction(FlowFunction.CALL_CHAT_CHECK, false, false); }
        public void CALL_CHAT_LIST() { CallFlowFunction(FlowFunction.CALL_CHAT_LIST, false, false); }
        public void CALL_QUEST_ORDER() { CallFlowFunction(FlowFunction.CALL_QUEST_ORDER, false, false); }
        public void CALL_CHAT_DIRECT(int param1) { CallFlowFunction(FlowFunction.CALL_CHAT_DIRECT, false, false, param1); }
        public void CALL_WEAPON_SHOP_DATA_LOAD() { CallFlowFunction(FlowFunction.CALL_WEAPON_SHOP_DATA_LOAD, false, false); }
        public void CALL_WEAPON_SHOP_END() { CallFlowFunction(FlowFunction.CALL_WEAPON_SHOP_END, false, false); }
        public void CALL_TUTORIAL(int param1, int param2) { CallFlowFunction(FlowFunction.CALL_TUTORIAL, false, false, param1, param2); }
        public void CALL_GLOBAL_MONEY_PANEL() { CallFlowFunction(FlowFunction.CALL_GLOBAL_MONEY_PANEL, false, false); }
        public void DEL_GLOBAL_MONEY_PANEL() { CallFlowFunction(FlowFunction.DEL_GLOBAL_MONEY_PANEL, false, false); }
        public void CALL_WANTED_EXP_PANEL(int param1) { CallFlowFunction(FlowFunction.CALL_WANTED_EXP_PANEL, false, false, param1); }
        public void CALL_WANTED_EXP_NO_WAIT(int param1) { CallFlowFunction(FlowFunction.CALL_WANTED_EXP_NO_WAIT, false, false, param1); }
        public void ADD_REPUTATION(int param1, int param2) { CallFlowFunction(FlowFunction.ADD_REPUTATION, false, false, param1, param2); }
        public void ADD_REPUTATION_NO_WAIT(int param1, int param2) { CallFlowFunction(FlowFunction.ADD_REPUTATION_NO_WAIT, false, false, param1, param2); }
        public void ADD_REPUTATION_FORCE_END() { CallFlowFunction(FlowFunction.ADD_REPUTATION_FORCE_END, false, false); }
        public void SET_REPUTATION(int param1, int param2) { CallFlowFunction(FlowFunction.SET_REPUTATION, false, false, param1, param2); }
        public int GET_REPUTATION(int param1) { return CallFlowFunction(FlowFunction.GET_REPUTATION, false, false, param1); }
        public void CALL_ITEM_SHOP_DATA_LOAD() { CallFlowFunction(FlowFunction.CALL_ITEM_SHOP_DATA_LOAD, false, false); }
        public int CALL_ARBEIT_BOOK(int param1) { return CallFlowFunction(FlowFunction.CALL_ARBEIT_BOOK, false, false, param1); }
        public void DIRECT_SUBSCRIBE_ARBEIT(int param1) { CallFlowFunction(FlowFunction.DIRECT_SUBSCRIBE_ARBEIT, false, false, param1); }
        public int CHECK_SUBSCRIBE_ARBEIT(int param1) { return CallFlowFunction(FlowFunction.CHECK_SUBSCRIBE_ARBEIT, false, false, param1); }
        public int CHECK_ENABLE_ARBEIT(int param1) { return CallFlowFunction(FlowFunction.CHECK_ENABLE_ARBEIT, false, false, param1); }
        public void CALL_WANTED_EXP_BATTLE(int param1, int param2) { CallFlowFunction(FlowFunction.CALL_WANTED_EXP_BATTLE, false, false, param1, param2); }
        public void RESET_INJECTION_EFFECT() { CallFlowFunction(FlowFunction.RESET_INJECTION_EFFECT, false, false); }
        public int SKILLCARD_COPY_CHK() { return CallFlowFunction(FlowFunction.SKILLCARD_COPY_CHK, false, false); }
        public int SKILLCARD_LIST_DISP(int param1) { return CallFlowFunction(FlowFunction.SKILLCARD_LIST_DISP, false, false, param1); }
        public void CALL_PHANTOM_NAME_ENTRY() { CallFlowFunction(FlowFunction.CALL_PHANTOM_NAME_ENTRY, false, false); }
        public void EXEC_EVT_COMBINE(int param1) { CallFlowFunction(FlowFunction.EXEC_EVT_COMBINE, false, false, param1); }
        public int GET_PUBLIC_SHOP_BUY_TYPE_NUM(int param1) { return CallFlowFunction(FlowFunction.GET_PUBLIC_SHOP_BUY_TYPE_NUM, false, false, param1); }
        public int GET_PUBLIC_SHOP_ITEM_ID(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_PUBLIC_SHOP_ITEM_ID, false, false, param1, param2); }
        public int GET_PUBLIC_SHOP_ITEM_BUY_NUM(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_PUBLIC_SHOP_ITEM_BUY_NUM, false, false, param1, param2); }
        public int CHECK_PUBLIC_SHOP_SET_ITEM(int param1, int param2) { return CallFlowFunction(FlowFunction.CHECK_PUBLIC_SHOP_SET_ITEM, false, false, param1, param2); }
        public int GET_PUBLIC_SHOP_SET_ITEM_PACK_NUM(int param1) { return CallFlowFunction(FlowFunction.GET_PUBLIC_SHOP_SET_ITEM_PACK_NUM, false, false, param1); }
        public int GET_PUBLIC_SHOP_SET_ITEM_PACK_ITEM_ID(int param1, int param2) { return CallFlowFunction(FlowFunction.GET_PUBLIC_SHOP_SET_ITEM_PACK_ITEM_ID, false, false, param1, param2); }
        public void PUBLIC_SHOP_BUY_ITEM_COPY() { CallFlowFunction(FlowFunction.PUBLIC_SHOP_BUY_ITEM_COPY, false, false); }
        public void PUBLIC_SHOP_BUY_ITEM_BAG_IN() { CallFlowFunction(FlowFunction.PUBLIC_SHOP_BUY_ITEM_BAG_IN, false, false); }
        public void CALL_CHAT_READ_UN_READ() { CallFlowFunction(FlowFunction.CALL_CHAT_READ_UN_READ, false, false); }
        public void CALL_CONF_COOPERATION(int param1, int param2) { CallFlowFunction(FlowFunction.CALL_CONF_COOPERATION, false, false, param1, param2); }
        public void CHAT_RESERVE_END() { CallFlowFunction(FlowFunction.CHAT_RESERVE_END, false, false); }
        public void CALL_CHAT_ARRIVAL(int param1) { CallFlowFunction(FlowFunction.CALL_CHAT_ARRIVAL, false, false, param1); }
        public void CHAT_ALL_CLEAR() { CallFlowFunction(FlowFunction.CHAT_ALL_CLEAR, false, false); }
        public int CHAT_GET_ARRIVAL_MONTH(int param1) { return CallFlowFunction(FlowFunction.CHAT_GET_ARRIVAL_MONTH, false, false, param1); }
        public int CHAT_GET_ARRIVAL_DAY(int param1) { return CallFlowFunction(FlowFunction.CHAT_GET_ARRIVAL_DAY, false, false, param1); }
        public void CMB_CELL_ERASE() { CallFlowFunction(FlowFunction.CMB_CELL_ERASE, false, false); }
        public void CHAT_SET_SWITCH(int param1, int param2) { CallFlowFunction(FlowFunction.CHAT_SET_SWITCH, false, false, param1, param2); }
        public int CHAT_CHECK_SWITCH(int param1) { return CallFlowFunction(FlowFunction.CHAT_CHECK_SWITCH, false, false, param1); }
        public void CMB_PREPARE_START() { CallFlowFunction(FlowFunction.CMB_PREPARE_START, false, false); }
        public void CMB_PREPARE_END() { CallFlowFunction(FlowFunction.CMB_PREPARE_END, false, false); }
        public int CHAT_GET_UNREAD_NUM() { return CallFlowFunction(FlowFunction.CHAT_GET_UNREAD_NUM, false, false); }
        public void OPEN_FAILED_QUEST_LIST() { CallFlowFunction(FlowFunction.OPEN_FAILED_QUEST_LIST, false, false); }
        public int SYNC_FAILED_QUEST_LIST() { return CallFlowFunction(FlowFunction.SYNC_FAILED_QUEST_LIST, false, false); }
        public void RESTART_FAILED_QUEST_LIST() { CallFlowFunction(FlowFunction.RESTART_FAILED_QUEST_LIST, false, false); }
        public void CLOSE_FAILED_QUEST_LIST() { CallFlowFunction(FlowFunction.CLOSE_FAILED_QUEST_LIST, false, false); }
        public void CALL_WANTED_EXP_LEVELUP(int param1) { CallFlowFunction(FlowFunction.CALL_WANTED_EXP_LEVELUP, false, false, param1); }
        public int MISSION_GET_NUM_STATE(int param1) { return CallFlowFunction(FlowFunction.MISSION_GET_NUM_STATE, false, false, param1); }
        public int CHANGE_GLOBAL_MONEY(int param1, int param2) { return CallFlowFunction(FlowFunction.CHANGE_GLOBAL_MONEY, false, false, param1, param2); }
        public int MISSION_GET_RANK(int param1) { return CallFlowFunction(FlowFunction.MISSION_GET_RANK, false, false, param1); }
        public void ADD_PUBLIC_SHOP_CHOICE_ITEM(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.ADD_PUBLIC_SHOP_CHOICE_ITEM, false, false, param1, param2, param3); }
        public void SET_PUBLIC_SHOP_CHOICE_ITEM(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.SET_PUBLIC_SHOP_CHOICE_ITEM, false, false, param1, param2, param3); }
        public void CALL_GLOBAL_MONEY_PANEL_EX(int param1) { CallFlowFunction(FlowFunction.CALL_GLOBAL_MONEY_PANEL_EX, false, false, param1); }
        public void CHAT_SET_HOLD(int param1, int param2) { CallFlowFunction(FlowFunction.CHAT_SET_HOLD, false, false, param1, param2); }
        public int CHAT_CHECK_HOLD(int param1) { return CallFlowFunction(FlowFunction.CHAT_CHECK_HOLD, false, false, param1); }
        public void CALL_GLOBAL_ITEM_PANEL(int param1) { CallFlowFunction(FlowFunction.CALL_GLOBAL_ITEM_PANEL, false, false, param1); }
        public void DEL_GLOBAL_ITEM_PANEL() { CallFlowFunction(FlowFunction.DEL_GLOBAL_ITEM_PANEL, false, false); }
        public int CHANGE_GLOBAL_ITEM() { return CallFlowFunction(FlowFunction.CHANGE_GLOBAL_ITEM, false, false); }
        public int CHANGE_GLOBAL_ITEM_EX(int param1) { return CallFlowFunction(FlowFunction.CHANGE_GLOBAL_ITEM_EX, false, false, param1); }
        public int IMG_CREATE(int param1, int param2) { return CallFlowFunction(FlowFunction.IMG_CREATE, false, false, param1, param2); }
        public void IMG_DELETE(int param1) { CallFlowFunction(FlowFunction.IMG_DELETE, false, false, param1); }
        public void IMG_LOAD_CALL(int param1) { CallFlowFunction(FlowFunction.IMG_LOAD_CALL, false, false, param1); }
        public void IMG_LOAD_SYNC(int param1) { CallFlowFunction(FlowFunction.IMG_LOAD_SYNC, false, false, param1); }
        public void IMG_ANIM_CALL(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.IMG_ANIM_CALL, false, false, param1, param2, param3); }
        public void IMG_ANIM_SYNC(int param1) { CallFlowFunction(FlowFunction.IMG_ANIM_SYNC, false, false, param1); }
        public int CHAT_GET_JOIN_ID(int param1) { return CallFlowFunction(FlowFunction.CHAT_GET_JOIN_ID, false, false, param1); }
        public void IMG_DSP(int param1, int param2) { CallFlowFunction(FlowFunction.IMG_DSP, false, false, param1, param2); }
        public void IMG_CLS() { CallFlowFunction(FlowFunction.IMG_CLS, false, false); }
        public int CHANGE_GLOBAL_MONEY_EX(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.CHANGE_GLOBAL_MONEY_EX, false, false, param1, param2, param3); }
        public void OPEN_QUEST_LIST_DISP() { CallFlowFunction(FlowFunction.OPEN_QUEST_LIST_DISP, false, false); }
        public int CMB_GET_PBOOK_REGIST_RATE() { return CallFlowFunction(FlowFunction.CMB_GET_PBOOK_REGIST_RATE, false, false); }
        public int CALL_FICTION_DRAW() { return CallFlowFunction(FlowFunction.CALL_FICTION_DRAW, false, false); }
        public void SET_PUBLIC_SHOP_CHOICE_ITEM_DISCOUNT(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.SET_PUBLIC_SHOP_CHOICE_ITEM_DISCOUNT, false, false, param1, param2, param3); }
        public void CHAT_RESET_DIRECT(int param1) { CallFlowFunction(FlowFunction.CHAT_RESET_DIRECT, false, false, param1); }
        public void CALL_DIFFICULT_SET() { CallFlowFunction(FlowFunction.CALL_DIFFICULT_SET, false, false); }
        public void UPDATE_CMB_EVERYMORNING() { CallFlowFunction(FlowFunction.UPDATE_CMB_EVERYMORNING, false, false); }
        public void CALL_DARTS_TASK_START(int param1, int param2) { CallFlowFunction(FlowFunction.CALL_DARTS_TASK_START, false, false, param1, param2); }
        public int CALL_DARTS_PLAY(int param1, int param2) { return CallFlowFunction(FlowFunction.CALL_DARTS_PLAY, false, false, param1, param2); }
        public void DARTS_LOOP_COUNT_ADD() { CallFlowFunction(FlowFunction.DARTS_LOOP_COUNT_ADD, false, false); }
        public int DARTS_LOOP_COUNT_CHK() { return CallFlowFunction(FlowFunction.DARTS_LOOP_COUNT_CHK, false, false); }
        public void CALL_DARTS_TASK_END() { CallFlowFunction(FlowFunction.CALL_DARTS_TASK_END, false, false); }
        public int CALL_PUBLIC_SHOP_TV(int param1) { return CallFlowFunction(FlowFunction.CALL_PUBLIC_SHOP_TV, false, false, param1); }
        public void CALL_STAMP_SHOP() { CallFlowFunction(FlowFunction.CALL_STAMP_SHOP, false, false); }
        public int CALL_MEMENTOS_SHOP() { return CallFlowFunction(FlowFunction.CALL_MEMENTOS_SHOP, false, false); }
        public void CALL_EXROOT_END_DRAW(int param1) { CallFlowFunction(FlowFunction.CALL_EXROOT_END_DRAW, false, false, param1); }
        public void SET_COMBINE_SPECIAL_MODE(int param1) { CallFlowFunction(FlowFunction.SET_COMBINE_SPECIAL_MODE, false, false, param1); }
        public int CALL_BILLIARDS_START(int param1) { return CallFlowFunction(FlowFunction.CALL_BILLIARDS_START, false, false, param1); }
        public void DARTS_SET_NPC_SCORE(int param1, int param2) { CallFlowFunction(FlowFunction.DARTS_SET_NPC_SCORE, false, false, param1, param2); }
        public void CALL_DARTS_TASK_START_EX(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.CALL_DARTS_TASK_START_EX, false, false, param1, param2, param3); }
        public int CALL_DARTS_PLAY_EX(int param1, int param2, int param3, int param4, int param5) { return CallFlowFunction(FlowFunction.CALL_DARTS_PLAY_EX, false, false, param1, param2, param3, param4, param5); }
        public int CALL_VINTAGE_SHOP() { return CallFlowFunction(FlowFunction.CALL_VINTAGE_SHOP, false, false); }
        public void CALL_DARTS_TASK_START_ROUND(int param1) { CallFlowFunction(FlowFunction.CALL_DARTS_TASK_START_ROUND, false, false, param1); }
        public int CALL_DARTS_PLAY_ROUND(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.CALL_DARTS_PLAY_ROUND, false, false, param1, param2, param3); }
        public int GET_VINTAGE_SHOP_SELL_NUM() { return CallFlowFunction(FlowFunction.GET_VINTAGE_SHOP_SELL_NUM, false, false); }
        public int CHK_DARTS_BUST() { return CallFlowFunction(FlowFunction.CHK_DARTS_BUST, false, false); }
        public void CALL_PERSONA_SKILL_CARD_SHOP() { CallFlowFunction(FlowFunction.CALL_PERSONA_SKILL_CARD_SHOP, false, false); }
        public void CALL_DARTS_WIPE_FADE_IN() { CallFlowFunction(FlowFunction.CALL_DARTS_WIPE_FADE_IN, false, false); }
        public void CALL_DARTS_WIPE_START() { CallFlowFunction(FlowFunction.CALL_DARTS_WIPE_START, false, false); }
        public void DARTS_WIPE_SYNC() { CallFlowFunction(FlowFunction.DARTS_WIPE_SYNC, false, false); }
        public void CALL_DARTS_WIPE_END() { CallFlowFunction(FlowFunction.CALL_DARTS_WIPE_END, false, false); }
        public int DARTS_WIPE_TIMER_CHECK() { return CallFlowFunction(FlowFunction.DARTS_WIPE_TIMER_CHECK, false, false); }
        public void DARTS_WIPE_START_FADE_IN(int param1) { CallFlowFunction(FlowFunction.DARTS_WIPE_START_FADE_IN, false, false, param1); }
        public int CALL_DARTS_MEMB_LIST() { return CallFlowFunction(FlowFunction.CALL_DARTS_MEMB_LIST, false, false); }
        public void SKILLCARD_COPY_CONFIRM(int param1) { CallFlowFunction(FlowFunction.SKILLCARD_COPY_CONFIRM, false, false, param1); }
        public int SKILLCARD_LIST_DISP_CREATE(int param1) { return CallFlowFunction(FlowFunction.SKILLCARD_LIST_DISP_CREATE, false, false, param1); }
        public int SKILLCARD_LIST_DISP_CREATE_ALL() { return CallFlowFunction(FlowFunction.SKILLCARD_LIST_DISP_CREATE_ALL, false, false); }
        public int SKILLCARD_CREATE_CHK(int param1) { return CallFlowFunction(FlowFunction.SKILLCARD_CREATE_CHK, false, false, param1); }
        public int SKILLCARD_CREATE_CHK_ALL() { return CallFlowFunction(FlowFunction.SKILLCARD_CREATE_CHK_ALL, false, false); }
        public void CALL_DARTS_TASK_START_RESRC(int param1, int param2) { CallFlowFunction(FlowFunction.CALL_DARTS_TASK_START_RESRC, false, false, param1, param2); }
        public int CALL_CHALLENGE_BTL_SEL() { return CallFlowFunction(FlowFunction.CALL_CHALLENGE_BTL_SEL, false, false); }
        public void CONFIRM_PS_STATUS(int param1, int param2) { CallFlowFunction(FlowFunction.CONFIRM_PS_STATUS, false, false, param1, param2); }
        public int SELECT_FRIEND(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.SELECT_FRIEND, false, false, param1, param2, param3); }
        public int CHECK_HAVE_INCENSE() { return CallFlowFunction(FlowFunction.CHECK_HAVE_INCENSE, false, false); }
        public void START_VIDEO_VIEWER() { CallFlowFunction(FlowFunction.START_VIDEO_VIEWER, false, false); }
        public void START_SOUND_VIEWER() { CallFlowFunction(FlowFunction.START_SOUND_VIEWER, false, false); }
        public void START_IMAGE_VIEWER() { CallFlowFunction(FlowFunction.START_IMAGE_VIEWER, false, false); }
        public void COMFIRM_PS_PARAM_UP(int param1, int param2, int param3, int param4, int param5, int param6, int param7) { CallFlowFunction(FlowFunction.COMFIRM_PS_PARAM_UP, false, false, param1, param2, param3, param4, param5, param6, param7); }
        public int CALL_DARTS_MEMB_LIST_CONF() { return CallFlowFunction(FlowFunction.CALL_DARTS_MEMB_LIST_CONF, false, false); }
        public void START_PALACE_MAKER() { CallFlowFunction(FlowFunction.START_PALACE_MAKER, false, false); }
        public void CALL_TEC_RANK_START() { CallFlowFunction(FlowFunction.CALL_TEC_RANK_START, false, false); }
        public void CALL_TEC_RANK_START_EX() { CallFlowFunction(FlowFunction.CALL_TEC_RANK_START_EX, false, false); }
        public void CALL_BILLIARDS_RESULT_START(int param1, int param2) { CallFlowFunction(FlowFunction.CALL_BILLIARDS_RESULT_START, false, false, param1, param2); }
        public void START_DARTS_BATONTOUCH(int param1, int param2) { CallFlowFunction(FlowFunction.START_DARTS_BATONTOUCH, false, false, param1, param2); }
        public void START_AWARD_VIEWER2(int param1) { CallFlowFunction(FlowFunction.START_AWARD_VIEWER2, false, false, param1); }
        public void MYP_CONF_OBJECT(int param1, int param2) { CallFlowFunction(FlowFunction.MYP_CONF_OBJECT, false, false, param1, param2); }
        public void DARTS_CMD_INITIALIZE(int param1) { CallFlowFunction(FlowFunction.DARTS_CMD_INITIALIZE, false, false, param1); }
        public int DARTS_CMD_GET_PCID(int param1) { return CallFlowFunction(FlowFunction.DARTS_CMD_GET_PCID, false, false, param1); }
        public void DARTS_CMD_RELEASE() { CallFlowFunction(FlowFunction.DARTS_CMD_RELEASE, false, false); }
        public int DARTS_CMD_GET_POSITION(int param1) { return CallFlowFunction(FlowFunction.DARTS_CMD_GET_POSITION, false, false, param1); }
        public void CALL_DARTS_TASK_START_RESRC_EX(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.CALL_DARTS_TASK_START_RESRC_EX, false, false, param1, param2, param3); }
        public int DARTS_CMD_CHK_NPC_FINISH(int param1) { return CallFlowFunction(FlowFunction.DARTS_CMD_CHK_NPC_FINISH, false, false, param1); }
        public void DARTS_CMD_SET_FINISH_MODE() { CallFlowFunction(FlowFunction.DARTS_CMD_SET_FINISH_MODE, false, false); }
        public int DARTS_CMD_GET_CHALLENGE_POINT() { return CallFlowFunction(FlowFunction.DARTS_CMD_GET_CHALLENGE_POINT, false, false); }
        public int DARTS_CMD_COMPARISON(int param1, int param2) { return CallFlowFunction(FlowFunction.DARTS_CMD_COMPARISON, false, false, param1, param2); }
        public int DARTS_CMD_GET_CHALLENGE_HIGH_RANK() { return CallFlowFunction(FlowFunction.DARTS_CMD_GET_CHALLENGE_HIGH_RANK, false, false); }
        public int CALL_PUBLIC_SHOP_FREE(int param1) { return CallFlowFunction(FlowFunction.CALL_PUBLIC_SHOP_FREE, false, false, param1); }
        public void FCL_SET_CUSTOM_TYPE(int param1, int param2) { CallFlowFunction(FlowFunction.FCL_SET_CUSTOM_TYPE, false, false, param1, param2); }
        public void CALL_FIELD(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.CALL_FIELD, false, false, param1, param2, param3, param4); }
        public int FLD_GET_SCRIPT_TIMING() { return CallFlowFunction(FlowFunction.FLD_GET_SCRIPT_TIMING, false, false); }
        public void FLD_PC_MODEL_CHANGE() { CallFlowFunction(FlowFunction.FLD_PC_MODEL_CHANGE, false, false); }
        public int FLD_PC_GET_RESHND(int param1) { return CallFlowFunction(FlowFunction.FLD_PC_GET_RESHND, false, false, param1); }
        public int FLD_NPC_GET_RESHND() { return CallFlowFunction(FlowFunction.FLD_NPC_GET_RESHND, false, false); }
        public void FLD_CAMERA_LOCK() { CallFlowFunction(FlowFunction.FLD_CAMERA_LOCK, false, false); }
        public void FLD_CAMERA_UNLOCK() { CallFlowFunction(FlowFunction.FLD_CAMERA_UNLOCK, false, false); }
        public int FLD_OBJ_GET_RESHND() { return CallFlowFunction(FlowFunction.FLD_OBJ_GET_RESHND, false, false); }
        public int FLD_OPEN_DOOR() { return CallFlowFunction(FlowFunction.FLD_OPEN_DOOR, false, false); }
        public int FLD_GET_TBOX() { return CallFlowFunction(FlowFunction.FLD_GET_TBOX, false, false); }
        public int FLD_GET_TBOX_FLAG() { return CallFlowFunction(FlowFunction.FLD_GET_TBOX_FLAG, false, false); }
        public void FLD_SWITCH_FAILURE(int param1) { CallFlowFunction(FlowFunction.FLD_SWITCH_FAILURE, false, false, param1); }
        public void FLD_PC_MODEL_SET_POS(int param1) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_SET_POS, false, false, param1); }
        public int FLD_OPEN_DOOR_NO(int param1) { return CallFlowFunction(FlowFunction.FLD_OPEN_DOOR_NO, false, false, param1); }
        public void FLD_SET_SUBJECT_MODE(int param1) { CallFlowFunction(FlowFunction.FLD_SET_SUBJECT_MODE, false, false, param1); }
        public void FLD_SOBJ_RECOVER() { CallFlowFunction(FlowFunction.FLD_SOBJ_RECOVER, false, false); }
        public void FLD_NEXT_DNG_LEVEL(int param1) { CallFlowFunction(FlowFunction.FLD_NEXT_DNG_LEVEL, false, false, param1); }
        public int FLD_GET_DNG_LEVEL() { return CallFlowFunction(FlowFunction.FLD_GET_DNG_LEVEL, false, false); }
        public void FLD_MAP_SEARCH() { CallFlowFunction(FlowFunction.FLD_MAP_SEARCH, false, false); }
        public int FLD_GET_DNG_AREA_DIR() { return CallFlowFunction(FlowFunction.FLD_GET_DNG_AREA_DIR, false, false); }
        public void FLD_PC_MODEL_SET_DNG_POS() { CallFlowFunction(FlowFunction.FLD_PC_MODEL_SET_DNG_POS, false, false); }
        public void FLD_ROT_CAMERA(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_ROT_CAMERA, false, false, param1, param2); }
        public void FLD_ROT_WORLD_CAMERA(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_ROT_WORLD_CAMERA, false, false, param1, param2); }
        public void FLD_ROT_DOOR_CAMERA(int param1) { CallFlowFunction(FlowFunction.FLD_ROT_DOOR_CAMERA, false, false, param1); }
        public void FLD_REPORT_MSG(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_REPORT_MSG, false, false, param1, param2); }
        public void FLD_REPORT_MSGSYNC(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_REPORT_MSGSYNC, false, false, param1, param2); }
        public void FLD_REPORT_FREE() { CallFlowFunction(FlowFunction.FLD_REPORT_FREE, false, false); }
        public int FLD_GET_TARGET_ENEMY_TYPE() { return CallFlowFunction(FlowFunction.FLD_GET_TARGET_ENEMY_TYPE, false, false); }
        public int FLD_GET_ENCOUNTID(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_ENCOUNTID, false, false, param1); }
        public int FLD_GET_MAJOR() { return CallFlowFunction(FlowFunction.FLD_GET_MAJOR, false, false); }
        public int FLD_GET_MINOR() { return CallFlowFunction(FlowFunction.FLD_GET_MINOR, false, false); }
        public void FLD_RETRY_SAVE() { CallFlowFunction(FlowFunction.FLD_RETRY_SAVE, false, false); }
        public void FLD_RETRY_LOAD() { CallFlowFunction(FlowFunction.FLD_RETRY_LOAD, false, false); }
        public void FLD_MODEL_SET_POS(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_MODEL_SET_POS, false, false, param1, param2); }
        public int FLD_MODEL_LOADSYNC(int param1) { return CallFlowFunction(FlowFunction.FLD_MODEL_LOADSYNC, false, false, param1); }
        public int FLD_NPC_MODEL_LOAD(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_NPC_MODEL_LOAD, false, false, param1, param2, param3); }
        public int FLD_OBJ_MODEL_LOAD(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_OBJ_MODEL_LOAD, false, false, param1, param2); }
        public int FLD_OBJ_MODEL_LOADSYNC(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_OBJ_MODEL_LOADSYNC, false, false, param1, param2); }
        public void FLD_OBJ_MODEL_COLLIS(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_OBJ_MODEL_COLLIS, false, false, param1, param2); }
        public void FLD_NPC_SYNC() { CallFlowFunction(FlowFunction.FLD_NPC_SYNC, false, false); }
        public void CALL_BKUP_FIELD() { CallFlowFunction(FlowFunction.CALL_BKUP_FIELD, false, false); }
        public void FLD_SET_SAVE_COUNTER(int param1) { CallFlowFunction(FlowFunction.FLD_SET_SAVE_COUNTER, false, false, param1); }
        public int FLD_GET_DNG_NO() { return CallFlowFunction(FlowFunction.FLD_GET_DNG_NO, false, false); }
        public void FLD_DUNGEON_EFFECT_ENABLE(int param1) { CallFlowFunction(FlowFunction.FLD_DUNGEON_EFFECT_ENABLE, false, false, param1); }
        public void FLD_CINEMASCOPE_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_CINEMASCOPE_VISIBLE, false, false, param1); }
        public void FLD_REQ_FLASHBACK(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_REQ_FLASHBACK, false, false, param1, param2); }
        public int FLD_CHECK_DNG_EDIT_FLOOR() { return CallFlowFunction(FlowFunction.FLD_CHECK_DNG_EDIT_FLOOR, false, false); }
        public int FLD_OBJ_CNV_RESHND(int param1) { return CallFlowFunction(FlowFunction.FLD_OBJ_CNV_RESHND, false, false, param1); }
        public void FLD_MODEL_SET_ROTATE(int param1, float param2, float param3, float param4, int param5) { CallFlowFunction(FlowFunction.FLD_MODEL_SET_ROTATE, false, false, param1, param2, param3, param4, param5); }
        public void FLD_MODEL_ADD_ROTATE(int param1, float param2, float param3, float param4, int param5) { CallFlowFunction(FlowFunction.FLD_MODEL_ADD_ROTATE, false, false, param1, param2, param3, param4, param5); }
        public void FLD_OPEN_ORD_DOOR(int param1) { CallFlowFunction(FlowFunction.FLD_OPEN_ORD_DOOR, false, false, param1); }
        public int FLD_GET_ENEMY_NUM() { return CallFlowFunction(FlowFunction.FLD_GET_ENEMY_NUM, false, false); }
        public int FLD_GET_TBOX_TYPE() { return CallFlowFunction(FlowFunction.FLD_GET_TBOX_TYPE, false, false); }
        public void FLD_SETUP_MOVIE_TEX(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SETUP_MOVIE_TEX, false, false, param1, param2); }
        public void FLD_PLAY_MOVIE_TEX(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PLAY_MOVIE_TEX, false, false, param1, param2); }
        public void FLD_PAUSE_MOVIE_TEX(int param1) { CallFlowFunction(FlowFunction.FLD_PAUSE_MOVIE_TEX, false, false, param1); }
        public void FLD_SYNC_MOVIE_TEX(int param1) { CallFlowFunction(FlowFunction.FLD_SYNC_MOVIE_TEX, false, false, param1); }
        public void FLD_OPEN_TBOX() { CallFlowFunction(FlowFunction.FLD_OPEN_TBOX, false, false); }
        public void FLD_EFFECT_SET_HELPERID_POS(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_EFFECT_SET_HELPERID_POS, false, false, param1, param2, param3); }
        public int FLD_ENEMY_MODEL_LOAD(int param1) { return CallFlowFunction(FlowFunction.FLD_ENEMY_MODEL_LOAD, false, false, param1); }
        public int FLD_SYMBOL_MODEL_LOAD(int param1) { return CallFlowFunction(FlowFunction.FLD_SYMBOL_MODEL_LOAD, false, false, param1); }
        public void FLD_END_FLASHBACK() { CallFlowFunction(FlowFunction.FLD_END_FLASHBACK, false, false); }
        public int FLD_GET_ENCOUNT_ENEMY_ID(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GET_ENCOUNT_ENEMY_ID, false, false, param1, param2); }
        public int FLD_GET_ENCOUNT_ENEMY_NUM(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_ENCOUNT_ENEMY_NUM, false, false, param1); }
        public void CALL_TITLE() { CallFlowFunction(FlowFunction.CALL_TITLE, false, false); }
        public float FLD_MODEL_GET_X_ROTATE(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_X_ROTATE, false, false, param1); }
        public float FLD_MODEL_GET_Y_ROTATE(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_Y_ROTATE, false, false, param1); }
        public float FLD_MODEL_GET_Z_ROTATE(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_Z_ROTATE, false, false, param1); }
        public void FLD_MODEL_SYNC_ROTATE(int param1) { CallFlowFunction(FlowFunction.FLD_MODEL_SYNC_ROTATE, false, false, param1); }
        public int FLD_CAMERA_READ(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_CAMERA_READ, false, false, param1, param2, param3); }
        public void FLD_CAMERA_READ_SYNC(int param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_READ_SYNC, false, false, param1); }
        public void FLD_CAMERA_FREE(int param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_FREE, false, false, param1); }
        public void FLD_CAMERA_SET(int param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_SET, false, false, param1); }
        public void FLD_CAMERA_RESET() { CallFlowFunction(FlowFunction.FLD_CAMERA_RESET, false, false); }
        public void FLD_CAMERA_ANIM(int param1, int param2, int param3, int param4, float param5) { CallFlowFunction(FlowFunction.FLD_CAMERA_ANIM, false, false, param1, param2, param3, param4, param5); }
        public void FLD_CAMERA_ANIM_SYNC(int param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_ANIM_SYNC, false, false, param1); }
        public int FLD_SCRIPT_READ(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_SCRIPT_READ, true, false, param1, param2, param3); }
        public void FLD_SCRIPT_READ_SYNC(int param1) { CallFlowFunction(FlowFunction.FLD_SCRIPT_READ_SYNC, false, true, param1); }
        public void FLD_SCRIPT_FREE(int param1) { CallFlowFunction(FlowFunction.FLD_SCRIPT_FREE, false, true, param1); }
        public void FLD_SCRIPT_EXEC(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SCRIPT_EXEC, false, true, param1, param2); }
        public int FLD_SCRIPT_SEARCH(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_SCRIPT_SEARCH, false, false, param1, param2, param3); }
        public void FLD_CAMERA_SET_HELPERPOS(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_CAMERA_SET_HELPERPOS, false, false, param1, param2, param3); }
        public void FLD_UNIT_SET_EVT_WAIT(int param1) { CallFlowFunction(FlowFunction.FLD_UNIT_SET_EVT_WAIT, false, false, param1); }
        public int FLD_SEARCH_DNG_NEAR_QUEST() { return CallFlowFunction(FlowFunction.FLD_SEARCH_DNG_NEAR_QUEST, false, false); }
        public void FLD_GET_SCH_OBJ_BEGIN(int param1) { CallFlowFunction(FlowFunction.FLD_GET_SCH_OBJ_BEGIN, false, false, param1); }
        public void FLD_SET_DOF(float param1, float param2, float param3, float param4, float param5, int param6) { CallFlowFunction(FlowFunction.FLD_SET_DOF, false, false, param1, param2, param3, param4, param5, param6); }
        public void FLD_SET_DOF_DEFAULT(int param1) { CallFlowFunction(FlowFunction.FLD_SET_DOF_DEFAULT, false, false, param1); }
        public void FLD_GMC_LIGHT_ADD(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_GMC_LIGHT_ADD, false, false, param1, param2, param3, param4); }
        public void FLD_GMC_LIGHT_UPDATE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_GMC_LIGHT_UPDATE, false, false, param1, param2); }
        public int FLD_GMC_LIGHT_GET_UID(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GMC_LIGHT_GET_UID, false, false, param1, param2); }
        public int FLD_GMC_LIGHT_CTRL(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_GMC_LIGHT_CTRL, false, false, param1, param2, param3); }
        public void FLD_GMC_LIGHT_FAR_CAMERA(int param1, float param2, float param3, float param4, float param5, float param6, float param7, float param8) { CallFlowFunction(FlowFunction.FLD_GMC_LIGHT_FAR_CAMERA, false, false, param1, param2, param3, param4, param5, param6, param7, param8); }
        public void FLD_SET_HDR(float param1, float param2, float param3, int param4) { CallFlowFunction(FlowFunction.FLD_SET_HDR, false, false, param1, param2, param3, param4); }
        public void FLD_SET_HDR_STAR(int param1, float param2, float param3, float param4, float param5, int param6) { CallFlowFunction(FlowFunction.FLD_SET_HDR_STAR, false, false, param1, param2, param3, param4, param5, param6); }
        public void FLD_SET_HDR_DEFAULT(int param1) { CallFlowFunction(FlowFunction.FLD_SET_HDR_DEFAULT, false, false, param1); }
        public void FLD_SET_HDR_STAR_DEFAULT(int param1) { CallFlowFunction(FlowFunction.FLD_SET_HDR_STAR_DEFAULT, false, false, param1); }
        public void FLD_SWITCH_SET_POS(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SWITCH_SET_POS, false, false, param1, param2, param3); }
        public int FLD_GET_REST_COUNT(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_REST_COUNT, false, false, param1); }
        public int FLD_CHECK_USE_REST() { return CallFlowFunction(FlowFunction.FLD_CHECK_USE_REST, false, false); }
        public void FLD_USE_REST(int param1) { CallFlowFunction(FlowFunction.FLD_USE_REST, false, false, param1); }
        public void FLD_GET_SEED() { CallFlowFunction(FlowFunction.FLD_GET_SEED, false, false); }
        public void FLD_SET_CAMERA_COLLIS(int param1) { CallFlowFunction(FlowFunction.FLD_SET_CAMERA_COLLIS, false, false, param1); }
        public int FLD_CHECK_REST_ITEM(int param1) { return CallFlowFunction(FlowFunction.FLD_CHECK_REST_ITEM, false, false, param1); }
        public int FLD_GET_REST_ITEM_ID(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_REST_ITEM_ID, false, false, param1); }
        public void FLD_ROT_OBJ_CAMERA(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_ROT_OBJ_CAMERA, false, false, param1, param2); }
        public void FLD_PROHIBIT_ENEMY_PATH(int param1) { CallFlowFunction(FlowFunction.FLD_PROHIBIT_ENEMY_PATH, false, false, param1); }
        public void FLD_START_SUPPORT_MSG() { CallFlowFunction(FlowFunction.FLD_START_SUPPORT_MSG, false, false); }
        public int FLD_CHECK_DUNGEON() { return CallFlowFunction(FlowFunction.FLD_CHECK_DUNGEON, false, false); }
        public int FLD_CHECK_AT_DUNGEON() { return CallFlowFunction(FlowFunction.FLD_CHECK_AT_DUNGEON, false, false); }
        public void FLD_ROADMAP(int param1) { CallFlowFunction(FlowFunction.FLD_ROADMAP, false, false, param1); }
        public void FLD_CAMERA_INTERP(int param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_INTERP, false, false, param1); }
        public void FLD_CAMERA_SYNC_INTERP() { CallFlowFunction(FlowFunction.FLD_CAMERA_SYNC_INTERP, false, false); }
        public void FLD_PC_MODEL_ATTACH_ITEM(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_ATTACH_ITEM, false, false, param1, param2, param3); }
        public void FLD_PC_MODEL_DETACH_ITEM(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_DETACH_ITEM, false, false, param1, param2, param3); }
        public void FLD_PC_ATTACH_ITEM_VISIBLE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_PC_ATTACH_ITEM_VISIBLE, false, false, param1, param2, param3); }
        public void FLD_TEX_TEST(int param1) { CallFlowFunction(FlowFunction.FLD_TEX_TEST, false, false, param1); }
        public void FLD_TEX_TEST_END() { CallFlowFunction(FlowFunction.FLD_TEX_TEST_END, false, false); }
        public void FLD_CAMERA_SET_POS(float param1, float param2, float param3) { CallFlowFunction(FlowFunction.FLD_CAMERA_SET_POS, false, false, param1, param2, param3); }
        public void FLD_CAMERA_SET_ROT(float param1, float param2, float param3, float param4) { CallFlowFunction(FlowFunction.FLD_CAMERA_SET_ROT, false, false, param1, param2, param3, param4); }
        public void FLD_ROADMAP_OPEN(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_ROADMAP_OPEN, false, false, param1, param2, param3); }
        public void FLD_ROADMAP_CLOSE() { CallFlowFunction(FlowFunction.FLD_ROADMAP_CLOSE, false, false); }
        public void FLD_ROADMAP_SET_LAYER(int param1) { CallFlowFunction(FlowFunction.FLD_ROADMAP_SET_LAYER, false, false, param1); }
        public void FLD_ROADMAP_MASK_ON() { CallFlowFunction(FlowFunction.FLD_ROADMAP_MASK_ON, false, false); }
        public void FLD_ROADMAP_MASK_OFF() { CallFlowFunction(FlowFunction.FLD_ROADMAP_MASK_OFF, false, false); }
        public void FLD_ROADMAP_MASK_SETCLIP(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_ROADMAP_MASK_SETCLIP, false, false, param1, param2, param3); }
        public void FLD_CAMERA_LOCK_INTERP(float param1, float param2, float param3, float param4, float param5, float param6, float param7, int param8) { CallFlowFunction(FlowFunction.FLD_CAMERA_LOCK_INTERP, false, false, param1, param2, param3, param4, param5, param6, param7, param8); }
        public void FLD_CAMERA_LOCK_SYNC_INTERP() { CallFlowFunction(FlowFunction.FLD_CAMERA_LOCK_SYNC_INTERP, false, false); }
        public int FLD_EFFECT_START(int param1) { return CallFlowFunction(FlowFunction.FLD_EFFECT_START, false, false, param1); }
        public int FLD_GET_ALERT_VALUE() { return CallFlowFunction(FlowFunction.FLD_GET_ALERT_VALUE, false, false); }
        public void FLD_SET_ALERT_VALUE(int param1) { CallFlowFunction(FlowFunction.FLD_SET_ALERT_VALUE, false, false, param1); }
        public void FLD_CAMERA_SET_FIXED_COLLIS(int param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_SET_FIXED_COLLIS, false, false, param1); }
        public void FLD_NPC_MODEL_READPAUSE_CANCEL() { CallFlowFunction(FlowFunction.FLD_NPC_MODEL_READPAUSE_CANCEL, false, false); }
        public void FLD_CROWD_MODEL_READPAUSE_CANCEL() { CallFlowFunction(FlowFunction.FLD_CROWD_MODEL_READPAUSE_CANCEL, false, false); }
        public void FLD_SET_ENEMY_ENCOUNT_NO(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SET_ENEMY_ENCOUNT_NO, false, false, param1, param2, param3); }
        public void FLD_PROHIBIT_ENEMY_AREA(int param1) { CallFlowFunction(FlowFunction.FLD_PROHIBIT_ENEMY_AREA, false, false, param1); }
        public void FLD_SET_SUMMON_LIFE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SET_SUMMON_LIFE, false, false, param1, param2, param3); }
        public void FLD_ROADMAP_SYNC() { CallFlowFunction(FlowFunction.FLD_ROADMAP_SYNC, false, false); }
        public void FLD_REQ_BGM() { CallFlowFunction(FlowFunction.FLD_REQ_BGM, false, false); }
        public void FLD_SET_ENEMY_IGNORE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SET_ENEMY_IGNORE, false, false, param1, param2, param3); }
        public void FLD_START_SMK_BALL(int param1) { CallFlowFunction(FlowFunction.FLD_START_SMK_BALL, false, false, param1); }
        public void FLD_SET_ATDNG_SHOP_EFF(int param1) { CallFlowFunction(FlowFunction.FLD_SET_ATDNG_SHOP_EFF, false, false, param1); }
        public int FLD_REQ_ATDNG_SHOP_ENTER() { return CallFlowFunction(FlowFunction.FLD_REQ_ATDNG_SHOP_ENTER, false, false); }
        public int FLD_SUMMON_ENEMY(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_SUMMON_ENEMY, false, false, param1, param2); }
        public void FLD_MODEL_SET_TRANSLATE(int param1, float param2, float param3, float param4, int param5) { CallFlowFunction(FlowFunction.FLD_MODEL_SET_TRANSLATE, false, false, param1, param2, param3, param4, param5); }
        public void FLD_MODEL_ADD_TRANSLATE(int param1, float param2, float param3, float param4, int param5) { CallFlowFunction(FlowFunction.FLD_MODEL_ADD_TRANSLATE, false, false, param1, param2, param3, param4, param5); }
        public void FLD_MODEL_PATH_TRANSLATE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_MODEL_PATH_TRANSLATE, false, false, param1, param2, param3); }
        public void FLD_MODEL_SYNC_TRANSLATE(int param1) { CallFlowFunction(FlowFunction.FLD_MODEL_SYNC_TRANSLATE, false, false, param1); }
        public int FLD_LOAD_PATH_DATA(int param1) { return CallFlowFunction(FlowFunction.FLD_LOAD_PATH_DATA, false, false, param1); }
        public void FLD_SYNC_PATH_DATA(int param1) { CallFlowFunction(FlowFunction.FLD_SYNC_PATH_DATA, false, false, param1); }
        public void FLD_FREE_PATH_DATA(int param1) { CallFlowFunction(FlowFunction.FLD_FREE_PATH_DATA, false, false, param1); }
        public int FLD_CHECK_DEBUG_FLAG() { return CallFlowFunction(FlowFunction.FLD_CHECK_DEBUG_FLAG, false, false); }
        public int FLD_NPC_SEARCH_RESHND(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_NPC_SEARCH_RESHND, false, false, param1, param2, param3); }
        public void FLD_WIRE_OBJ_ENABLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_WIRE_OBJ_ENABLE, false, false, param1, param2); }
        public void FLD_GET_SCH_OBJ_COIN() { CallFlowFunction(FlowFunction.FLD_GET_SCH_OBJ_COIN, false, false); }
        public void FLD_SET_CELLPHONE(int param1) { CallFlowFunction(FlowFunction.FLD_SET_CELLPHONE, false, false, param1); }
        public void FLD_PANEL_DISP(int param1) { CallFlowFunction(FlowFunction.FLD_PANEL_DISP, false, false, param1); }
        public void FLD_EFFECT_BANK_LOAD(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_EFFECT_BANK_LOAD, false, false, param1, param2); }
        public int FLD_EFFECT_BANK_SYNC(int param1) { return CallFlowFunction(FlowFunction.FLD_EFFECT_BANK_SYNC, false, false, param1); }
        public void FLD_EFFECT_BANK_FREE(int param1) { CallFlowFunction(FlowFunction.FLD_EFFECT_BANK_FREE, false, false, param1); }
        public int FLD_EFFECT_BANK_START(int param1) { return CallFlowFunction(FlowFunction.FLD_EFFECT_BANK_START, false, false, param1); }
        public void FLD_EFFECT_END(int param1) { CallFlowFunction(FlowFunction.FLD_EFFECT_END, false, false, param1); }
        public void FLD_EFFECT_FADE_OUT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_EFFECT_FADE_OUT, false, false, param1, param2); }
        public void FLD_EFFECT_SET_POS(int param1, float param2, float param3, float param4) { CallFlowFunction(FlowFunction.FLD_EFFECT_SET_POS, false, false, param1, param2, param3, param4); }
        public void FLD_EFFECT_SET_RES_POS(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_EFFECT_SET_RES_POS, false, false, param1, param2); }
        public void FLD_EFFECT_SET_ROT(int param1, float param2, float param3, float param4) { CallFlowFunction(FlowFunction.FLD_EFFECT_SET_ROT, false, false, param1, param2, param3, param4); }
        public void FLD_EFFECT_SET_RES_ROT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_EFFECT_SET_RES_ROT, false, false, param1, param2); }
        public void FLD_EFFECT_SET_SCALE(int param1, float param2, float param3, float param4) { CallFlowFunction(FlowFunction.FLD_EFFECT_SET_SCALE, false, false, param1, param2, param3, param4); }
        public void FLD_EFFECT_SET_ALPHA(int param1, float param2) { CallFlowFunction(FlowFunction.FLD_EFFECT_SET_ALPHA, false, false, param1, param2); }
        public void FLD_EFFECT_SET_SPEED(int param1, float param2) { CallFlowFunction(FlowFunction.FLD_EFFECT_SET_SPEED, false, false, param1, param2); }
        public void FLD_SEARCH_EFFECT_ON() { CallFlowFunction(FlowFunction.FLD_SEARCH_EFFECT_ON, false, false); }
        public void FLD_SEARCH_EFFECT_OFF() { CallFlowFunction(FlowFunction.FLD_SEARCH_EFFECT_OFF, false, false); }
        public int FLD_SEARCH_EFFECT_CHECK() { return CallFlowFunction(FlowFunction.FLD_SEARCH_EFFECT_CHECK, false, false); }
        public void FLD_PANEL_HIDE_DISABLE() { CallFlowFunction(FlowFunction.FLD_PANEL_HIDE_DISABLE, false, false); }
        public void FLD_CLEAR_SUMMON_ENEMY_ALL() { CallFlowFunction(FlowFunction.FLD_CLEAR_SUMMON_ENEMY_ALL, false, false); }
        public void FLD_MODEL_RELATE_TRANSLATE(int param1, int param2, float param3, float param4, float param5, int param6) { CallFlowFunction(FlowFunction.FLD_MODEL_RELATE_TRANSLATE, false, false, param1, param2, param3, param4, param5, param6); }
        public float FLD_MODEL_GET_X_TRANSLATE(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_X_TRANSLATE, false, false, param1); }
        public float FLD_MODEL_GET_Y_TRANSLATE(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_Y_TRANSLATE, false, false, param1); }
        public float FLD_MODEL_GET_Z_TRANSLATE(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_Z_TRANSLATE, false, false, param1); }
        public void FLD_MODEL_ORIENT_ROTATE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_MODEL_ORIENT_ROTATE, false, false, param1, param2, param3); }
        public int FLD_GET_POS_INDEX() { return CallFlowFunction(FlowFunction.FLD_GET_POS_INDEX, false, false); }
        public void FLD_CAMERA_LOOKAT_INTERP(float param1, float param2, float param3, int param4) { CallFlowFunction(FlowFunction.FLD_CAMERA_LOOKAT_INTERP, false, false, param1, param2, param3, param4); }
        public void FLD_CAMERA_FOVY_INTERP(float param1, int param2) { CallFlowFunction(FlowFunction.FLD_CAMERA_FOVY_INTERP, false, false, param1, param2); }
        public void FLD_MODEL_SET_VISIBLE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_MODEL_SET_VISIBLE, false, false, param1, param2, param3); }
        public void FLD_MODEL_SYNC_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_MODEL_SYNC_VISIBLE, false, false, param1); }
        public void FLD_PTY_MODEL_SET_VISIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PTY_MODEL_SET_VISIBLE, false, false, param1, param2); }
        public void FLD_PTY_MODEL_SYNC_VISIBLE() { CallFlowFunction(FlowFunction.FLD_PTY_MODEL_SYNC_VISIBLE, false, false); }
        public void FLD_EMY_MODEL_SET_VISIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_EMY_MODEL_SET_VISIBLE, false, false, param1, param2); }
        public void FLD_EMY_MODEL_SYNC_VISIBLE() { CallFlowFunction(FlowFunction.FLD_EMY_MODEL_SYNC_VISIBLE, false, false); }
        public void FLD_START_FADE_DISABLE() { CallFlowFunction(FlowFunction.FLD_START_FADE_DISABLE, false, false); }
        public int FLD_GET_SCH_OBJ_ITEM(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_SCH_OBJ_ITEM, false, false, param1); }
        public float FLD_MODEL_GET_DISTANCE(int param1, int param2) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_DISTANCE, false, false, param1, param2); }
        public float FLD_MODEL_GET_DIFF_X_ANGLE(int param1, int param2) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_DIFF_X_ANGLE, false, false, param1, param2); }
        public float FLD_MODEL_GET_DIFF_Y_ANGLE(int param1, int param2) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_DIFF_Y_ANGLE, false, false, param1, param2); }
        public float FLD_MODEL_GET_DIFF_Z_ANGLE(int param1, int param2) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_DIFF_Z_ANGLE, false, false, param1, param2); }
        public float FLD_CAMERA_GET_X_POS() { return CallFloatFlowFunction(FlowFunction.FLD_CAMERA_GET_X_POS, false, false); }
        public float FLD_CAMERA_GET_Y_POS() { return CallFloatFlowFunction(FlowFunction.FLD_CAMERA_GET_Y_POS, false, false); }
        public float FLD_CAMERA_GET_Z_POS() { return CallFloatFlowFunction(FlowFunction.FLD_CAMERA_GET_Z_POS, false, false); }
        public float FLD_CAMERA_GET_X_ROT() { return CallFloatFlowFunction(FlowFunction.FLD_CAMERA_GET_X_ROT, false, false); }
        public float FLD_CAMERA_GET_Y_ROT() { return CallFloatFlowFunction(FlowFunction.FLD_CAMERA_GET_Y_ROT, false, false); }
        public float FLD_CAMERA_GET_Z_ROT() { return CallFloatFlowFunction(FlowFunction.FLD_CAMERA_GET_Z_ROT, false, false); }
        public float FLD_CAMERA_GET_W_ROT() { return CallFloatFlowFunction(FlowFunction.FLD_CAMERA_GET_W_ROT, false, false); }
        public float FLD_CAMERA_GET_FOVY() { return CallFloatFlowFunction(FlowFunction.FLD_CAMERA_GET_FOVY, false, false); }
        public void FLD_NPC_RELOAD() { CallFlowFunction(FlowFunction.FLD_NPC_RELOAD, false, false); }
        public int FLD_GET_SCH_OBJ_FIX_ITEM(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_SCH_OBJ_FIX_ITEM, false, false, param1); }
        public int FLD_CHECK_FIND_SOMETHING() { return CallFlowFunction(FlowFunction.FLD_CHECK_FIND_SOMETHING, false, false); }
        public void FLD_PTY_FOLLOW_ENABLE(int param1) { CallFlowFunction(FlowFunction.FLD_PTY_FOLLOW_ENABLE, false, false, param1); }
        public void FLD_CAMERA_SET_FIXED(float param1, float param2, float param3, float param4, float param5, float param6, float param7) { CallFlowFunction(FlowFunction.FLD_CAMERA_SET_FIXED, false, false, param1, param2, param3, param4, param5, param6, param7); }
        public void FLD_SCH_OBJ_VISIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SCH_OBJ_VISIBLE, false, false, param1, param2); }
        public void FLD_START_BOSS(int param1) { CallFlowFunction(FlowFunction.FLD_START_BOSS, false, false, param1); }
        public void FLD_RETRY_CLEAR() { CallFlowFunction(FlowFunction.FLD_RETRY_CLEAR, false, false); }
        public void FLD_RETRY_BOSS_SAVE() { CallFlowFunction(FlowFunction.FLD_RETRY_BOSS_SAVE, false, false); }
        public void FLD_RETRY_BOSS_LOAD() { CallFlowFunction(FlowFunction.FLD_RETRY_BOSS_LOAD, false, false); }
        public void FLD_RETRY_BOSS_CLEAR() { CallFlowFunction(FlowFunction.FLD_RETRY_BOSS_CLEAR, false, false); }
        public int FLD_GET_PREV_MAJOR() { return CallFlowFunction(FlowFunction.FLD_GET_PREV_MAJOR, false, false); }
        public int FLD_GET_PREV_MINOR() { return CallFlowFunction(FlowFunction.FLD_GET_PREV_MINOR, false, false); }
        public int FLD_GET_PREV_POS_INDEX() { return CallFlowFunction(FlowFunction.FLD_GET_PREV_POS_INDEX, false, false); }
        public void FLD_CAMERA_BEHIND_LOCK() { CallFlowFunction(FlowFunction.FLD_CAMERA_BEHIND_LOCK, false, false); }
        public void FLD_CAMERA_BEHIND_UNLOCK() { CallFlowFunction(FlowFunction.FLD_CAMERA_BEHIND_UNLOCK, false, false); }
        public void FLD_CAMERA_SET_PARAM(float param1, float param2, float param3, float param4, float param5, float param6, int param7) { CallFlowFunction(FlowFunction.FLD_CAMERA_SET_PARAM, false, false, param1, param2, param3, param4, param5, param6, param7); }
        public void FLD_CAMERA_RESET_PARAM(int param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_RESET_PARAM, false, false, param1); }
        public void FLD_SET_COVER_STATE() { CallFlowFunction(FlowFunction.FLD_SET_COVER_STATE, false, false); }
        public void FLD_EFFECT_ATTACH_MODEL(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_EFFECT_ATTACH_MODEL, false, false, param1, param2); }
        public int FLD_PC_ID_GET_RESHND(int param1) { return CallFlowFunction(FlowFunction.FLD_PC_ID_GET_RESHND, false, false, param1); }
        public int FLD_PC_ID_CHECK_RESHND(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_PC_ID_CHECK_RESHND, false, false, param1, param2); }
        public void FLD_PAUSE_ENEMY_MOVE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PAUSE_ENEMY_MOVE, false, false, param1, param2); }
        public void FLD_RESUME_ENEMY_MOVE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_RESUME_ENEMY_MOVE, false, false, param1, param2); }
        public void FLD_MODEL_FREE(int param1) { CallFlowFunction(FlowFunction.FLD_MODEL_FREE, false, false, param1); }
        public void CALL_AT_DUNGEON(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.CALL_AT_DUNGEON, false, false, param1, param2, param3); }
        public int FLD_GET_DOOR_DIR() { return CallFlowFunction(FlowFunction.FLD_GET_DOOR_DIR, false, false); }
        public void FLD_MISSION_LIST_ON() { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_ON, false, false); }
        public void FLD_MISSION_LIST_OFF() { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_OFF, false, false); }
        public void FLD_MODEL_WALK_TRANSLATE(int param1, float param2, float param3, float param4) { CallFlowFunction(FlowFunction.FLD_MODEL_WALK_TRANSLATE, false, false, param1, param2, param3, param4); }
        public void FLD_MODEL_RUN_TRANSLATE(int param1, float param2, float param3, float param4) { CallFlowFunction(FlowFunction.FLD_MODEL_RUN_TRANSLATE, false, false, param1, param2, param3, param4); }
        public int FLD_MODEL_ADDMOTION_LOAD(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_MODEL_ADDMOTION_LOAD, false, false, param1, param2); }
        public void FLD_MODEL_COPY_POSE_ANIM(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_MODEL_COPY_POSE_ANIM, false, false, param1, param2); }
        public int FLD_MODEL_CLONE_ADDMOTION(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_MODEL_CLONE_ADDMOTION, false, false, param1, param2); }
        public void FLD_MODEL_REVERT_ADDMOTION(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_MODEL_REVERT_ADDMOTION, false, false, param1, param2); }
        public void FLD_START_BGM_DISABLE() { CallFlowFunction(FlowFunction.FLD_START_BGM_DISABLE, false, false); }
        public void FLD_MODEL_POINT_ROTATE(int param1, float param2, float param3, float param4, int param5) { CallFlowFunction(FlowFunction.FLD_MODEL_POINT_ROTATE, false, false, param1, param2, param3, param4, param5); }
        public int FLD_ENCOUNT_SYMBOL(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_ENCOUNT_SYMBOL, false, false, param1, param2, param3); }
        public int FLD_SEARCH_CLOSEST_ENEMY() { return CallFlowFunction(FlowFunction.FLD_SEARCH_CLOSEST_ENEMY, false, false); }
        public int FLD_GET_WANTED_POINT() { return CallFlowFunction(FlowFunction.FLD_GET_WANTED_POINT, false, false); }
        public void FLD_SET_WANTED_POINT(int param1) { CallFlowFunction(FlowFunction.FLD_SET_WANTED_POINT, false, false, param1); }
        public void FLD_ADD_WANTED_POINT(int param1) { CallFlowFunction(FlowFunction.FLD_ADD_WANTED_POINT, false, false, param1); }
        public int FLD_ENCOUNT_SYMBOL_FADE(int param1, int param2, int param3, int param4, int param5) { return CallFlowFunction(FlowFunction.FLD_ENCOUNT_SYMBOL_FADE, false, false, param1, param2, param3, param4, param5); }
        public int CALL_LMAP(int param1) { return CallFlowFunction(FlowFunction.CALL_LMAP, false, false, param1); }
        public void FLD_START_FADE_SYNC() { CallFlowFunction(FlowFunction.FLD_START_FADE_SYNC, false, false); }
        public int FLD_NPC_MODEL_LOAD_BASE(int param1, int param2, int param3, int param4) { return CallFlowFunction(FlowFunction.FLD_NPC_MODEL_LOAD_BASE, false, false, param1, param2, param3, param4); }
        public int FLD_DNG_CHK_ACCIDENT(int param1) { return CallFlowFunction(FlowFunction.FLD_DNG_CHK_ACCIDENT, false, false, param1); }
        public int FLD_ENCOUNT_SYMBOL_CLOSE(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_ENCOUNT_SYMBOL_CLOSE, false, false, param1, param2, param3); }
        public int FLD_CHECK_BOSS() { return CallFlowFunction(FlowFunction.FLD_CHECK_BOSS, false, false); }
        public void FLD_WEAPON_MODEL_VISIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_WEAPON_MODEL_VISIBLE, false, false, param1, param2); }
        public void FLD_GUN_MODEL_VISIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_GUN_MODEL_VISIBLE, false, false, param1, param2); }
        public void FLD_CELLPHONE_MODEL_VISIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_CELLPHONE_MODEL_VISIBLE, false, false, param1, param2); }
        public void FLD_BAG_MODEL_VISIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_BAG_MODEL_VISIBLE, false, false, param1, param2); }
        public void FLD_UMBRELLA_MODEL_VISIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_UMBRELLA_MODEL_VISIBLE, false, false, param1, param2); }
        public void FLD_SET_LMAP_POS(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SET_LMAP_POS, false, false, param1, param2); }
        public int FLD_GET_ENEMY_RESHND(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GET_ENEMY_RESHND, false, false, param1, param2); }
        public void FLD_TUTORIAL_OK_ONLY() { CallFlowFunction(FlowFunction.FLD_TUTORIAL_OK_ONLY, false, false); }
        public int FLD_CLOSE_DOOR_NO(int param1) { return CallFlowFunction(FlowFunction.FLD_CLOSE_DOOR_NO, false, false, param1); }
        public void FLD_LOCAL_FLAG_ON(int param1) { CallFlowFunction(FlowFunction.FLD_LOCAL_FLAG_ON, false, false, param1); }
        public void FLD_LOCAL_FLAG_OFF(int param1) { CallFlowFunction(FlowFunction.FLD_LOCAL_FLAG_OFF, false, false, param1); }
        public int FLD_LOCAL_FLAG_CHK(int param1) { return CallFlowFunction(FlowFunction.FLD_LOCAL_FLAG_CHK, false, false, param1); }
        public void FLD_REQ_SCN_CHANGE(int param1) { CallFlowFunction(FlowFunction.FLD_REQ_SCN_CHANGE, false, false, param1); }
        public void FLD_MODEL_TRANSLATION_KEY(int param1) { CallFlowFunction(FlowFunction.FLD_MODEL_TRANSLATION_KEY, false, false, param1); }
        public void FLD_HIT_SET_TYPE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_HIT_SET_TYPE, false, false, param1, param2, param3); }
        public void FLD_HIT_RESET_TYPE(int param1) { CallFlowFunction(FlowFunction.FLD_HIT_RESET_TYPE, false, false, param1); }
        public int FLD_HIT_GET_TYPE(int param1) { return CallFlowFunction(FlowFunction.FLD_HIT_GET_TYPE, false, false, param1); }
        public int FLD_HIT_GET_NAMEID(int param1) { return CallFlowFunction(FlowFunction.FLD_HIT_GET_NAMEID, false, false, param1); }
        public void FLD_SOBJHIT_SET_TYPE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SOBJHIT_SET_TYPE, false, false, param1, param2, param3); }
        public void FLD_SOBJHIT_RESET_TYPE(int param1) { CallFlowFunction(FlowFunction.FLD_SOBJHIT_RESET_TYPE, false, false, param1); }
        public int FLD_SOBJHIT_GET_TYPE(int param1) { return CallFlowFunction(FlowFunction.FLD_SOBJHIT_GET_TYPE, false, false, param1); }
        public int FLD_SOBJHIT_GET_NAMEID(int param1) { return CallFlowFunction(FlowFunction.FLD_SOBJHIT_GET_NAMEID, false, false, param1); }
        public void FLD_PLACE_NAME_SET_NO(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PLACE_NAME_SET_NO, false, false, param1, param2); }
        public int FLD_NPC_SEARCH_RESHND2(int param1, int param2, int param3, int param4) { return CallFlowFunction(FlowFunction.FLD_NPC_SEARCH_RESHND2, false, false, param1, param2, param3, param4); }
        public void FLD_NPC_REMOVE(int param1) { CallFlowFunction(FlowFunction.FLD_NPC_REMOVE, false, false, param1); }
        public void FLD_NPC_STOP_CHASE(int param1) { CallFlowFunction(FlowFunction.FLD_NPC_STOP_CHASE, false, false, param1); }
        public int FLD_NPC_CHECK_CHASE(int param1) { return CallFlowFunction(FlowFunction.FLD_NPC_CHECK_CHASE, false, false, param1); }
        public void FLD_CAMERA_ZOOM(int param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_ZOOM, false, false, param1); }
        public void FLD_PLACENAME_TEX(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_PLACENAME_TEX, false, false, param1, param2, param3, param4); }
        public void FLD_NPC_START_CHASE(int param1) { CallFlowFunction(FlowFunction.FLD_NPC_START_CHASE, false, false, param1); }
        public void FLD_UNIT_SET_COLLIS(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_UNIT_SET_COLLIS, false, false, param1, param2); }
        public int FLD_NOT_OPEN_DOOR() { return CallFlowFunction(FlowFunction.FLD_NOT_OPEN_DOOR, false, false); }
        public int FLD_OPEN_DOOR_FADE() { return CallFlowFunction(FlowFunction.FLD_OPEN_DOOR_FADE, false, false); }
        public void FLD_NPC_SET_LOOKAT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_SET_LOOKAT, false, false, param1, param2); }
        public void FLD_OPEN_TBOX_SIMPLE() { CallFlowFunction(FlowFunction.FLD_OPEN_TBOX_SIMPLE, false, false); }
        public void FLD_SET_DIVDATA(int param1) { CallFlowFunction(FlowFunction.FLD_SET_DIVDATA, false, false, param1); }
        public int FLD_GET_DIVDATA() { return CallFlowFunction(FlowFunction.FLD_GET_DIVDATA, false, false); }
        public void FLD_UPDATE_DIVDATA() { CallFlowFunction(FlowFunction.FLD_UPDATE_DIVDATA, false, false); }
        public int FLD_GET_SCH_OBJ_RND_ITEM(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GET_SCH_OBJ_RND_ITEM, false, false, param1, param2); }
        public void FLD_MODEL_UNIT_TRANSLATE(int param1, float param2, float param3, float param4, int param5) { CallFlowFunction(FlowFunction.FLD_MODEL_UNIT_TRANSLATE, false, false, param1, param2, param3, param4, param5); }
        public int FLD_OPEN_FRIDGE(int param1) { return CallFlowFunction(FlowFunction.FLD_OPEN_FRIDGE, false, false, param1); }
        public void FLD_CLOSE_FRIDGE(int param1) { CallFlowFunction(FlowFunction.FLD_CLOSE_FRIDGE, false, false, param1); }
        public void FLD_NPC_PRGANIM(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_PRGANIM, false, false, param1, param2); }
        public int FLD_PC_GET_CURRENT_RESHND(int param1) { return CallFlowFunction(FlowFunction.FLD_PC_GET_CURRENT_RESHND, false, false, param1); }
        public int FLD_NPCID_SEARCH_RESHND(int param1) { return CallFlowFunction(FlowFunction.FLD_NPCID_SEARCH_RESHND, false, false, param1); }
        public int FLD_NPCID_SEARCH_RESHND2(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_NPCID_SEARCH_RESHND2, false, false, param1, param2); }
        public int FLD_GET_DIV_INDEX() { return CallFlowFunction(FlowFunction.FLD_GET_DIV_INDEX, false, false); }
        public int FLD_GET_PREV_DIV_INDEX() { return CallFlowFunction(FlowFunction.FLD_GET_PREV_DIV_INDEX, false, false); }
        public void FLD_SWITCH_ON(int param1) { CallFlowFunction(FlowFunction.FLD_SWITCH_ON, false, false, param1); }
        public void FLD_GET_SCH_OBJ_END() { CallFlowFunction(FlowFunction.FLD_GET_SCH_OBJ_END, false, false); }
        public float FLD_POS_GET_X_POS(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_POS_GET_X_POS, false, false, param1); }
        public float FLD_POS_GET_Y_POS(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_POS_GET_Y_POS, false, false, param1); }
        public float FLD_POS_GET_Z_POS(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_POS_GET_Z_POS, false, false, param1); }
        public void FLD_SFTYROOM_MENU() { CallFlowFunction(FlowFunction.FLD_SFTYROOM_MENU, false, false); }
        public void FLD_SFTYROOM_MENU_SYNC() { CallFlowFunction(FlowFunction.FLD_SFTYROOM_MENU_SYNC, false, false); }
        public void FLD_SFTYROOM_MENU_EXIT() { CallFlowFunction(FlowFunction.FLD_SFTYROOM_MENU_EXIT, false, false); }
        public void FLD_SFTYROOM_MENU_SETMASK(int param1) { CallFlowFunction(FlowFunction.FLD_SFTYROOM_MENU_SETMASK, false, false, param1); }
        public void FLD_GREETING_MSG(int param1) { CallFlowFunction(FlowFunction.FLD_GREETING_MSG, false, false, param1); }
        public void FLD_GREETING_MSGSYNC(int param1) { CallFlowFunction(FlowFunction.FLD_GREETING_MSGSYNC, false, false, param1); }
        public void FLD_GREETING_FREE() { CallFlowFunction(FlowFunction.FLD_GREETING_FREE, false, false); }
        public int FLD_NPC_GET_DISTANCE() { return CallFlowFunction(FlowFunction.FLD_NPC_GET_DISTANCE, false, false); }
        public void FLD_CAMERA_INTERP_SMOOTH(int param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_INTERP_SMOOTH, false, false, param1); }
        public void CALL_KF_EVENT(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.CALL_KF_EVENT, false, false, param1, param2, param3, param4); }
        public int FLD_CHECK_MORGANA_BAG() { return CallFlowFunction(FlowFunction.FLD_CHECK_MORGANA_BAG, false, false); }
        public void FLD_PC_COVER_RUN(int param1, float param2, float param3, float param4) { CallFlowFunction(FlowFunction.FLD_PC_COVER_RUN, false, false, param1, param2, param3, param4); }
        public void FLD_PC_SYNC_COVER_RUN(int param1) { CallFlowFunction(FlowFunction.FLD_PC_SYNC_COVER_RUN, false, false, param1); }
        public int FLD_SNUFF_GET_RESULT() { return CallFlowFunction(FlowFunction.FLD_SNUFF_GET_RESULT, false, false); }
        public void FLD_PTY_MODEL_SET_STD_POS() { CallFlowFunction(FlowFunction.FLD_PTY_MODEL_SET_STD_POS, false, false); }
        public void FLD_CAMERA_TUMBLE_INTERP(float param1, float param2, float param3, float param4, float param5, float param6, int param7) { CallFlowFunction(FlowFunction.FLD_CAMERA_TUMBLE_INTERP, false, false, param1, param2, param3, param4, param5, param6, param7); }
        public void FLD_PTY_MODEL_SET_PAUSE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PTY_MODEL_SET_PAUSE, false, false, param1, param2); }
        public void FLD_DUNGEON_RESULT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_DUNGEON_RESULT, false, false, param1, param2); }
        public void FLD_DUNGEON_RESULT_SYNC() { CallFlowFunction(FlowFunction.FLD_DUNGEON_RESULT_SYNC, false, false); }
        public void FLD_CROWD_SET_MESSAGE(int param1, int param2, float param3) { CallFlowFunction(FlowFunction.FLD_CROWD_SET_MESSAGE, false, false, param1, param2, param3); }
        public void FLD_CAMERA_HIT_UPDATE() { CallFlowFunction(FlowFunction.FLD_CAMERA_HIT_UPDATE, false, false); }
        public void FLD_UNIT_WAIT_DISABLE(int param1) { CallFlowFunction(FlowFunction.FLD_UNIT_WAIT_DISABLE, false, false, param1); }
        public void FLD_SFTYROOM_SET_CAMERA(int param1) { CallFlowFunction(FlowFunction.FLD_SFTYROOM_SET_CAMERA, false, false, param1); }
        public void FLD_SFTYROOM_MENU_SETHELP(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SFTYROOM_MENU_SETHELP, false, false, param1, param2); }
        public void FLD_BG_TRANSKEY_SYNC() { CallFlowFunction(FlowFunction.FLD_BG_TRANSKEY_SYNC, false, false); }
        public void FLD_RESET_SCH_OBJ_FLAG(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_RESET_SCH_OBJ_FLAG, false, false, param1, param2); }
        public void FLD_PC_MODEL_ACTION(float param1, float param2, float param3, int param4) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_ACTION, false, false, param1, param2, param3, param4); }
        public void FLD_NPC_ROTATE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_NPC_ROTATE, false, false, param1, param2, param3); }
        public void FLD_NPC_ROTATE_RESET(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_ROTATE_RESET, false, false, param1, param2); }
        public void FLD_NPC_ROTATE_SYNC(int param1) { CallFlowFunction(FlowFunction.FLD_NPC_ROTATE_SYNC, false, false, param1); }
        public void FLD_EFFECT_SYNC(int param1) { CallFlowFunction(FlowFunction.FLD_EFFECT_SYNC, false, false, param1); }
        public int FLD_CHOICE_REPORTER() { return CallFlowFunction(FlowFunction.FLD_CHOICE_REPORTER, false, false); }
        public int FLD_PC_GET_ID(int param1) { return CallFlowFunction(FlowFunction.FLD_PC_GET_ID, false, false, param1); }
        public void FLD_UNIT_SET_WAIT(int param1) { CallFlowFunction(FlowFunction.FLD_UNIT_SET_WAIT, false, false, param1); }
        public void FLD_SET_TBOX_VISIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SET_TBOX_VISIBLE, false, false, param1, param2); }
        public void FLD_OVERTURN_TAG(int param1) { CallFlowFunction(FlowFunction.FLD_OVERTURN_TAG, false, false, param1); }
        public void FLD_SMP_EVENT_BEGIN(int param1) { CallFlowFunction(FlowFunction.FLD_SMP_EVENT_BEGIN, false, false, param1); }
        public void FLD_SMP_EVENT_END(int param1) { CallFlowFunction(FlowFunction.FLD_SMP_EVENT_END, false, false, param1); }
        public void FLD_MISSION_LIST_INVISALL() { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_INVISALL, false, false); }
        public void FLD_MISSION_LIST_VISITEM(int param1) { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_VISITEM, false, false, param1); }
        public void FLD_MISSION_LIST_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_VISIBLE, false, false, param1); }
        public void FLD_MISSION_LIST_INVIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_INVIBLE, false, false, param1, param2); }
        public void FLD_MISSION_LIST_SYNC_VIS() { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_SYNC_VIS, false, false); }
        public int FLD_GET_REPORTER() { return CallFlowFunction(FlowFunction.FLD_GET_REPORTER, false, false); }
        public int FLD_GET_FOUND_ENEMY_TYPE(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_FOUND_ENEMY_TYPE, false, false, param1); }
        public void FLD_CAMERA_SET_FIXED_REVERT(float param1, float param2, float param3, float param4, float param5, float param6, float param7, int param8) { CallFlowFunction(FlowFunction.FLD_CAMERA_SET_FIXED_REVERT, false, false, param1, param2, param3, param4, param5, param6, param7, param8); }
        public void FLD_ALERT_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_ALERT_VISIBLE, false, false, param1); }
        public int FLD_ALERT_GET_VISIBLE() { return CallFlowFunction(FlowFunction.FLD_ALERT_GET_VISIBLE, false, false); }
        public int FLD_TUTORIAL_COVER_RUN() { return CallFlowFunction(FlowFunction.FLD_TUTORIAL_COVER_RUN, false, false); }
        public int FLD_NPC_GET_CURRENT_PATHNODE(int param1) { return CallFlowFunction(FlowFunction.FLD_NPC_GET_CURRENT_PATHNODE, false, false, param1); }
        public void FLD_NPC_STOP_PATHNODE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_STOP_PATHNODE, false, false, param1, param2); }
        public void FLD_GET_STAMP() { CallFlowFunction(FlowFunction.FLD_GET_STAMP, false, false); }
        public void FLD_EXIT_DUNGEON() { CallFlowFunction(FlowFunction.FLD_EXIT_DUNGEON, false, false); }
        public void FLD_TOOL_CREATE() { CallFlowFunction(FlowFunction.FLD_TOOL_CREATE, false, false); }
        public void FLD_TOOL_CREATE_SYNC() { CallFlowFunction(FlowFunction.FLD_TOOL_CREATE_SYNC, false, false); }
        public int FLD_PERSONA_MODEL_LOAD(int param1) { return CallFlowFunction(FlowFunction.FLD_PERSONA_MODEL_LOAD, false, false, param1); }
        public void FLD_TOOL_SCR_YESNO(int param1) { CallFlowFunction(FlowFunction.FLD_TOOL_SCR_YESNO, false, false, param1); }
        public int FLD_TOOL_GET_ELEMENTID() { return CallFlowFunction(FlowFunction.FLD_TOOL_GET_ELEMENTID, false, false); }
        public void FLD_PTY_MODEL_SET_HIDE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PTY_MODEL_SET_HIDE, false, false, param1, param2); }
        public void FLD_EXIT_TIME_DISP() { CallFlowFunction(FlowFunction.FLD_EXIT_TIME_DISP, false, false); }
        public void FLD_SYNC_TIME_DISP() { CallFlowFunction(FlowFunction.FLD_SYNC_TIME_DISP, false, false); }
        public void SAVE_TEMPORARY() { CallFlowFunction(FlowFunction.SAVE_TEMPORARY, false, false); }
        public int LOAD_TEMPORARY() { return CallFlowFunction(FlowFunction.LOAD_TEMPORARY, false, false); }
        public void FLD_NPC_SET_RUNSTATE(int param1, float param2) { CallFlowFunction(FlowFunction.FLD_NPC_SET_RUNSTATE, false, false, param1, param2); }
        public void FLD_RAIN_PAUSE(int param1) { CallFlowFunction(FlowFunction.FLD_RAIN_PAUSE, false, false, param1); }
        public void FLD_NPC_READRESUME_DISABLE() { CallFlowFunction(FlowFunction.FLD_NPC_READRESUME_DISABLE, false, false); }
        public void FLD_CROWD_INTERCEPT_READ() { CallFlowFunction(FlowFunction.FLD_CROWD_INTERCEPT_READ, false, false); }
        public int FLD_TOOL_ACCOUNT() { return CallFlowFunction(FlowFunction.FLD_TOOL_ACCOUNT, false, false); }
        public void FLD_HITSCR_FORCE_EXEC(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_HITSCR_FORCE_EXEC, false, false, param1, param2); }
        public void FLD_ALERT_HOLD_OFF(int param1) { CallFlowFunction(FlowFunction.FLD_ALERT_HOLD_OFF, false, false, param1); }
        public void FLD_STOP_FLASHBACK() { CallFlowFunction(FlowFunction.FLD_STOP_FLASHBACK, false, false); }
        public int FLD_MODEL_TYPMOTION_LOAD(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_MODEL_TYPMOTION_LOAD, false, false, param1, param2, param3); }
        public int FLD_MODEL_CLONE_TYPMOTION(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_MODEL_CLONE_TYPMOTION, false, false, param1, param2, param3); }
        public void FLD_UNIT_SET_WALK(int param1) { CallFlowFunction(FlowFunction.FLD_UNIT_SET_WALK, false, false, param1); }
        public void FLD_UNIT_SET_RUN(int param1) { CallFlowFunction(FlowFunction.FLD_UNIT_SET_RUN, false, false, param1); }
        public void FLD_UNIT_SET_C_WAIT(int param1) { CallFlowFunction(FlowFunction.FLD_UNIT_SET_C_WAIT, false, false, param1); }
        public void FLD_UNIT_SET_C_RUN(int param1) { CallFlowFunction(FlowFunction.FLD_UNIT_SET_C_RUN, false, false, param1); }
        public int FLD_NPC_TBLID_LOAD(int param1) { return CallFlowFunction(FlowFunction.FLD_NPC_TBLID_LOAD, false, false, param1); }
        public void FLD_ESCAPE_EFFECT() { CallFlowFunction(FlowFunction.FLD_ESCAPE_EFFECT, false, false); }
        public float FLD_POS_GET_ROT(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_POS_GET_ROT, false, false, param1); }
        public float FLD_POS_GET_DNG_X_POS() { return CallFloatFlowFunction(FlowFunction.FLD_POS_GET_DNG_X_POS, false, false); }
        public float FLD_POS_GET_DNG_Y_POS() { return CallFloatFlowFunction(FlowFunction.FLD_POS_GET_DNG_Y_POS, false, false); }
        public float FLD_POS_GET_DNG_Z_POS() { return CallFloatFlowFunction(FlowFunction.FLD_POS_GET_DNG_Z_POS, false, false); }
        public float FLD_POS_GET_DNG_ROT() { return CallFloatFlowFunction(FlowFunction.FLD_POS_GET_DNG_ROT, false, false); }
        public void FLD_BGMNG_LINKPROC_TIME(int param1, int param2, float param3) { CallFlowFunction(FlowFunction.FLD_BGMNG_LINKPROC_TIME, false, false, param1, param2, param3); }
        public void FLD_BGMNG_LINKPROC_ANIMSTART(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_BGMNG_LINKPROC_ANIMSTART, false, false, param1, param2, param3, param4); }
        public void FLD_BGMNG_LINKPROC_ANIMEND(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_BGMNG_LINKPROC_ANIMEND, false, false, param1, param2, param3, param4); }
        public void FLD_SWITCH_OFF(int param1) { CallFlowFunction(FlowFunction.FLD_SWITCH_OFF, false, false, param1); }
        public int FLD_CORP_NPC_EXIST(int param1) { return CallFlowFunction(FlowFunction.FLD_CORP_NPC_EXIST, false, false, param1); }
        public int FLD_CORP_NPC_EXIST2(int param1, int param2, int param3, int param4) { return CallFlowFunction(FlowFunction.FLD_CORP_NPC_EXIST2, false, false, param1, param2, param3, param4); }
        public int FLD_OBJ_SEARCH_RESHND(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_OBJ_SEARCH_RESHND, false, false, param1, param2); }
        public void FLD_SET_FOG(float param1, float param2, int param3, int param4, int param5, int param6, int param7) { CallFlowFunction(FlowFunction.FLD_SET_FOG, false, false, param1, param2, param3, param4, param5, param6, param7); }
        public void FLD_SET_FOG_DEFAULT(int param1) { CallFlowFunction(FlowFunction.FLD_SET_FOG_DEFAULT, false, false, param1); }
        public void FLD_MODEL_ANIM_BLINK(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_MODEL_ANIM_BLINK, false, false, param1, param2); }
        public void FLD_PC_WEAPON_CHANGE() { CallFlowFunction(FlowFunction.FLD_PC_WEAPON_CHANGE, false, false); }
        public int FLD_CHECK_FIND_ENEMY() { return CallFlowFunction(FlowFunction.FLD_CHECK_FIND_ENEMY, false, false); }
        public void FLD_SET_PAD_LOCK(int param1) { CallFlowFunction(FlowFunction.FLD_SET_PAD_LOCK, false, false, param1); }
        public int FLD_CHECK_RAY_HIT(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_CHECK_RAY_HIT, false, false, param1, param2); }
        public int FLD_CHECK_SUBJECT_MODE() { return CallFlowFunction(FlowFunction.FLD_CHECK_SUBJECT_MODE, false, false); }
        public void FLD_SET_CORRECT(float param1, float param2, float param3, float param4, float param5, int param6) { CallFlowFunction(FlowFunction.FLD_SET_CORRECT, false, false, param1, param2, param3, param4, param5, param6); }
        public void FLD_SET_CORRECT_DEFAULT(int param1) { CallFlowFunction(FlowFunction.FLD_SET_CORRECT_DEFAULT, false, false, param1); }
        public void FLD_PC_MODEL_REQ_WIRE_ANIM(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_REQ_WIRE_ANIM, false, false, param1, param2); }
        public void FLD_START_ATDNG_SHOP_ENTER() { CallFlowFunction(FlowFunction.FLD_START_ATDNG_SHOP_ENTER, false, false); }
        public void FLD_OBJ_POL_RELOAD() { CallFlowFunction(FlowFunction.FLD_OBJ_POL_RELOAD, false, false); }
        public void FLD_NPC_ATTACH_MODEL(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_NPC_ATTACH_MODEL, false, false, param1, param2, param3); }
        public void FLD_SET_MOVE_LOCK(int param1) { CallFlowFunction(FlowFunction.FLD_SET_MOVE_LOCK, false, false, param1); }
        public void FLD_SYNC_ENV() { CallFlowFunction(FlowFunction.FLD_SYNC_ENV, false, false); }
        public void FLD_GMC_PUZZLE_START(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_GMC_PUZZLE_START, false, false, param1, param2); }
        public void FLD_GMC_PUZZLE_SYNC() { CallFlowFunction(FlowFunction.FLD_GMC_PUZZLE_SYNC, false, false); }
        public int FLD_GMC_PUZZLE_PARAM_CMD(int param1, int param2, int param3, int param4) { return CallFlowFunction(FlowFunction.FLD_GMC_PUZZLE_PARAM_CMD, false, false, param1, param2, param3, param4); }
        public void FLD_UMBRELLA_ANIM_CHANGE(int param1) { CallFlowFunction(FlowFunction.FLD_UMBRELLA_ANIM_CHANGE, false, false, param1); }
        public void FLD_NPC_STOP_NOW(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_STOP_NOW, false, false, param1, param2); }
        public void FLD_LMAP_FADE(int param1) { CallFlowFunction(FlowFunction.FLD_LMAP_FADE, false, false, param1); }
        public void FLD_NPC_SET_RUNSTATE2(int param1, float param2, int param3) { CallFlowFunction(FlowFunction.FLD_NPC_SET_RUNSTATE2, false, false, param1, param2, param3); }
        public void FLD_CROWD_PATH_VISIBLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_CROWD_PATH_VISIBLE, false, false, param1, param2); }
        public void FLD_CROWD_PATH_WAIT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_CROWD_PATH_WAIT, false, false, param1, param2); }
        public int FLD_CROWD_PATH_CHECK_UNIT(int param1) { return CallFlowFunction(FlowFunction.FLD_CROWD_PATH_CHECK_UNIT, false, false, param1); }
        public void FLD_CROWD_PATH_REPOP_UNIT(int param1) { CallFlowFunction(FlowFunction.FLD_CROWD_PATH_REPOP_UNIT, false, false, param1); }
        public void FLD_CROWD_PATH_INTERCEPT_READ(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_CROWD_PATH_INTERCEPT_READ, false, false, param1, param2); }
        public void FLD_SET_LOCAL_COUNT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SET_LOCAL_COUNT, false, false, param1, param2); }
        public int FLD_GET_LOCAL_COUNT(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_LOCAL_COUNT, false, false, param1); }
        public void FLD_SET_DOOR_HIT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SET_DOOR_HIT, false, false, param1, param2); }
        public void FLD_REPORT_MSG_DTL(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_REPORT_MSG_DTL, false, false, param1, param2, param3, param4); }
        public void FLD_REPORT_MSGSYNC_DTL(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_REPORT_MSGSYNC_DTL, false, false, param1, param2, param3, param4); }
        public void FLD_MODEL_UNIT_ROTATE(int param1, int param2, float param3, int param4, int param5) { CallFlowFunction(FlowFunction.FLD_MODEL_UNIT_ROTATE, false, false, param1, param2, param3, param4, param5); }
        public void FLD_MODEL_UNIT_POINT_ROTATE(int param1, float param2, float param3, float param4, int param5) { CallFlowFunction(FlowFunction.FLD_MODEL_UNIT_POINT_ROTATE, false, false, param1, param2, param3, param4, param5); }
        public void FLD_TOOL_SET_ITEM_NAME() { CallFlowFunction(FlowFunction.FLD_TOOL_SET_ITEM_NAME, false, false); }
        public int FLD_TOOL_CHK_ITEM_AVAILABLE() { return CallFlowFunction(FlowFunction.FLD_TOOL_CHK_ITEM_AVAILABLE, false, false); }
        public void FLD_TOOL_CREATE_ITEM(int param1) { CallFlowFunction(FlowFunction.FLD_TOOL_CREATE_ITEM, false, false, param1); }
        public void FLD_PC_MODEL_LOOK_AROUND(int param1) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_LOOK_AROUND, false, false, param1); }
        public void FLD_DUNGEON_RESULT_SET_MES(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_DUNGEON_RESULT_SET_MES, false, false, param1, param2, param3); }
        public void FLD_DUNGEON_RESULT_CLEAR_MES() { CallFlowFunction(FlowFunction.FLD_DUNGEON_RESULT_CLEAR_MES, false, false); }
        public void FLD_DUNGEON_RESULT_SET_VAR(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_DUNGEON_RESULT_SET_VAR, false, false, param1, param2, param3); }
        public void FLD_DUNGEON_RESULT_CLEAR_VAR() { CallFlowFunction(FlowFunction.FLD_DUNGEON_RESULT_CLEAR_VAR, false, false); }
        public int FLD_DUNGEON_RESULT_GET_TOTALPRICE() { return CallFlowFunction(FlowFunction.FLD_DUNGEON_RESULT_GET_TOTALPRICE, false, false); }
        public int FLD_CROWD_PATH_WAIT_UNIT(int param1) { return CallFlowFunction(FlowFunction.FLD_CROWD_PATH_WAIT_UNIT, false, false, param1); }
        public void FLD_PC_MODEL_REQ_ACTION(float param1, float param2, float param3, int param4) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_REQ_ACTION, false, false, param1, param2, param3, param4); }
        public void FLD_PC_MODEL_SYNC_ACTION() { CallFlowFunction(FlowFunction.FLD_PC_MODEL_SYNC_ACTION, false, false); }
        public void FLD_GMC_OBJ_MOVE(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_GMC_OBJ_MOVE, false, false, param1, param2, param3, param4); }
        public void FLD_GMC_OBJ_MOVE_SYNC(int param1) { CallFlowFunction(FlowFunction.FLD_GMC_OBJ_MOVE_SYNC, false, false, param1); }
        public void FLD_GMC_TENKEY_START(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_GMC_TENKEY_START, false, false, param1, param2, param3); }
        public int FLD_GMC_TENKEY_SYNC() { return CallFlowFunction(FlowFunction.FLD_GMC_TENKEY_SYNC, false, false); }
        public void FLD_GMC_TENKEY_END() { CallFlowFunction(FlowFunction.FLD_GMC_TENKEY_END, false, false); }
        public int FLD_GMC_TENKEY_CTRL(int param1, int param2, int param3, int param4) { return CallFlowFunction(FlowFunction.FLD_GMC_TENKEY_CTRL, false, false, param1, param2, param3, param4); }
        public void FLD_SET_MOUSE(int param1) { CallFlowFunction(FlowFunction.FLD_SET_MOUSE, false, false, param1); }
        public int FLD_CHECK_MOUSE() { return CallFlowFunction(FlowFunction.FLD_CHECK_MOUSE, false, false); }
        public int FLD_GET_PTYTALK_MSG(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_GET_PTYTALK_MSG, false, false, param1, param2, param3); }
        public int FLD_GET_PTYTALK_WND(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_GET_PTYTALK_WND, false, false, param1, param2, param3); }
        public int FLD_GET_PTYTALK_FACE(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_GET_PTYTALK_FACE, false, false, param1, param2, param3); }
        public void FLD_CAMERA_LOCK_INTERP_S(float param1, float param2, float param3, float param4, float param5, float param6, float param7, int param8) { CallFlowFunction(FlowFunction.FLD_CAMERA_LOCK_INTERP_S, false, false, param1, param2, param3, param4, param5, param6, param7, param8); }
        public int FLD_GET_BATTLE_RESULT() { return CallFlowFunction(FlowFunction.FLD_GET_BATTLE_RESULT, false, false); }
        public int FLD_CHECK_APPROACH_ENEMY() { return CallFlowFunction(FlowFunction.FLD_CHECK_APPROACH_ENEMY, false, false); }
        public int FLD_CHOICE_MEMBER_REPORTER() { return CallFlowFunction(FlowFunction.FLD_CHOICE_MEMBER_REPORTER, false, false); }
        public int KFEVT_GET_MAJOR() { return CallFlowFunction(FlowFunction.KFEVT_GET_MAJOR, false, false); }
        public int KFEVT_GET_MINOR() { return CallFlowFunction(FlowFunction.KFEVT_GET_MINOR, false, false); }
        public int KFEVT_GET_POS_INDEX() { return CallFlowFunction(FlowFunction.KFEVT_GET_POS_INDEX, false, false); }
        public int KFEVT_GET_DIV_INDEX() { return CallFlowFunction(FlowFunction.KFEVT_GET_DIV_INDEX, false, false); }
        public void FLD_REQ_PC_SE(int param1) { CallFlowFunction(FlowFunction.FLD_REQ_PC_SE, false, false, param1); }
        public int FLD_NPC_EXIST_GROUP_VALUE(int param1) { return CallFlowFunction(FlowFunction.FLD_NPC_EXIST_GROUP_VALUE, false, false, param1); }
        public int FLD_NPC_EXIST_GROUP_VALUE_MD(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_NPC_EXIST_GROUP_VALUE_MD, false, false, param1, param2, param3); }
        public int FLD_NPC_BIT_CHK_GROUP(int param1) { return CallFlowFunction(FlowFunction.FLD_NPC_BIT_CHK_GROUP, false, false, param1); }
        public int FLD_GET_CARTALK_THEME() { return CallFlowFunction(FlowFunction.FLD_GET_CARTALK_THEME, false, false); }
        public void KFEVT_181_INIT() { CallFlowFunction(FlowFunction.KFEVT_181_INIT, false, false); }
        public void KFEVT_181_INIT_SYNC() { CallFlowFunction(FlowFunction.KFEVT_181_INIT_SYNC, false, false); }
        public void KFEVT_181_RESET_TAKEOUT_INFO() { CallFlowFunction(FlowFunction.KFEVT_181_RESET_TAKEOUT_INFO, false, false); }
        public void KFEVT_181_SET_TAKEOUT_INFO(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.KFEVT_181_SET_TAKEOUT_INFO, false, false, param1, param2, param3); }
        public int KFEVT_181_GET_TAKEOUT_CATEGORY(int param1) { return CallFlowFunction(FlowFunction.KFEVT_181_GET_TAKEOUT_CATEGORY, false, false, param1); }
        public int KFEVT_181_GET_TAKEOUT_ID(int param1) { return CallFlowFunction(FlowFunction.KFEVT_181_GET_TAKEOUT_ID, false, false, param1); }
        public int KFEVT_181_CHECK_TAKEOUT_INFO(int param1, int param2) { return CallFlowFunction(FlowFunction.KFEVT_181_CHECK_TAKEOUT_INFO, false, false, param1, param2); }
        public int KFEVT_181_EVALUATION(int param1) { return CallFlowFunction(FlowFunction.KFEVT_181_EVALUATION, false, false, param1); }
        public int KFEVT_181_GET_BONUS_TYPE() { return CallFlowFunction(FlowFunction.KFEVT_181_GET_BONUS_TYPE, false, false); }
        public int KFEVT_181_CHECK_BONUS_TYPE(int param1) { return CallFlowFunction(FlowFunction.KFEVT_181_CHECK_BONUS_TYPE, false, false, param1); }
        public int KFEVT_181_GET_REWARD_TYPE() { return CallFlowFunction(FlowFunction.KFEVT_181_GET_REWARD_TYPE, false, false); }
        public int KFEVT_181_GET_REWARD_VALUE(int param1) { return CallFlowFunction(FlowFunction.KFEVT_181_GET_REWARD_VALUE, false, false, param1); }
        public void FLD_TOOL_USE() { CallFlowFunction(FlowFunction.FLD_TOOL_USE, false, false); }
        public void FLD_TOOL_VIEW() { CallFlowFunction(FlowFunction.FLD_TOOL_VIEW, false, false); }
        public int FLD_GET_PC_PARAM_ADD(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_PC_PARAM_ADD, false, false, param1); }
        public void FLD_SET_SCR_SKIP(int param1) { CallFlowFunction(FlowFunction.FLD_SET_SCR_SKIP, false, false, param1); }
        public int FLD_CHECK_SCR_SKIP() { return CallFlowFunction(FlowFunction.FLD_CHECK_SCR_SKIP, false, false); }
        public void FLD_WAIT(int param1) { CallFlowFunction(FlowFunction.FLD_WAIT, false, false, param1); }
        public void FLD_MODEL_ANIM(int param1, int param2, int param3, int param4, float param5) { CallFlowFunction(FlowFunction.FLD_MODEL_ANIM, false, false, param1, param2, param3, param4, param5); }
        public void FLD_MODEL_ANIM_SYNC(int param1) { CallFlowFunction(FlowFunction.FLD_MODEL_ANIM_SYNC, false, false, param1); }
        public void FLD_PC_MODEL_SET_GLIMPSE(int param1) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_SET_GLIMPSE, false, false, param1); }
        public int FLD_TOOL_GET_ITEMID() { return CallFlowFunction(FlowFunction.FLD_TOOL_GET_ITEMID, false, false); }
        public void FLD_NPC_FBN_SYNC(int param1) { CallFlowFunction(FlowFunction.FLD_NPC_FBN_SYNC, false, false, param1); }
        public int FLD_SEL_EX(int param1, int param2, int param3, int param4, int param5) { return CallFlowFunction(FlowFunction.FLD_SEL_EX, false, false, param1, param2, param3, param4, param5); }
        public void FLD_SEL_SET_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_SEL_SET_VISIBLE, false, false, param1); }
        public int FLD_SEL_DATA_REQUEST(int param1) { return CallFlowFunction(FlowFunction.FLD_SEL_DATA_REQUEST, false, false, param1); }
        public void FLD_MAP_PANEL_CHANGE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_MAP_PANEL_CHANGE, false, false, param1, param2, param3); }
        public void KFEVT_181_SET_MSG_INFO(int param1, int param2, int param3, int param4, int param5) { CallFlowFunction(FlowFunction.KFEVT_181_SET_MSG_INFO, false, false, param1, param2, param3, param4, param5); }
        public int KFEVT_181_GET_MSG_ID(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.KFEVT_181_GET_MSG_ID, false, false, param1, param2, param3); }
        public int KFEVT_181_GET_MSG_NUM(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.KFEVT_181_GET_MSG_NUM, false, false, param1, param2, param3); }
        public void FLD_PC_MODEL_LOOK_FRONT() { CallFlowFunction(FlowFunction.FLD_PC_MODEL_LOOK_FRONT, false, false); }
        public void FLD_START_DEBUG_SCRIPT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_START_DEBUG_SCRIPT, false, false, param1, param2); }
        public void FLD_MODEL_DIR_TRANSLATE(int param1, float param2, float param3, int param4) { CallFlowFunction(FlowFunction.FLD_MODEL_DIR_TRANSLATE, false, false, param1, param2, param3, param4); }
        public void FLD_SHOW_ENEMY(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SHOW_ENEMY, false, false, param1, param2); }
        public int KFEVT_181_GET_BONUS_TYPE_NUM() { return CallFlowFunction(FlowFunction.KFEVT_181_GET_BONUS_TYPE_NUM, false, false); }
        public void KFEVT_181_SET_FAVORABILITY_FLAG(int param1) { CallFlowFunction(FlowFunction.KFEVT_181_SET_FAVORABILITY_FLAG, false, false, param1); }
        public int KFEVT_181_GET_FAVORABILITY(int param1) { return CallFlowFunction(FlowFunction.KFEVT_181_GET_FAVORABILITY, false, false, param1); }
        public int KFEVT_181_GET_BONUS_FORMATION_COUNT(int param1) { return CallFlowFunction(FlowFunction.KFEVT_181_GET_BONUS_FORMATION_COUNT, false, false, param1); }
        public void KFEVT_181_RESET_MSG_INFO() { CallFlowFunction(FlowFunction.KFEVT_181_RESET_MSG_INFO, false, false); }
        public void KFEVT_181_RESET_DESIGNATION_MENU() { CallFlowFunction(FlowFunction.KFEVT_181_RESET_DESIGNATION_MENU, false, false); }
        public void KFEVT_181_SET_DESIGNATION_MENU(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.KFEVT_181_SET_DESIGNATION_MENU, false, false, param1, param2, param3); }
        public int KFEVT_181_GET_RAND_DESIGNATION_MENU(int param1) { return CallFlowFunction(FlowFunction.KFEVT_181_GET_RAND_DESIGNATION_MENU, false, false, param1); }
        public void FLD_LMAP_END(int param1) { CallFlowFunction(FlowFunction.FLD_LMAP_END, false, false, param1); }
        public void FLD_MODEL_ATTACH_TRANSLATE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_MODEL_ATTACH_TRANSLATE, false, false, param1, param2, param3); }
        public void FLD_MODEL_DETACH_TRANSLATE(int param1) { CallFlowFunction(FlowFunction.FLD_MODEL_DETACH_TRANSLATE, false, false, param1); }
        public void FLD_MODEL_ATTACH_ROTATE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_MODEL_ATTACH_ROTATE, false, false, param1, param2, param3); }
        public void FLD_MODEL_DETACH_ROTATE(int param1) { CallFlowFunction(FlowFunction.FLD_MODEL_DETACH_ROTATE, false, false, param1); }
        public void FLD_REQ_PRE_LOAD(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_REQ_PRE_LOAD, false, false, param1, param2, param3, param4); }
        public void KFEVT_181_SET_VAR_FOOD_NAME() { CallFlowFunction(FlowFunction.KFEVT_181_SET_VAR_FOOD_NAME, false, false); }
        public void FLD_MODEL_TALK_ANIM(int param1) { CallFlowFunction(FlowFunction.FLD_MODEL_TALK_ANIM, false, false, param1); }
        public void FLD_UNIT_SET_SURPRISE(int param1) { CallFlowFunction(FlowFunction.FLD_UNIT_SET_SURPRISE, false, false, param1); }
        public void FLD_GAYA_EFFECT_SET(int param1) { CallFlowFunction(FlowFunction.FLD_GAYA_EFFECT_SET, false, false, param1); }
        public void FLD_MISSION_ACCEPT() { CallFlowFunction(FlowFunction.FLD_MISSION_ACCEPT, false, false); }
        public int FLD_LMAP_GET_FARE(int param1) { return CallFlowFunction(FlowFunction.FLD_LMAP_GET_FARE, false, false, param1); }
        public void CALL_BATTING_CENTER() { CallFlowFunction(FlowFunction.CALL_BATTING_CENTER, false, false); }
        public void FLD_GREETING_MSG_DTL(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_GREETING_MSG_DTL, false, false, param1, param2, param3); }
        public int FLD_CROWD_PATH_READ_WAIT(int param1) { return CallFlowFunction(FlowFunction.FLD_CROWD_PATH_READ_WAIT, false, false, param1); }
        public void KFEVT_181_FOOD_VISIBLE(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.KFEVT_181_FOOD_VISIBLE, false, false, param1, param2, param3, param4); }
        public void FLD_DUNGEON_RESULT_SET_EXP(int param1) { CallFlowFunction(FlowFunction.FLD_DUNGEON_RESULT_SET_EXP, false, false, param1); }
        public void FLD_HIT_ADD_ICON(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_HIT_ADD_ICON, false, false, param1, param2, param3); }
        public void KFEVT_181_FOOD_ALL_VISIBLE(int param1) { CallFlowFunction(FlowFunction.KFEVT_181_FOOD_ALL_VISIBLE, false, false, param1); }
        public void KFEVT_181_DISH_CLONE(int param1) { CallFlowFunction(FlowFunction.KFEVT_181_DISH_CLONE, false, false, param1); }
        public int FLD_CHECK_SMK_BALL() { return CallFlowFunction(FlowFunction.FLD_CHECK_SMK_BALL, false, false); }
        public int FLD_CHECK_FIND_ENEMY___2() { return CallFlowFunction(FlowFunction.FLD_CHECK_FIND_ENEMY___2, false, false); }
        public void FLD_PANEL_MAP_PROC_SYNC(int param1) { CallFlowFunction(FlowFunction.FLD_PANEL_MAP_PROC_SYNC, false, false, param1); }
        public void FLD_PANEL_MAP_PROC_END(int param1) { CallFlowFunction(FlowFunction.FLD_PANEL_MAP_PROC_END, false, false, param1); }
        public void KFEVT_181_DISH_CLONE_SYNC() { CallFlowFunction(FlowFunction.KFEVT_181_DISH_CLONE_SYNC, false, false); }
        public void FLD_ROADMAP_SCALE(int param1) { CallFlowFunction(FlowFunction.FLD_ROADMAP_SCALE, false, false, param1); }
        public void FLD_TOOL_SET_DRAWFLAG(int param1) { CallFlowFunction(FlowFunction.FLD_TOOL_SET_DRAWFLAG, false, false, param1); }
        public void FLD_PC_MODEL_SET_FLOATING(int param1) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_SET_FLOATING, false, false, param1); }
        public void FLD_PC_MODEL_MOVE_FLOATING(float param1, float param2, float param3) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_MOVE_FLOATING, false, false, param1, param2, param3); }
        public void FLD_PC_MODEL_SYNC_FLOATING() { CallFlowFunction(FlowFunction.FLD_PC_MODEL_SYNC_FLOATING, false, false); }
        public void CALL_FISHING_POND() { CallFlowFunction(FlowFunction.CALL_FISHING_POND, false, false); }
        public void KFEVT_181_DISH_DRAWSET(int param1) { CallFlowFunction(FlowFunction.KFEVT_181_DISH_DRAWSET, false, false, param1); }
        public int KFEVT_181_GET_DISTANCE_X(float param1, float param2, float param3, float param4, float param5, float param6) { return CallFlowFunction(FlowFunction.KFEVT_181_GET_DISTANCE_X, false, false, param1, param2, param3, param4, param5, param6); }
        public int KFEVT_181_GET_DISTANCE_Z(float param1, float param2, float param3, float param4, float param5, float param6) { return CallFlowFunction(FlowFunction.KFEVT_181_GET_DISTANCE_Z, false, false, param1, param2, param3, param4, param5, param6); }
        public int FLD_NPC_GREETING_GET_DISP_TIME() { return CallFlowFunction(FlowFunction.FLD_NPC_GREETING_GET_DISP_TIME, false, false); }
        public void FLD_SET_DISGUISE(int param1) { CallFlowFunction(FlowFunction.FLD_SET_DISGUISE, false, false, param1); }
        public int FLD_CHECK_DISGUISE() { return CallFlowFunction(FlowFunction.FLD_CHECK_DISGUISE, false, false); }
        public void FLD_PC_MODEL_PERSONAL(int param1) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_PERSONAL, false, false, param1); }
        public void FLD_OBJ_SET_ALPHA(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_OBJ_SET_ALPHA, false, false, param1, param2, param3); }
        public int FLD_PANEL_MMAP_WHOLE(int param1) { return CallFlowFunction(FlowFunction.FLD_PANEL_MMAP_WHOLE, false, false, param1); }
        public int FLD_PANEL_MAP_AT_CHECK_VISIBLE() { return CallFlowFunction(FlowFunction.FLD_PANEL_MAP_AT_CHECK_VISIBLE, false, false); }
        public void KFEVT_SET_NANPA_TACTICS(float param1, float param2) { CallFlowFunction(FlowFunction.KFEVT_SET_NANPA_TACTICS, false, false, param1, param2); }
        public void FLD_SET_DEBUG_OK() { CallFlowFunction(FlowFunction.FLD_SET_DEBUG_OK, false, false); }
        public int KFEVT_GET_NANPA_QUEST_VAL(float param1, float param2, float param3) { return CallFlowFunction(FlowFunction.KFEVT_GET_NANPA_QUEST_VAL, false, false, param1, param2, param3); }
        public void FLD_FASTTRAVEL_OPEN(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_FASTTRAVEL_OPEN, false, false, param1, param2, param3); }
        public void FLD_MODEL_SET_RIPPLE_EFF(int param1, int param2, float param3) { CallFlowFunction(FlowFunction.FLD_MODEL_SET_RIPPLE_EFF, false, false, param1, param2, param3); }
        public void FLD_MODEL_SET_SPOUT_EFF(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_MODEL_SET_SPOUT_EFF, false, false, param1, param2); }
        public void FLD_GET_FIX_ITEM(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_GET_FIX_ITEM, false, false, param1, param2); }
        public int KFEVT_GET_NANPA_BEST_SEL(float param1, float param2) { return CallFlowFunction(FlowFunction.KFEVT_GET_NANPA_BEST_SEL, false, false, param1, param2); }
        public int KFEVT_NANPA_BITON(float param1, float param2, float param3) { return CallFlowFunction(FlowFunction.KFEVT_NANPA_BITON, false, false, param1, param2, param3); }
        public int KFEVT_NANPA_BITCHECK(float param1, float param2, float param3) { return CallFlowFunction(FlowFunction.KFEVT_NANPA_BITCHECK, false, false, param1, param2, param3); }
        public void FLD_REQ_DOOR_SE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_REQ_DOOR_SE, false, false, param1, param2); }
        public void KFEVT_181_DISH_EFFECT() { CallFlowFunction(FlowFunction.KFEVT_181_DISH_EFFECT, false, false); }
        public void FLD_SET_ENEMY_WAIT_TIME(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SET_ENEMY_WAIT_TIME, false, false, param1, param2, param3); }
        public void FLD_OVERWRITE_ENC_NO(int param1) { CallFlowFunction(FlowFunction.FLD_OVERWRITE_ENC_NO, false, false, param1); }
        public void FLD_SET_LOOK_AT_POS(int param1, float param2, int param3) { CallFlowFunction(FlowFunction.FLD_SET_LOOK_AT_POS, false, false, param1, param2, param3); }
        public void FLD_PTY_MODEL_SET_RND_POS() { CallFlowFunction(FlowFunction.FLD_PTY_MODEL_SET_RND_POS, false, false); }
        public void FLD_PTY_MODEL_SET_LINE_POS() { CallFlowFunction(FlowFunction.FLD_PTY_MODEL_SET_LINE_POS, false, false); }
        public void FLD_OPEN_ORD_DOOR_ONLY(int param1) { CallFlowFunction(FlowFunction.FLD_OPEN_ORD_DOOR_ONLY, false, false, param1); }
        public int FLD_MISSION_ACCEPT_GET_CHECK_NUM() { return CallFlowFunction(FlowFunction.FLD_MISSION_ACCEPT_GET_CHECK_NUM, false, false); }
        public int FLD_MISSION_ACCEPT_GET_CHECK_ID(int param1) { return CallFlowFunction(FlowFunction.FLD_MISSION_ACCEPT_GET_CHECK_ID, false, false, param1); }
        public int FLD_SUMMON_ENEMY_MOVE(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_SUMMON_ENEMY_MOVE, false, false, param1, param2); }
        public void FLD_MISSION_LIST_ON_FORCE() { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_ON_FORCE, false, false); }
        public int FLD_GET_SCH_OBJ_ENEMY(int param1, int param2, float param3, float param4, float param5) { return CallFlowFunction(FlowFunction.FLD_GET_SCH_OBJ_ENEMY, false, false, param1, param2, param3, param4, param5); }
        public void FLD_TOOL_REQUEST_END() { CallFlowFunction(FlowFunction.FLD_TOOL_REQUEST_END, false, false); }
        public int FLD_PC_GET_BAG_TYPE() { return CallFlowFunction(FlowFunction.FLD_PC_GET_BAG_TYPE, false, false); }
        public void FLD_OPEN_ORD_DOOR_FADE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_OPEN_ORD_DOOR_FADE, false, false, param1, param2, param3); }
        public void FLD_SET_DOOR_HIT_TYPE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SET_DOOR_HIT_TYPE, false, false, param1, param2, param3); }
        public void FLD_SET_ENEMY_GLANCE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SET_ENEMY_GLANCE, false, false, param1, param2, param3); }
        public void FLD_NPC_SEPARATEOFF_MESH(int param1) { CallFlowFunction(FlowFunction.FLD_NPC_SEPARATEOFF_MESH, false, false, param1); }
        public void FLD_PARTY_IN(int param1) { CallFlowFunction(FlowFunction.FLD_PARTY_IN, false, false, param1); }
        public void FLD_PARTY_OUT(int param1) { CallFlowFunction(FlowFunction.FLD_PARTY_OUT, false, false, param1); }
        public void FLD_REQ_PRE_LOAD_ATDNG(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_REQ_PRE_LOAD_ATDNG, false, false, param1, param2, param3); }
        public int FLD_CHECK_ENTRANCE_FLOOR() { return CallFlowFunction(FlowFunction.FLD_CHECK_ENTRANCE_FLOOR, false, false); }
        public int FLD_CHECK_SAFE_ROOM() { return CallFlowFunction(FlowFunction.FLD_CHECK_SAFE_ROOM, false, false); }
        public void FLD_SFTYROOM_MENU_SETMODE(int param1) { CallFlowFunction(FlowFunction.FLD_SFTYROOM_MENU_SETMODE, false, false, param1); }
        public void FLD_MODEL_ANIM_NEXT(int param1, int param2, int param3, int param4, float param5) { CallFlowFunction(FlowFunction.FLD_MODEL_ANIM_NEXT, false, false, param1, param2, param3, param4, param5); }
        public int FLD_CHECK_SAVE_ENABLE() { return CallFlowFunction(FlowFunction.FLD_CHECK_SAVE_ENABLE, false, false); }
        public void FLD_SET_DIALY(int param1) { CallFlowFunction(FlowFunction.FLD_SET_DIALY, false, false, param1); }
        public void FLD_DUNGEON_RESULT_SET_MVP(int param1) { CallFlowFunction(FlowFunction.FLD_DUNGEON_RESULT_SET_MVP, false, false, param1); }
        public void FLD_DUNGEON_RESULT_SET_BONUS(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_DUNGEON_RESULT_SET_BONUS, false, false, param1, param2, param3); }
        public void FLD_BAG_ANIM_DISABLE() { CallFlowFunction(FlowFunction.FLD_BAG_ANIM_DISABLE, false, false); }
        public void FLD_SET_BAG_ANIM(int param1) { CallFlowFunction(FlowFunction.FLD_SET_BAG_ANIM, false, false, param1); }
        public int FLD_SYNC_DOOR_FADE() { return CallFlowFunction(FlowFunction.FLD_SYNC_DOOR_FADE, false, false); }
        public int FLD_CHECK_DNG_TRAVERSE(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_CHECK_DNG_TRAVERSE, false, false, param1, param2); }
        public int FLD_GET_SYMBOL_ENCOUNTID(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GET_SYMBOL_ENCOUNTID, false, false, param1, param2); }
        public void FLD_DUNGEON_RESULT_SET_DUNGEON_NO(int param1) { CallFlowFunction(FlowFunction.FLD_DUNGEON_RESULT_SET_DUNGEON_NO, false, false, param1); }
        public void FLD_SYNC_GET_ITEM() { CallFlowFunction(FlowFunction.FLD_SYNC_GET_ITEM, false, false); }
        public void FLD_NPC_RESET_FBNID_POS(int param1) { CallFlowFunction(FlowFunction.FLD_NPC_RESET_FBNID_POS, false, false, param1); }
        public int KFEVT_TBL_GET_MAJOR(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.KFEVT_TBL_GET_MAJOR, false, false, param1, param2, param3); }
        public int KFEVT_TBL_GET_MINOR(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.KFEVT_TBL_GET_MINOR, false, false, param1, param2, param3); }
        public int KFEVT_TBL_GET_DIV(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.KFEVT_TBL_GET_DIV, false, false, param1, param2, param3); }
        public int FLD_MISSION_ACCEPT_GET_SELECT_ID() { return CallFlowFunction(FlowFunction.FLD_MISSION_ACCEPT_GET_SELECT_ID, false, false); }
        public int FLD_GET_DNG_QUEST_NO(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GET_DNG_QUEST_NO, false, false, param1, param2); }
        public void CALL_ATDNG_QUEST_FLOOR(int param1) { CallFlowFunction(FlowFunction.CALL_ATDNG_QUEST_FLOOR, false, false, param1); }
        public void FLD_NPC_TURN_AT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_TURN_AT, false, false, param1, param2); }
        public void FLD_NPC_TURN_RESET(int param1) { CallFlowFunction(FlowFunction.FLD_NPC_TURN_RESET, false, false, param1); }
        public float FLD_GET_DNG_PARTS_ROT() { return CallFloatFlowFunction(FlowFunction.FLD_GET_DNG_PARTS_ROT, false, false); }
        public void FLD_NPC_UNDISP(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_UNDISP, false, false, param1, param2); }
        public int FLD_GET_ALERT_ADD_VALUE() { return CallFlowFunction(FlowFunction.FLD_GET_ALERT_ADD_VALUE, false, false); }
        public void FLD_BREAK_WALL() { CallFlowFunction(FlowFunction.FLD_BREAK_WALL, false, false); }
        public int FLD_GET_SNEAKING_ITEM_ID() { return CallFlowFunction(FlowFunction.FLD_GET_SNEAKING_ITEM_ID, false, false); }
        public void FLD_TOOL_END_EFFECT() { CallFlowFunction(FlowFunction.FLD_TOOL_END_EFFECT, false, false); }
        public void FLD_TOOL_END_EFFECT_SYNC() { CallFlowFunction(FlowFunction.FLD_TOOL_END_EFFECT_SYNC, false, false); }
        public int FLD_CHECK_MSG_DISP() { return CallFlowFunction(FlowFunction.FLD_CHECK_MSG_DISP, false, false); }
        public void KAWAKAMI_SET_REQUEST_ITEM(float param1, float param2, float param3) { CallFlowFunction(FlowFunction.KAWAKAMI_SET_REQUEST_ITEM, false, false, param1, param2, param3); }
        public int KAWAKAMI_GET_REQUEST_ITEMID(float param1) { return CallFlowFunction(FlowFunction.KAWAKAMI_GET_REQUEST_ITEMID, false, false, param1); }
        public int KAWAKAMI_GET_REQUEST_ITEMNUM(float param1) { return CallFlowFunction(FlowFunction.KAWAKAMI_GET_REQUEST_ITEMNUM, false, false, param1); }
        public void FLD_SET_RESHND_BANK(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SET_RESHND_BANK, false, false, param1, param2); }
        public int FLD_GET_RESHND_BANK(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_RESHND_BANK, false, false, param1); }
        public void FLD_SFTYROOM_MENU_SETBOSSID(int param1) { CallFlowFunction(FlowFunction.FLD_SFTYROOM_MENU_SETBOSSID, false, false, param1); }
        public void FLD_DASH_EFFECT(int param1) { CallFlowFunction(FlowFunction.FLD_DASH_EFFECT, false, false, param1); }
        public int FLD_GET_CARTALK_PC(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_CARTALK_PC, false, false, param1); }
        public int FLD_GET_CARTALK_MSG(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GET_CARTALK_MSG, false, false, param1, param2); }
        public int FLD_GET_CARTALK_WND(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GET_CARTALK_WND, false, false, param1, param2); }
        public int FLD_GET_CARTALK_FACE(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GET_CARTALK_FACE, false, false, param1, param2); }
        public int FLD_GET_CARTALK_ANSWER(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GET_CARTALK_ANSWER, false, false, param1, param2); }
        public int FLD_GET_CARTALK_ANS_PC(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_GET_CARTALK_ANS_PC, false, false, param1, param2, param3); }
        public int FLD_GET_CARTALK_ANS_MSG(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_GET_CARTALK_ANS_MSG, false, false, param1, param2, param3); }
        public int FLD_GET_CARTALK_ANS_WND(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_GET_CARTALK_ANS_WND, false, false, param1, param2, param3); }
        public int FLD_GET_CARTALK_ANS_FACE(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_GET_CARTALK_ANS_FACE, false, false, param1, param2, param3); }
        public int FLD_RESIDENT_EFFECT_START(int param1) { return CallFlowFunction(FlowFunction.FLD_RESIDENT_EFFECT_START, false, false, param1); }
        public int GET_CHARA_CAMERA_DIR(float param1, float param2, float param3, float param4, float param5, float param6) { return CallFlowFunction(FlowFunction.GET_CHARA_CAMERA_DIR, false, false, param1, param2, param3, param4, param5, param6); }
        public int FLD_CHECK_SAVE_DATA_LOAD() { return CallFlowFunction(FlowFunction.FLD_CHECK_SAVE_DATA_LOAD, false, false); }
        public void FLD_GFS_PARTS_SYNC(int param1) { CallFlowFunction(FlowFunction.FLD_GFS_PARTS_SYNC, false, false, param1); }
        public void FLD_CROWD_PAUSE(int param1) { CallFlowFunction(FlowFunction.FLD_CROWD_PAUSE, false, false, param1); }
        public void FLD_CALL_EVENT_SETUP() { CallFlowFunction(FlowFunction.FLD_CALL_EVENT_SETUP, false, false); }
        public void FLD_ALERT_DISP_PLACENO(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_ALERT_DISP_PLACENO, false, false, param1, param2); }
        public void FLD_ALERT_RAPID_DISP_PLACENO(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_ALERT_RAPID_DISP_PLACENO, false, false, param1, param2); }
        public void CROSSWORD_START(int param1) { CallFlowFunction(FlowFunction.CROSSWORD_START, false, false, param1); }
        public void CROSSWORD_ENDSYNC() { CallFlowFunction(FlowFunction.CROSSWORD_ENDSYNC, false, false); }
        public int CROSSWORD_RELUST() { return CallFlowFunction(FlowFunction.CROSSWORD_RELUST, false, false); }
        public void FLD_SET_SCR_NAME(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SET_SCR_NAME, false, false, param1, param2); }
        public int FLD_MISSION_LIST_GET_FLAG(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_MISSION_LIST_GET_FLAG, false, false, param1, param2); }
        public void FLD_MISSION_LIST_SET_FLAG(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_SET_FLAG, false, false, param1, param2, param3); }
        public void FLD_MISSION_LIST_CLEAR_FLAGS() { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_CLEAR_FLAGS, false, false); }
        public void FLD_MISSION_LIST_SWAPTBL() { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_SWAPTBL, false, false); }
        public void CALL_TV_PROGRAM() { CallFlowFunction(FlowFunction.CALL_TV_PROGRAM, false, false); }
        public void TV_PROGRAM_ENDSYNC() { CallFlowFunction(FlowFunction.TV_PROGRAM_ENDSYNC, false, false); }
        public void TODAY_TV_PROGRAM() { CallFlowFunction(FlowFunction.TODAY_TV_PROGRAM, false, false); }
        public void TODAY_TV_PROGRAM_ENDSYNC() { CallFlowFunction(FlowFunction.TODAY_TV_PROGRAM_ENDSYNC, false, false); }
        public int GET_TODAY_TV_PROGRAM_BG() { return CallFlowFunction(FlowFunction.GET_TODAY_TV_PROGRAM_BG, false, false); }
        public void FLD_VLT_FILTER_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_VLT_FILTER_VISIBLE, false, false, param1); }
        public void FLD_NPC_SET_EFFECT_TARGET(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_SET_EFFECT_TARGET, false, false, param1, param2); }
        public void FLD_MISSION_WINDOW(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_MISSION_WINDOW, false, false, param1, param2); }
        public int FLD_GET_ALERT_DEC_VALUE() { return CallFlowFunction(FlowFunction.FLD_GET_ALERT_DEC_VALUE, false, false); }
        public void FLD_VLT_FILTER_LOCK(int param1) { CallFlowFunction(FlowFunction.FLD_VLT_FILTER_LOCK, false, false, param1); }
        public int FLD_CHECK_DNG_FIND_PARTS(int param1) { return CallFlowFunction(FlowFunction.FLD_CHECK_DNG_FIND_PARTS, false, false, param1); }
        public void FLD_ALERT_SET_KEEP_FLAG(int param1) { CallFlowFunction(FlowFunction.FLD_ALERT_SET_KEEP_FLAG, false, false, param1); }
        public void FLD_BG_CASH_REMOVE() { CallFlowFunction(FlowFunction.FLD_BG_CASH_REMOVE, false, false); }
        public int FLD_ITEM_MODEL_LOAD(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_ITEM_MODEL_LOAD, false, false, param1, param2); }
        public void FLD_PANEL_MMAP_NEW_STAGE(int param1) { CallFlowFunction(FlowFunction.FLD_PANEL_MMAP_NEW_STAGE, false, false, param1); }
        public void FLD_PANEL_MMAP_NEW_STAGE_EXIT() { CallFlowFunction(FlowFunction.FLD_PANEL_MMAP_NEW_STAGE_EXIT, false, false); }
        public void FLD_NPC_VISIBLE_ALL(int param1) { CallFlowFunction(FlowFunction.FLD_NPC_VISIBLE_ALL, false, false, param1); }
        public void FLD_NPC_SET_RADIUS(int param1, float param2) { CallFlowFunction(FlowFunction.FLD_NPC_SET_RADIUS, false, false, param1, param2); }
        public void FLD_CROWD_PATH_VISIBLE_ALL(int param1) { CallFlowFunction(FlowFunction.FLD_CROWD_PATH_VISIBLE_ALL, false, false, param1); }
        public void FLD_START_SUPPORT_MSG_EX() { CallFlowFunction(FlowFunction.FLD_START_SUPPORT_MSG_EX, false, false); }
        public void FLD_SHOW_NEW_SPOT(int param1) { CallFlowFunction(FlowFunction.FLD_SHOW_NEW_SPOT, false, false, param1); }
        public void FLD_TRANS_END_ANIM(int param1, int param2, int param3, int param4, float param5) { CallFlowFunction(FlowFunction.FLD_TRANS_END_ANIM, false, false, param1, param2, param3, param4, param5); }
        public void FLD_ROTATE_END_ANIM(int param1, int param2, int param3, int param4, float param5) { CallFlowFunction(FlowFunction.FLD_ROTATE_END_ANIM, false, false, param1, param2, param3, param4, param5); }
        public void FLD_END_SMK_BALL() { CallFlowFunction(FlowFunction.FLD_END_SMK_BALL, false, false); }
        public int FLD_ITEM_GET_RESHND(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_ITEM_GET_RESHND, false, false, param1, param2); }
        public void FLD_NPC_LOOKAT_DISABLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_LOOKAT_DISABLE, false, false, param1, param2); }
        public void FLD_SETBANK_BGENV_VOICE(int param1) { CallFlowFunction(FlowFunction.FLD_SETBANK_BGENV_VOICE, false, false, param1); }
        public void FLD_GET_FIX_ITEMS() { CallFlowFunction(FlowFunction.FLD_GET_FIX_ITEMS, false, false); }
        public void FLD_SLIDING_EFFECT(int param1) { CallFlowFunction(FlowFunction.FLD_SLIDING_EFFECT, false, false, param1); }
        public int FLD_GET_TBOX_ITEM_ID(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_TBOX_ITEM_ID, false, false, param1); }
        public void FLD_GET_SCH_OBJ_BEGIN_NG(int param1) { CallFlowFunction(FlowFunction.FLD_GET_SCH_OBJ_BEGIN_NG, false, false, param1); }
        public void FLD_PANEL_EXTRA_LIFE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_PANEL_EXTRA_LIFE, false, false, param1, param2, param3); }
        public void FLD_PANEL_EXTRA_LOOP(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_PANEL_EXTRA_LOOP, false, false, param1, param2, param3); }
        public void FLD_PANEL_EXTRA_END_REQ() { CallFlowFunction(FlowFunction.FLD_PANEL_EXTRA_END_REQ, false, false); }
        public void FLD_PANEL_EXTRA_END_REQ_RAPID() { CallFlowFunction(FlowFunction.FLD_PANEL_EXTRA_END_REQ_RAPID, false, false); }
        public int FLD_PANEL_EXTRA_CHK_VISIBLE() { return CallFlowFunction(FlowFunction.FLD_PANEL_EXTRA_CHK_VISIBLE, false, false); }
        public void FLD_NPC_APPEND_LOAD() { CallFlowFunction(FlowFunction.FLD_NPC_APPEND_LOAD, false, false); }
        public void FLD_SLEEP_ENEMY(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SLEEP_ENEMY, false, false, param1, param2); }
        public void FLD_NPC_SET_DEFMOTION(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_SET_DEFMOTION, false, false, param1, param2); }
        public void FLD_NPC_CANCEL_ENGULF(int param1) { CallFlowFunction(FlowFunction.FLD_NPC_CANCEL_ENGULF, false, false, param1); }
        public int FLD_SEL_EX2(int param1, int param2, int param3, int param4, int param5, int param6, int param7) { return CallFlowFunction(FlowFunction.FLD_SEL_EX2, false, false, param1, param2, param3, param4, param5, param6, param7); }
        public void FLD_ROADMAP_SET_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_ROADMAP_SET_VISIBLE, false, false, param1); }
        public void FLD_GIMMICK_RAY_HIT(float param1, float param2, float param3) { CallFlowFunction(FlowFunction.FLD_GIMMICK_RAY_HIT, false, false, param1, param2, param3); }
        public void FLD_PC_CNV_NPC() { CallFlowFunction(FlowFunction.FLD_PC_CNV_NPC, false, false); }
        public void FLD_SET_EVT_EMY_ENCOUNT_NO(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SET_EVT_EMY_ENCOUNT_NO, false, false, param1, param2, param3); }
        public void FLD_SET_ENEMY_INOUT(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SET_ENEMY_INOUT, false, false, param1, param2, param3); }
        public void FLD_NPC_EMOTE_ANIM(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_EMOTE_ANIM, false, false, param1, param2); }
        public void FLD_CAR_ONOFF_CHANGE(int param1) { CallFlowFunction(FlowFunction.FLD_CAR_ONOFF_CHANGE, false, false, param1); }
        public void FLD_PARTY_SAVE() { CallFlowFunction(FlowFunction.FLD_PARTY_SAVE, false, false); }
        public void FLD_PARTY_LOAD() { CallFlowFunction(FlowFunction.FLD_PARTY_LOAD, false, false); }
        public float FLD_GET_DNG_PARTS_X_POS() { return CallFloatFlowFunction(FlowFunction.FLD_GET_DNG_PARTS_X_POS, false, false); }
        public float FLD_GET_DNG_PARTS_Y_POS() { return CallFloatFlowFunction(FlowFunction.FLD_GET_DNG_PARTS_Y_POS, false, false); }
        public float FLD_GET_DNG_PARTS_Z_POS() { return CallFloatFlowFunction(FlowFunction.FLD_GET_DNG_PARTS_Z_POS, false, false); }
        public void FLD_CAMERA_SET_TGT_UPDATE(int param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_SET_TGT_UPDATE, false, false, param1); }
        public void FLD_SHOW_NEW_SPOT_SYNC_MODE(int param1) { CallFlowFunction(FlowFunction.FLD_SHOW_NEW_SPOT_SYNC_MODE, false, false, param1); }
        public void FLD_SHOW_NEW_SPOT_SYNC_EXIT() { CallFlowFunction(FlowFunction.FLD_SHOW_NEW_SPOT_SYNC_EXIT, false, false); }
        public void FLD_REVERT_ENC_NO() { CallFlowFunction(FlowFunction.FLD_REVERT_ENC_NO, false, false); }
        public void FLD_SET_ALL_ENCOUNT_NO(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_SET_ALL_ENCOUNT_NO, false, false, param1, param2, param3, param4); }
        public void FLD_EMY_SET_EFFECT_TARGET(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_EMY_SET_EFFECT_TARGET, false, false, param1, param2); }
        public void FLD_SET_SCNLIGHT_AMB(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_SET_SCNLIGHT_AMB, false, false, param1, param2, param3, param4); }
        public void FLD_SET_SCNLIGHT_DIFF(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_SET_SCNLIGHT_DIFF, false, false, param1, param2, param3, param4); }
        public void FLD_SET_SCNLIGHT_SPEC(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_SET_SCNLIGHT_SPEC, false, false, param1, param2, param3, param4); }
        public void FLD_SET_SCNLIGHT_DEFAULT(int param1) { CallFlowFunction(FlowFunction.FLD_SET_SCNLIGHT_DEFAULT, false, false, param1); }
        public void FLD_SET_CHARLIGHT_AMB(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_SET_CHARLIGHT_AMB, false, false, param1, param2, param3, param4); }
        public void FLD_SET_CHARLIGHT_DIFF(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_SET_CHARLIGHT_DIFF, false, false, param1, param2, param3, param4); }
        public void FLD_SET_CHARLIGHT_SPEC(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_SET_CHARLIGHT_SPEC, false, false, param1, param2, param3, param4); }
        public void FLD_SET_CHARIGHT_DEFAULT(int param1) { CallFlowFunction(FlowFunction.FLD_SET_CHARIGHT_DEFAULT, false, false, param1); }
        public float FLD_CAMERA_GET_YAW() { return CallFloatFlowFunction(FlowFunction.FLD_CAMERA_GET_YAW, false, false); }
        public float FLD_CAMERA_GET_PITCH() { return CallFloatFlowFunction(FlowFunction.FLD_CAMERA_GET_PITCH, false, false); }
        public float FLD_CAMERA_GET_ROLL() { return CallFloatFlowFunction(FlowFunction.FLD_CAMERA_GET_ROLL, false, false); }
        public float FLD_ADJUST_DEG_180(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_ADJUST_DEG_180, false, false, param1); }
        public int FLD_PC_ID_GET_CURRENT_RESHND(int param1) { return CallFlowFunction(FlowFunction.FLD_PC_ID_GET_CURRENT_RESHND, false, false, param1); }
        public void CALL_ALERT_SPECIAL(int param1, int param2) { CallFlowFunction(FlowFunction.CALL_ALERT_SPECIAL, false, false, param1, param2); }
        public int FLD_GET_TYPE_ALERT_VALUE(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_TYPE_ALERT_VALUE, false, false, param1); }
        public void FLD_SET_TYPE_ALERT_VALUE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SET_TYPE_ALERT_VALUE, false, false, param1, param2); }
        public int FLD_LMAP_GET_SELECT_ID() { return CallFlowFunction(FlowFunction.FLD_LMAP_GET_SELECT_ID, false, false); }
        public void FLD_SET_FIX_BGM(int param1) { CallFlowFunction(FlowFunction.FLD_SET_FIX_BGM, false, false, param1); }
        public void FLD_NPC_LOOKAT_DISABLE_FBNID(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_LOOKAT_DISABLE_FBNID, false, false, param1, param2); }
        public void CALL_ALERT_CHANGE(int param1) { CallFlowFunction(FlowFunction.CALL_ALERT_CHANGE, false, false, param1); }
        public float FLD_MODEL_GET_X_WORLD_TRANSLATE(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_X_WORLD_TRANSLATE, false, false, param1); }
        public float FLD_MODEL_GET_Y_WORLD_TRANSLATE(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_Y_WORLD_TRANSLATE, false, false, param1); }
        public float FLD_MODEL_GET_Z_WORLD_TRANSLATE(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_Z_WORLD_TRANSLATE, false, false, param1); }
        public void FLD_MODEL_BGHELPER_TRANSLATE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_MODEL_BGHELPER_TRANSLATE, false, false, param1, param2); }
        public void FLD_GREETING_MSG_BLOCK(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_GREETING_MSG_BLOCK, false, false, param1, param2, param3); }
        public void FLD_GIMMICK_CAMERA_SET(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_GIMMICK_CAMERA_SET, false, false, param1, param2); }
        public int FLD_OBJ_MODEL_LOAD_UID(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_OBJ_MODEL_LOAD_UID, false, false, param1, param2, param3); }
        public void FLD_SWITCH_ELEVATOR(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SWITCH_ELEVATOR, false, false, param1, param2); }
        public float FLD_EMY_MODEL_GET_SCALE(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_EMY_MODEL_GET_SCALE, false, false, param1); }
        public void FLD_NOT_OPEN_DOOR_ANIM(int param1) { CallFlowFunction(FlowFunction.FLD_NOT_OPEN_DOOR_ANIM, false, false, param1); }
        public void FLD_PANEL_GUIDE_HIGHLIGHT(int param1) { CallFlowFunction(FlowFunction.FLD_PANEL_GUIDE_HIGHLIGHT, false, false, param1); }
        public void FLD_SET_DARK_ZONE(int param1) { CallFlowFunction(FlowFunction.FLD_SET_DARK_ZONE, false, false, param1); }
        public int FLD_CHECK_DARK_ZONE() { return CallFlowFunction(FlowFunction.FLD_CHECK_DARK_ZONE, false, false); }
        public void FLD_PANEL_COIN_SET_TYPE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PANEL_COIN_SET_TYPE, false, false, param1, param2); }
        public void FLD_PANEL_COIN_SET_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_PANEL_COIN_SET_VISIBLE, false, false, param1); }
        public int FLD_PANEL_COIN_CHECK_VISIBLE() { return CallFlowFunction(FlowFunction.FLD_PANEL_COIN_CHECK_VISIBLE, false, false); }
        public int FLD_GET_FISHING_RESULT(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GET_FISHING_RESULT, false, false, param1, param2); }
        public void PREPARE_CALL_FIELD(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.PREPARE_CALL_FIELD, false, false, param1, param2, param3, param4); }
        public void PREPARE_CALL_KF_EVENT(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.PREPARE_CALL_KF_EVENT, false, false, param1, param2, param3, param4); }
        public void FLD_CLEAR_SUMMON_ENEMY(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_CLEAR_SUMMON_ENEMY, false, false, param1, param2); }
        public void FLD_CLEAR_SUMMON_LIFE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_CLEAR_SUMMON_LIFE, false, false, param1, param2); }
        public void FLD_CAMERA_INTERP_ASYNC(int param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_INTERP_ASYNC, false, false, param1); }
        public void FLD_PC_MODEL_SET_PASS_GATE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_SET_PASS_GATE, false, false, param1, param2); }
        public void FLD_BFIELD_LOAD() { CallFlowFunction(FlowFunction.FLD_BFIELD_LOAD, false, false); }
        public int FLD_CASINO_GAME_DEAL(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_CASINO_GAME_DEAL, false, false, param1, param2, param3); }
        public int FLD_CASINO_GAME_CHECK_PLAY(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_CASINO_GAME_CHECK_PLAY, false, false, param1, param2, param3); }
        public void FLD_SET_BUTTON_HIT_DISABLE(int param1) { CallFlowFunction(FlowFunction.FLD_SET_BUTTON_HIT_DISABLE, false, false, param1); }
        public void FLD_ALLY_SET_POINT_ROT(float param1, float param2, float param3) { CallFlowFunction(FlowFunction.FLD_ALLY_SET_POINT_ROT, false, false, param1, param2, param3); }
        public void FLD_ALLY_SET_ORIENT_ROT(int param1) { CallFlowFunction(FlowFunction.FLD_ALLY_SET_ORIENT_ROT, false, false, param1); }
        public void FLD_SYNC_COVER_STATE() { CallFlowFunction(FlowFunction.FLD_SYNC_COVER_STATE, false, false); }
        public void FLD_SET_PARTY_LOOKAT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SET_PARTY_LOOKAT, false, false, param1, param2); }
        public void FLD_SET_PARTY_LOOKAT_POS(int param1, float param2, float param3, float param4) { CallFlowFunction(FlowFunction.FLD_SET_PARTY_LOOKAT_POS, false, false, param1, param2, param3, param4); }
        public void FLD_RESET_PARTY_LOOKAT(int param1) { CallFlowFunction(FlowFunction.FLD_RESET_PARTY_LOOKAT, false, false, param1); }
        public void FLD_ALLY_SET_WAIT(int param1) { CallFlowFunction(FlowFunction.FLD_ALLY_SET_WAIT, false, false, param1); }
        public void FLD_PLACENAME_TEX_EXIT() { CallFlowFunction(FlowFunction.FLD_PLACENAME_TEX_EXIT, false, false); }
        public void FLD_PLACENAME_TEX_WAIT() { CallFlowFunction(FlowFunction.FLD_PLACENAME_TEX_WAIT, false, false); }
        public void FLD_NPC_SET_CURRENT_PATHNODE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_SET_CURRENT_PATHNODE, false, false, param1, param2); }
        public void FLD_SWITCH_REQ_ANIM(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SWITCH_REQ_ANIM, false, false, param1, param2); }
        public void FLD_SWITCH_SYNC_ANIM() { CallFlowFunction(FlowFunction.FLD_SWITCH_SYNC_ANIM, false, false); }
        public int FLD_CHECK_AUTO_RECOVER() { return CallFlowFunction(FlowFunction.FLD_CHECK_AUTO_RECOVER, false, false); }
        public int FLD_USE_AUTO_RECOVER() { return CallFlowFunction(FlowFunction.FLD_USE_AUTO_RECOVER, false, false); }
        public int FLD_SIMPLE_SYS_MSG(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.FLD_SIMPLE_SYS_MSG, false, false, param1, param2, param3); }
        public void FLD_MEMBER_RECOVER(int param1) { CallFlowFunction(FlowFunction.FLD_MEMBER_RECOVER, false, false, param1); }
        public void FLD_NPC_TALKICON_FORCEDISP_FBNID(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_TALKICON_FORCEDISP_FBNID, false, false, param1, param2); }
        public void FLD_DNG_SET_CENTER_POS(int param1) { CallFlowFunction(FlowFunction.FLD_DNG_SET_CENTER_POS, false, false, param1); }
        public void FLD_MODEL_SET_SCALE(int param1, float param2) { CallFlowFunction(FlowFunction.FLD_MODEL_SET_SCALE, false, false, param1, param2); }
        public void FLD_CROWD_SET_DIVNO_DNG(int param1) { CallFlowFunction(FlowFunction.FLD_CROWD_SET_DIVNO_DNG, false, false, param1); }
        public int FLD_CROWD_GET_DIVNO_DNG() { return CallFlowFunction(FlowFunction.FLD_CROWD_GET_DIVNO_DNG, false, false); }
        public void FLD_PTY_ADD_BUF(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PTY_ADD_BUF, false, false, param1, param2); }
        public void FLD_PTY_RESET_BUF() { CallFlowFunction(FlowFunction.FLD_PTY_RESET_BUF, false, false); }
        public void FLD_SET_DUCT_POS(float param1, float param2, float param3, float param4, float param5) { CallFlowFunction(FlowFunction.FLD_SET_DUCT_POS, false, false, param1, param2, param3, param4, param5); }
        public float FLD_GET_DUCT_POS(int param1) { return CallFloatFlowFunction(FlowFunction.FLD_GET_DUCT_POS, false, false, param1); }
        public void FLD_SET_CAMERA_DEFAULT_POS(int param1) { CallFlowFunction(FlowFunction.FLD_SET_CAMERA_DEFAULT_POS, false, false, param1); }
        public void FLD_PANEL_GUIDE_UNDISP(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PANEL_GUIDE_UNDISP, false, false, param1, param2); }
        public void FLD_GEN_FISHING_SEED() { CallFlowFunction(FlowFunction.FLD_GEN_FISHING_SEED, false, false); }
        public void FLD_CASINO_WORK_INIT() { CallFlowFunction(FlowFunction.FLD_CASINO_WORK_INIT, false, false); }
        public void FLD_CLEAR_COVER_STATE(int param1) { CallFlowFunction(FlowFunction.FLD_CLEAR_COVER_STATE, false, false, param1); }
        public void FLD_SET_ENEMY_ORNAMENT(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SET_ENEMY_ORNAMENT, false, false, param1, param2, param3); }
        public int FLD_PANEL_GUIDE_UNDISP_CHECK(int param1) { return CallFlowFunction(FlowFunction.FLD_PANEL_GUIDE_UNDISP_CHECK, false, false, param1); }
        public void FLD_PANEL_COIN_SET_ENABLE(int param1) { CallFlowFunction(FlowFunction.FLD_PANEL_COIN_SET_ENABLE, false, false, param1); }
        public int FLD_PANEL_COIN_CHECK_ENABLE() { return CallFlowFunction(FlowFunction.FLD_PANEL_COIN_CHECK_ENABLE, false, false); }
        public void FLD_ROADMAP_MMAP_OPEN(int param1) { CallFlowFunction(FlowFunction.FLD_ROADMAP_MMAP_OPEN, false, false, param1); }
        public void FLD_ROADMAP_MMAP_SYNC() { CallFlowFunction(FlowFunction.FLD_ROADMAP_MMAP_SYNC, false, false); }
        public void FLD_ROADMAP_MMAP_CLOSE() { CallFlowFunction(FlowFunction.FLD_ROADMAP_MMAP_CLOSE, false, false); }
        public void FLD_SET_CAMERA_FAR_MODE(int param1) { CallFlowFunction(FlowFunction.FLD_SET_CAMERA_FAR_MODE, false, false, param1); }
        public void FLD_SET_DOOR_HIT_TYPE_DTL(int param1, int param2, int param3, int param4, int param5) { CallFlowFunction(FlowFunction.FLD_SET_DOOR_HIT_TYPE_DTL, false, false, param1, param2, param3, param4, param5); }
        public void FLD_PC_OFS_TRANSLATE(float param1, float param2, float param3, int param4) { CallFlowFunction(FlowFunction.FLD_PC_OFS_TRANSLATE, false, false, param1, param2, param3, param4); }
        public int FLD_FBNID_TO_NPCID(int param1) { return CallFlowFunction(FlowFunction.FLD_FBNID_TO_NPCID, false, false, param1); }
        public void FLD_NPC_SET_ROTATE_RATIO(int param1, float param2) { CallFlowFunction(FlowFunction.FLD_NPC_SET_ROTATE_RATIO, false, false, param1, param2); }
        public void FLD_CAMERA_SET_FOVY(float param1) { CallFlowFunction(FlowFunction.FLD_CAMERA_SET_FOVY, false, false, param1); }
        public void FLD_MODEL_DST_TRANSLATE(int param1, float param2, float param3, float param4, float param5, int param6) { CallFlowFunction(FlowFunction.FLD_MODEL_DST_TRANSLATE, false, false, param1, param2, param3, param4, param5, param6); }
        public void FLD_CAMERA_SET_FIXED_INTERP(float param1, float param2, float param3, float param4, float param5, float param6, float param7, int param8) { CallFlowFunction(FlowFunction.FLD_CAMERA_SET_FIXED_INTERP, false, false, param1, param2, param3, param4, param5, param6, param7, param8); }
        public void FLD_SET_GMK_CAMERA_UID(int param1) { CallFlowFunction(FlowFunction.FLD_SET_GMK_CAMERA_UID, false, false, param1); }
        public int FLD_GET_GMK_CAMERA_UID() { return CallFlowFunction(FlowFunction.FLD_GET_GMK_CAMERA_UID, false, false); }
        public void FLD_MMT_MAP_END() { CallFlowFunction(FlowFunction.FLD_MMT_MAP_END, false, false); }
        public void FLD_GREETING_MSG_DTL_HIGH(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_GREETING_MSG_DTL_HIGH, false, false, param1, param2, param3); }
        public void FLD_REQ_PITFALL_ENTER() { CallFlowFunction(FlowFunction.FLD_REQ_PITFALL_ENTER, false, false); }
        public void FLD_ROADMAP_MMAP_CHANGE(int param1) { CallFlowFunction(FlowFunction.FLD_ROADMAP_MMAP_CHANGE, false, false, param1); }
        public void FLD_CAR_INTERCEPT_READ(int param1) { CallFlowFunction(FlowFunction.FLD_CAR_INTERCEPT_READ, false, false, param1); }
        public void FLD_NPC_TALKICON_UNDISP_FBNID(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_TALKICON_UNDISP_FBNID, false, false, param1, param2); }
        public void FLD_CAR_ADD_ENGINE_SE(int param1) { CallFlowFunction(FlowFunction.FLD_CAR_ADD_ENGINE_SE, false, false, param1); }
        public void FLD_CAR_ENGINE_SE_ENABLE(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_CAR_ENGINE_SE_ENABLE, false, false, param1, param2); }
        public void FLD_CRAFT_ITEM_TROPHY(int param1) { CallFlowFunction(FlowFunction.FLD_CRAFT_ITEM_TROPHY, false, false, param1); }
        public void FLD_ALLY_WEAPON_SETUP() { CallFlowFunction(FlowFunction.FLD_ALLY_WEAPON_SETUP, false, false); }
        public void FLD_SYNC_SCN_CHANGE() { CallFlowFunction(FlowFunction.FLD_SYNC_SCN_CHANGE, false, false); }
        public int FLD_GET_BKUP_FIELD_TYPE() { return CallFlowFunction(FlowFunction.FLD_GET_BKUP_FIELD_TYPE, false, false); }
        public void FLD_OBJ_MODEL_LINKBG(int param1) { CallFlowFunction(FlowFunction.FLD_OBJ_MODEL_LINKBG, false, false, param1); }
        public float FLD_MODEL_GET_X_HELPER_TRANSLATE(int param1, int param2) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_X_HELPER_TRANSLATE, false, false, param1, param2); }
        public float FLD_MODEL_GET_Y_HELPER_TRANSLATE(int param1, int param2) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_Y_HELPER_TRANSLATE, false, false, param1, param2); }
        public float FLD_MODEL_GET_Z_HELPER_TRANSLATE(int param1, int param2) { return CallFloatFlowFunction(FlowFunction.FLD_MODEL_GET_Z_HELPER_TRANSLATE, false, false, param1, param2); }
        public void BGENV_LINK_BGOBJ_INDEX_ANIM(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.BGENV_LINK_BGOBJ_INDEX_ANIM, false, false, param1, param2, param3, param4); }
        public void FLD_ROADMAP_UPDATE() { CallFlowFunction(FlowFunction.FLD_ROADMAP_UPDATE, false, false); }
        public void FLD_NPC_SHADOWCAST_FBNID(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_SHADOWCAST_FBNID, false, false, param1, param2); }
        public void FLD_PTY_PANEL_SET_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_PTY_PANEL_SET_VISIBLE, false, false, param1); }
        public int CALL_PLAY_GO_SAVE() { return CallFlowFunction(FlowFunction.CALL_PLAY_GO_SAVE, false, false); }
        public void FLD_CROWD_BBEFECT_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_CROWD_BBEFECT_VISIBLE, false, false, param1); }
        public void FLD_NPC_FBN_FADE_SYNC(int param1) { CallFlowFunction(FlowFunction.FLD_NPC_FBN_FADE_SYNC, false, false, param1); }
        public void FLD_LMAP_SPOT_TROPHY_PROC() { CallFlowFunction(FlowFunction.FLD_LMAP_SPOT_TROPHY_PROC, false, false); }
        public void FLD_MISSION_LIST_END_SYNC() { CallFlowFunction(FlowFunction.FLD_MISSION_LIST_END_SYNC, false, false); }
        public void FLD_SPOT_FLAG_SET(int param1) { CallFlowFunction(FlowFunction.FLD_SPOT_FLAG_SET, false, false, param1); }
        public void FLD_REQ_NEXT_SCN_FADE(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_REQ_NEXT_SCN_FADE, false, false, param1, param2, param3, param4); }
        public int FLD_UMBREALLA_CHECK_USE() { return CallFlowFunction(FlowFunction.FLD_UMBREALLA_CHECK_USE, false, false); }
        public void FLD_PC_MODEL_REQ_WIRE_MOVE(int param1) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_REQ_WIRE_MOVE, false, false, param1); }
        public void FLD_PC_MODEL_SYNC_WIRE_MOVE(int param1) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_SYNC_WIRE_MOVE, false, false, param1); }
        public int FLD_CHECK_USE_PARAMUP_FUNC(int param1) { return CallFlowFunction(FlowFunction.FLD_CHECK_USE_PARAMUP_FUNC, false, false, param1); }
        public int FLD_GET_REWARD_NUM_PARAMUP_FUNC(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_REWARD_NUM_PARAMUP_FUNC, false, false, param1); }
        public int FLD_GET_REWARD_ID_PARAMUP_FUNC(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_GET_REWARD_ID_PARAMUP_FUNC, false, false, param1, param2); }
        public int FLD_GET_TYPE_PARAMUP_REWARD_ID(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_TYPE_PARAMUP_REWARD_ID, false, false, param1); }
        public int FLD_GET_VALUE_PARAMUP_REWARD_ID(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_VALUE_PARAMUP_REWARD_ID, false, false, param1); }
        public int FLD_TOOL_GET_CREATE_NUM() { return CallFlowFunction(FlowFunction.FLD_TOOL_GET_CREATE_NUM, false, false); }
        public void FLD_GAMBLING_TIME_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_GAMBLING_TIME_VISIBLE, false, false, param1); }
        public void FLD_ACTHIT_SET_ICON_NG(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_ACTHIT_SET_ICON_NG, false, false, param1, param2); }
        public void FLD_SET_WIRE_TARGET(int param1) { CallFlowFunction(FlowFunction.FLD_SET_WIRE_TARGET, false, false, param1); }
        public void FLD_PC_MODEL_SET_WIRE_SPEED(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_PC_MODEL_SET_WIRE_SPEED, false, false, param1, param2); }
        public void FLD_ENTER_BY_WALK_DISABLE() { CallFlowFunction(FlowFunction.FLD_ENTER_BY_WALK_DISABLE, false, false); }
        public void FLD_SET_WIRE_TARGET_EFFECT(int param1) { CallFlowFunction(FlowFunction.FLD_SET_WIRE_TARGET_EFFECT, false, false, param1); }
        public int FLD_GET_TOTAL_STAMP_POINT() { return CallFlowFunction(FlowFunction.FLD_GET_TOTAL_STAMP_POINT, false, false); }
        public void FLD_SET_DBG_ATDNG_PROGRESS(int param1) { CallFlowFunction(FlowFunction.FLD_SET_DBG_ATDNG_PROGRESS, false, false, param1); }
        public int FLD_GET_QUEST_ATDNG_PARAM(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_QUEST_ATDNG_PARAM, false, false, param1); }
        public void FLD_MODEL_ADJUST_GROUND(int param1) { CallFlowFunction(FlowFunction.FLD_MODEL_ADJUST_GROUND, false, false, param1); }
        public void FLD_MODEL_SET_NPC_POS(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_MODEL_SET_NPC_POS, false, false, param1, param2); }
        public int FLD_CAMERA_CHECK_LOCK() { return CallFlowFunction(FlowFunction.FLD_CAMERA_CHECK_LOCK, false, false); }
        public int FLD_SEARCH_POL_RESHND(int param1) { return CallFlowFunction(FlowFunction.FLD_SEARCH_POL_RESHND, false, false, param1); }
        public void FLD_ANIM_HIT_IMMEDIATE() { CallFlowFunction(FlowFunction.FLD_ANIM_HIT_IMMEDIATE, false, false); }
        public void FLD_SET_BACK_LOG_LOCK(int param1) { CallFlowFunction(FlowFunction.FLD_SET_BACK_LOG_LOCK, false, false, param1); }
        public int FLD_ASSIST_GET_DISTINATION(int param1) { return CallFlowFunction(FlowFunction.FLD_ASSIST_GET_DISTINATION, false, false, param1); }
        public void FLD_NPC_GREETING_DISABLE_FBNID(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_GREETING_DISABLE_FBNID, false, false, param1, param2); }
        public void FLD_AST_SET_REINFORCE_DATA(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_AST_SET_REINFORCE_DATA, false, false, param1, param2); }
        public void FLD_AST_SET_COOP_DATA(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_AST_SET_COOP_DATA, false, false, param1, param2); }
        public int FLD_AST_GET_REINFORCE_INDEX(int param1) { return CallFlowFunction(FlowFunction.FLD_AST_GET_REINFORCE_INDEX, false, false, param1); }
        public int FLD_AST_GET_COOP_INDEX(int param1) { return CallFlowFunction(FlowFunction.FLD_AST_GET_COOP_INDEX, false, false, param1); }
        public int FLD_AST_GET_PARAMID_FROM_RFIDX(int param1) { return CallFlowFunction(FlowFunction.FLD_AST_GET_PARAMID_FROM_RFIDX, false, false, param1); }
        public void FLD_ENEMY_SET_MAD_EFFECT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_ENEMY_SET_MAD_EFFECT, false, false, param1, param2); }
        public int FLD_GET_INDEX_STAMP_POINT(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_INDEX_STAMP_POINT, false, false, param1); }
        public int FLD_GET_INDEX_STAMP_COUNT(int param1) { return CallFlowFunction(FlowFunction.FLD_GET_INDEX_STAMP_COUNT, false, false, param1); }
        public void CALL_DAIFUGOU() { CallFlowFunction(FlowFunction.CALL_DAIFUGOU, false, false); }
        public void FLD_CLEAR_COIN() { CallFlowFunction(FlowFunction.FLD_CLEAR_COIN, false, false); }
        public void FLD_PARTY_STATUS_SAVE() { CallFlowFunction(FlowFunction.FLD_PARTY_STATUS_SAVE, false, false); }
        public void FLD_PARTY_HPSP_LOAD() { CallFlowFunction(FlowFunction.FLD_PARTY_HPSP_LOAD, false, false); }
        public int FLD_AST_COOP_LIST_CHECK(int param1) { return CallFlowFunction(FlowFunction.FLD_AST_COOP_LIST_CHECK, false, false, param1); }
        public int FLD_AST_FACIL_LIST_CHECK(int param1) { return CallFlowFunction(FlowFunction.FLD_AST_FACIL_LIST_CHECK, false, false, param1); }
        public void FLD_AST_DISPLAY(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_AST_DISPLAY, false, false, param1, param2, param3); }
        public int FLD_AST_FACIL_UNLOCK_CHECK() { return CallFlowFunction(FlowFunction.FLD_AST_FACIL_UNLOCK_CHECK, false, false); }
        public void SET_VTAG_HERO_CALL_PC(int param1) { CallFlowFunction(FlowFunction.SET_VTAG_HERO_CALL_PC, false, false, param1); }
        public void FLD_CROWD_SET_HIT_MODEL(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_CROWD_SET_HIT_MODEL, false, false, param1, param2); }
        public void FLD_SET_ENEMY_INOUT_EFF(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_SET_ENEMY_INOUT_EFF, false, false, param1, param2, param3); }
        public void FLD_PC_SET_MOVE_SPEED(float param1, float param2, int param3) { CallFlowFunction(FlowFunction.FLD_PC_SET_MOVE_SPEED, false, false, param1, param2, param3); }
        public int FLD_CROWD_ALL_UNMOVED_READ_WAIT() { return CallFlowFunction(FlowFunction.FLD_CROWD_ALL_UNMOVED_READ_WAIT, false, false); }
        public void FLD_NPC_TALK_DISABLE_FBNID(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_TALK_DISABLE_FBNID, false, false, param1, param2); }
        public int FLD_SET_TRANSFORM(int param1) { return CallFlowFunction(FlowFunction.FLD_SET_TRANSFORM, false, false, param1); }
        public void FLD_START_MMT_MAP_EFF(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.FLD_START_MMT_MAP_EFF, false, false, param1, param2, param3, param4); }
        public void FLD_END_MMT_MAP_EFF() { CallFlowFunction(FlowFunction.FLD_END_MMT_MAP_EFF, false, false); }
        public void FLD_MEMBER_RECOVER_DIRECT(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_MEMBER_RECOVER_DIRECT, false, false, param1, param2); }
        public void FLD_MY_PALACE_ENTER() { CallFlowFunction(FlowFunction.FLD_MY_PALACE_ENTER, false, false); }
        public void FLD_PC_PARAM_ADD_ON() { CallFlowFunction(FlowFunction.FLD_PC_PARAM_ADD_ON, false, false); }
        public void FLD_PANEL_DISP_NO_MAP(int param1) { CallFlowFunction(FlowFunction.FLD_PANEL_DISP_NO_MAP, false, false, param1); }
        public void FLD_PC_PARAM_ADD_DISP(int param1) { CallFlowFunction(FlowFunction.FLD_PC_PARAM_ADD_DISP, false, false, param1); }
        public void FLD_NPC_NEAR_PAUSE_DISABLE_FBNID(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_NEAR_PAUSE_DISABLE_FBNID, false, false, param1, param2); }
        public int FLD_AST_CHK_SEL_HIDEOUT() { return CallFlowFunction(FlowFunction.FLD_AST_CHK_SEL_HIDEOUT, false, false); }
        public int FLD_MY_PALACE_GET_ITEM(int param1) { return CallFlowFunction(FlowFunction.FLD_MY_PALACE_GET_ITEM, false, false, param1); }
        public int FLD_CHECK_USABLE_SNEAKING_ITEM(int param1) { return CallFlowFunction(FlowFunction.FLD_CHECK_USABLE_SNEAKING_ITEM, false, false, param1); }
        public int FLD_GET_QR_ID() { return CallFlowFunction(FlowFunction.FLD_GET_QR_ID, false, false); }
        public void FLD_DISP_QR(int param1) { CallFlowFunction(FlowFunction.FLD_DISP_QR, false, false, param1); }
        public void FLD_BG_WEATHER_EFF_VISIBLE(int param1) { CallFlowFunction(FlowFunction.FLD_BG_WEATHER_EFF_VISIBLE, false, false, param1); }
        public void FLD_SE_PLAY(int param1) { CallFlowFunction(FlowFunction.FLD_SE_PLAY, false, false, param1); }
        public void FLD_DEC_SAFEROOM_ALERT() { CallFlowFunction(FlowFunction.FLD_DEC_SAFEROOM_ALERT, false, false); }
        public void FLD_UPDATE_DAYS_ALERT() { CallFlowFunction(FlowFunction.FLD_UPDATE_DAYS_ALERT, false, false); }
        public void FLD_DAIFUGOU_SET_SEL_NO(int param1) { CallFlowFunction(FlowFunction.FLD_DAIFUGOU_SET_SEL_NO, false, false, param1); }
        public void FLD_NPC_SET_NAMEID(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_NPC_SET_NAMEID, false, false, param1, param2); }
        public int FLD_NPC_GET_NAMEID(int param1) { return CallFlowFunction(FlowFunction.FLD_NPC_GET_NAMEID, false, false, param1); }
        public int FLD_TOOL_SCR_GET_BONUS_NUM(int param1, int param2) { return CallFlowFunction(FlowFunction.FLD_TOOL_SCR_GET_BONUS_NUM, false, false, param1, param2); }
        public void FLD_MAP_PANEL_CANCEL() { CallFlowFunction(FlowFunction.FLD_MAP_PANEL_CANCEL, false, false); }
        public void FLD_COMSE_PLAY(int param1) { CallFlowFunction(FlowFunction.FLD_COMSE_PLAY, false, false, param1); }
        public void FLD_COMSE_STOP(int param1) { CallFlowFunction(FlowFunction.FLD_COMSE_STOP, false, false, param1); }
        public void FLD_GMC_LIGHT_SET_SCRIPT(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.FLD_GMC_LIGHT_SET_SCRIPT, false, false, param1, param2, param3); }
        public int FLD_GMC_LIGHT_GET_VALUE() { return CallFlowFunction(FlowFunction.FLD_GMC_LIGHT_GET_VALUE, false, false); }
        public void FLD_SET_BATTLE_FIELD(int param1, int param2) { CallFlowFunction(FlowFunction.FLD_SET_BATTLE_FIELD, false, false, param1, param2); }
        public void FLD_SET_ANOTHER_ENV(int param1) { CallFlowFunction(FlowFunction.FLD_SET_ANOTHER_ENV, false, false, param1); }
        public void FLD_REQ_CA_RIPPLE() { CallFlowFunction(FlowFunction.FLD_REQ_CA_RIPPLE, false, false); }
        public void FLD_MY_PALACE_REQ_ANNOUNCE() { CallFlowFunction(FlowFunction.FLD_MY_PALACE_REQ_ANNOUNCE, false, false); }
        public void FLD_START_TELOP(int param1) { CallFlowFunction(FlowFunction.FLD_START_TELOP, false, false, param1); }
        public float FLD_GET_GROUND_Y(int param1, int param2, int param3) { return CallFloatFlowFunction(FlowFunction.FLD_GET_GROUND_Y, false, false, param1, param2, param3); }
        public int FLD_GET_DNG_QUEST_NO___2() { return CallFlowFunction(FlowFunction.FLD_GET_DNG_QUEST_NO___2, false, false); }
        public void FLD_SET_DEFAULT_ALERT() { CallFlowFunction(FlowFunction.FLD_SET_DEFAULT_ALERT, false, false); }
        public int FLD_GET_COIN_COUNT() { return CallFlowFunction(FlowFunction.FLD_GET_COIN_COUNT, false, false); }
        public void FLD_DNG_RESET_TBOX() { CallFlowFunction(FlowFunction.FLD_DNG_RESET_TBOX, false, false); }
        public void EVT_FAST_PROC_END_SYNC() { CallFlowFunction(FlowFunction.EVT_FAST_PROC_END_SYNC, false, false); }
        public void FLD_MODEL_CLEAR_ANIM_EFF(int param1) { CallFlowFunction(FlowFunction.FLD_MODEL_CLEAR_ANIM_EFF, false, false, param1); }
        public void FLD_ROADMAP_MMAP_CLOSE_SYNC() { CallFlowFunction(FlowFunction.FLD_ROADMAP_MMAP_CLOSE_SYNC, false, false); }
        public void NET_SET_AFTER_SCHOOL_ACTION(int param1) { CallFlowFunction(FlowFunction.NET_SET_AFTER_SCHOOL_ACTION, false, false, param1); }
        public void NET_SET_NIGHT_ACTION(int param1) { CallFlowFunction(FlowFunction.NET_SET_NIGHT_ACTION, false, false, param1); }
        public void NET_SET_ANSER_SELECT_NUM(int param1) { CallFlowFunction(FlowFunction.NET_SET_ANSER_SELECT_NUM, false, false, param1); }
        public void NET_SET_ANSER_SUCCESS(int param1) { CallFlowFunction(FlowFunction.NET_SET_ANSER_SUCCESS, false, false, param1); }
        public void NET_SET_STRATEGY(int param1) { CallFlowFunction(FlowFunction.NET_SET_STRATEGY, false, false, param1); }
        public void NET_SET_STRATEGY_SUCCESS(int param1) { CallFlowFunction(FlowFunction.NET_SET_STRATEGY_SUCCESS, false, false, param1); }
        public void NET_START_AUDIENCE() { CallFlowFunction(FlowFunction.NET_START_AUDIENCE, false, false); }
        public void NET_STOP_AUDIENCE() { CallFlowFunction(FlowFunction.NET_STOP_AUDIENCE, false, false); }
        public void CALL_EVENT(int param1, int param2) { CallFlowFunction(FlowFunction.CALL_EVENT, false, false, param1, param2); }
        public void EVT_ASSET_OVERWRITE(int param1, int param2, int param3, int param4, int param5, int param6, int param7, int param8) { CallFlowFunction(FlowFunction.EVT_ASSET_OVERWRITE, false, false, param1, param2, param3, param4, param5, param6, param7, param8); }
        public int EVT_GET_RESHND(int param1, int param2) { return CallFlowFunction(FlowFunction.EVT_GET_RESHND, false, false, param1, param2); }
        public int EVT_GET_ASSET_RESHND(int param1) { return CallFlowFunction(FlowFunction.EVT_GET_ASSET_RESHND, false, false, param1); }
        public void CHARA_CAMERA(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.CHARA_CAMERA, false, false, param1, param2, param3, param4); }
        public int EVT_GET_ANIMCOUNT(int param1) { return CallFlowFunction(FlowFunction.EVT_GET_ANIMCOUNT, false, false, param1); }
        public int EVT_GET_ANIMCOUNT_U() { return CallFlowFunction(FlowFunction.EVT_GET_ANIMCOUNT_U, false, false); }
        public int EVT_GET_ANIMCOUNT_D() { return CallFlowFunction(FlowFunction.EVT_GET_ANIMCOUNT_D, false, false); }
        public int EVT_GET_ANIMCOUNT_L() { return CallFlowFunction(FlowFunction.EVT_GET_ANIMCOUNT_L, false, false); }
        public int EVT_GET_ANIMCOUNT_R() { return CallFlowFunction(FlowFunction.EVT_GET_ANIMCOUNT_R, false, false); }
        public void CUTIN_START(int param1, int param2, int param3, int param4) { CallFlowFunction(FlowFunction.CUTIN_START, false, false, param1, param2, param3, param4); }
        public void CUTIN_STOP(int param1) { CallFlowFunction(FlowFunction.CUTIN_STOP, false, false, param1); }
        public void CMM_OPEN(int param1) { CallFlowFunction(FlowFunction.CMM_OPEN, false, false, param1); }
        public int CMM_EXIST(int param1) { return CallFlowFunction(FlowFunction.CMM_EXIST, false, false, param1); }
        public int CMM_GET_LV(int param1) { return CallFlowFunction(FlowFunction.CMM_GET_LV, false, false, param1); }
        public void CMM_LVUP(int param1) { CallFlowFunction(FlowFunction.CMM_LVUP, false, false, param1); }
        public int CMM_CHK_LVUP(int param1) { return CallFlowFunction(FlowFunction.CMM_CHK_LVUP, false, false, param1); }
        public void CMM_ADD_POINT(int param1, int param2) { CallFlowFunction(FlowFunction.CMM_ADD_POINT, false, false, param1, param2); }
        public void CMM_ADD_POINT_ID(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.CMM_ADD_POINT_ID, false, false, param1, param2, param3); }
        public int CMM_CHK_REVERSE(int param1) { return CallFlowFunction(FlowFunction.CMM_CHK_REVERSE, false, false, param1); }
        public void CMM_SET_REVERSE(int param1, int param2) { CallFlowFunction(FlowFunction.CMM_SET_REVERSE, false, false, param1, param2); }
        public int CMM_CHK_BROKEN(int param1) { return CallFlowFunction(FlowFunction.CMM_CHK_BROKEN, false, false, param1); }
        public void CMM_SET_BROKEN(int param1, int param2) { CallFlowFunction(FlowFunction.CMM_SET_BROKEN, false, false, param1, param2); }
        public int CMM_CHK_CALL(int param1) { return CallFlowFunction(FlowFunction.CMM_CHK_CALL, false, false, param1); }
        public void CMM_SET_PROMISE(int param1) { CallFlowFunction(FlowFunction.CMM_SET_PROMISE, false, false, param1); }
        public int CMM_GET_PROMISE() { return CallFlowFunction(FlowFunction.CMM_GET_PROMISE, false, false); }
        public int CMM_CHK_PROMISE() { return CallFlowFunction(FlowFunction.CMM_CHK_PROMISE, false, false); }
        public int CMM_GET_PROMISE_DAY() { return CallFlowFunction(FlowFunction.CMM_GET_PROMISE_DAY, false, false); }
        public void CMM_SETUP_EVENT(int param1, int param2) { CallFlowFunction(FlowFunction.CMM_SETUP_EVENT, false, false, param1, param2); }
        public void CMM_EXEC_EVENT() { CallFlowFunction(FlowFunction.CMM_EXEC_EVENT, false, false); }
        public int CMM_GET_EVENT_TYPE() { return CallFlowFunction(FlowFunction.CMM_GET_EVENT_TYPE, false, false); }
        public void CMM_VSET_COMMUNITY(int param1) { CallFlowFunction(FlowFunction.CMM_VSET_COMMUNITY, false, false, param1); }
        public int CMM_VSET_PS(int param1, int param2) { return CallFlowFunction(FlowFunction.CMM_VSET_PS, false, false, param1, param2); }
        public int CMM_VSET_PSID(int param1) { return CallFlowFunction(FlowFunction.CMM_VSET_PSID, false, false, param1); }
        public void CMM_FRIEND(int param1) { CallFlowFunction(FlowFunction.CMM_FRIEND, false, false, param1); }
        public int CMM_CHK_EVENT(int param1, int param2) { return CallFlowFunction(FlowFunction.CMM_CHK_EVENT, false, false, param1, param2); }
        public void CMM_ACTIVE(int param1) { CallFlowFunction(FlowFunction.CMM_ACTIVE, false, false, param1); }
        public int CMM_GET_LOVER_HIGH() { return CallFlowFunction(FlowFunction.CMM_GET_LOVER_HIGH, false, false); }
        public int CMM_CHK_ARCANA_PSSTOCKLV(int param1) { return CallFlowFunction(FlowFunction.CMM_CHK_ARCANA_PSSTOCKLV, false, false, param1); }
        public int CMM_CHK_INVITE() { return CallFlowFunction(FlowFunction.CMM_CHK_INVITE, false, false); }
        public int CMM_CHK_FIX_INVITE() { return CallFlowFunction(FlowFunction.CMM_CHK_FIX_INVITE, false, false); }
        public void CMM_SET_INVITE(int param1) { CallFlowFunction(FlowFunction.CMM_SET_INVITE, false, false, param1); }
        public int CMM_CNV_ID(int param1) { return CallFlowFunction(FlowFunction.CMM_CNV_ID, false, false, param1); }
        public int CMM_GET_CLUB(int param1) { return CallFlowFunction(FlowFunction.CMM_GET_CLUB, false, false, param1); }
        public void CMM_ARBEIT_PAY(int param1) { CallFlowFunction(FlowFunction.CMM_ARBEIT_PAY, false, false, param1); }
        public int CMM_ARBEIT_PAY_RECEIVE() { return CallFlowFunction(FlowFunction.CMM_ARBEIT_PAY_RECEIVE, false, false); }
        public int CMM_ARBEIT_GET_MONEY(int param1) { return CallFlowFunction(FlowFunction.CMM_ARBEIT_GET_MONEY, false, false, param1); }
        public void CMM_RANKUP(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.CMM_RANKUP, false, false, param1, param2, param3); }
        public void CMM_EVERY_DAY_UPDATE_SUDDEN_DEATH() { CallFlowFunction(FlowFunction.CMM_EVERY_DAY_UPDATE_SUDDEN_DEATH, false, false); }
        public void CMM_INC_SUDDEN_DEATH_COUNT(int param1) { CallFlowFunction(FlowFunction.CMM_INC_SUDDEN_DEATH_COUNT, false, false, param1); }
        public int CMM_CHK_SUDDEN_DEATH_DOUBT(int param1) { return CallFlowFunction(FlowFunction.CMM_CHK_SUDDEN_DEATH_DOUBT, false, false, param1); }
        public int CMM_CHK_SUDDEN_DEATH(int param1) { return CallFlowFunction(FlowFunction.CMM_CHK_SUDDEN_DEATH, false, false, param1); }
        public void CMM_SET_SUDDEN_DEATH_COUNT(int param1, int param2) { CallFlowFunction(FlowFunction.CMM_SET_SUDDEN_DEATH_COUNT, false, false, param1, param2); }
        public void CMM_DEC_SUDDEN_DEATH_COUNT(int param1) { CallFlowFunction(FlowFunction.CMM_DEC_SUDDEN_DEATH_COUNT, false, false, param1); }
        public void CMM_SET_SUDDEN_DEATH_FLAGT(int param1) { CallFlowFunction(FlowFunction.CMM_SET_SUDDEN_DEATH_FLAGT, false, false, param1); }
        public void CMM_RESET_SUDDEN_DEATH_FLAG(int param1) { CallFlowFunction(FlowFunction.CMM_RESET_SUDDEN_DEATH_FLAG, false, false, param1); }
        public void CMM_GET_PERSONA_DAY_TIME_SKILL(int param1) { CallFlowFunction(FlowFunction.CMM_GET_PERSONA_DAY_TIME_SKILL, false, false, param1); }
        public int CMM_MO_GET_INDEX() { return CallFlowFunction(FlowFunction.CMM_MO_GET_INDEX, false, false); }
        public int CMM_MO_CHK_DAY() { return CallFlowFunction(FlowFunction.CMM_MO_CHK_DAY, false, false); }
        public int CMM_MO_CHK_DAY_RECEIVE() { return CallFlowFunction(FlowFunction.CMM_MO_CHK_DAY_RECEIVE, false, false); }
        public int CMM_MO_GET_MONEY(int param1, int param2) { return CallFlowFunction(FlowFunction.CMM_MO_GET_MONEY, false, false, param1, param2); }
        public int CMM_MO_SET_ITEM(int param1) { return CallFlowFunction(FlowFunction.CMM_MO_SET_ITEM, false, false, param1); }
        public void CMM_MO_VSET(int param1) { CallFlowFunction(FlowFunction.CMM_MO_VSET, false, false, param1); }
        public void CMM_DEC2_SUDDEN_DEATH_COUNT(int param1) { CallFlowFunction(FlowFunction.CMM_DEC2_SUDDEN_DEATH_COUNT, false, false, param1); }
        public void CMM_START_AUTO_COMMAND() { CallFlowFunction(FlowFunction.CMM_START_AUTO_COMMAND, false, false); }
        public int CMM_SYNC_AUTO_COMMAND() { return CallFlowFunction(FlowFunction.CMM_SYNC_AUTO_COMMAND, false, false); }
        public void CMM_NEWS_PAPER() { CallFlowFunction(FlowFunction.CMM_NEWS_PAPER, false, false); }
        public void CMM_NEWS_PAPER_SYNC() { CallFlowFunction(FlowFunction.CMM_NEWS_PAPER_SYNC, false, false); }
        public void MISSION_START(int param1) { CallFlowFunction(FlowFunction.MISSION_START, false, false, param1); }
        public void MISSION_START_SYNC(int param1) { CallFlowFunction(FlowFunction.MISSION_START_SYNC, false, false, param1); }
        public void MISSION_END(int param1) { CallFlowFunction(FlowFunction.MISSION_END, false, false, param1); }
        public void MISSION_SCRIPT_EXEC(int param1, int param2) { CallFlowFunction(FlowFunction.MISSION_SCRIPT_EXEC, false, false, param1, param2); }
        public void LBX_IN_START(int param1) { CallFlowFunction(FlowFunction.LBX_IN_START, false, false, param1); }
        public void LBX_IN_SYNC() { CallFlowFunction(FlowFunction.LBX_IN_SYNC, false, false); }
        public void LBX_OUT_START(int param1) { CallFlowFunction(FlowFunction.LBX_OUT_START, false, false, param1); }
        public void LBX_OUT_SYNC() { CallFlowFunction(FlowFunction.LBX_OUT_SYNC, false, false); }
        public void CUTIN_START2(int param1, int param2, int param3, int param4, int param5) { CallFlowFunction(FlowFunction.CUTIN_START2, false, false, param1, param2, param3, param4, param5); }
        public void CUTIN_START3(int param1, int param2, int param3, int param4, int param5, int param6) { CallFlowFunction(FlowFunction.CUTIN_START3, false, false, param1, param2, param3, param4, param5, param6); }
        public void CUTIN_START4(int param1, int param2, int param3, int param4, int param5, int param6, int param7) { CallFlowFunction(FlowFunction.CUTIN_START4, false, false, param1, param2, param3, param4, param5, param6, param7); }
        public void CALL_EVENT_TEST(int param1, int param2) { CallFlowFunction(FlowFunction.CALL_EVENT_TEST, false, false, param1, param2); }
        public void EVT_MONOTONE_START() { CallFlowFunction(FlowFunction.EVT_MONOTONE_START, false, false); }
        public void EVT_MONOTONE_END() { CallFlowFunction(FlowFunction.EVT_MONOTONE_END, false, false); }
        public void EVT_MODEL_ADD_ROTATE(int param1, float param2, float param3, float param4, int param5) { CallFlowFunction(FlowFunction.EVT_MODEL_ADD_ROTATE, false, false, param1, param2, param3, param4, param5); }
        public void CALL_EVENT_PREPARE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.CALL_EVENT_PREPARE, false, false, param1, param2, param3); }
        public void CHAT_WAIT_PAD() { CallFlowFunction(FlowFunction.CHAT_WAIT_PAD, false, false); }
        public void CHAT_SEL_LINE(int param1, int param2) { CallFlowFunction(FlowFunction.CHAT_SEL_LINE, false, false, param1, param2); }
        public void CHAT_SET_SEL(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.CHAT_SET_SEL, false, false, param1, param2, param3); }
        public int CHAT_GET_SEL(int param1, int param2) { return CallFlowFunction(FlowFunction.CHAT_GET_SEL, false, false, param1, param2); }
        public void CALL_BOOK_READ(int param1) { CallFlowFunction(FlowFunction.CALL_BOOK_READ, false, false, param1); }
        public int CMM_BOOK_READ(int param1, int param2) { return CallFlowFunction(FlowFunction.CMM_BOOK_READ, false, false, param1, param2); }
        public int CMM_BOOK_SEARCH(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.CMM_BOOK_SEARCH, false, false, param1, param2, param3); }
        public int CMM_BOOK_ACCESS(int param1, int param2) { return CallFlowFunction(FlowFunction.CMM_BOOK_ACCESS, false, false, param1, param2); }
        public int CMM_BOOK_READ_END(int param1) { return CallFlowFunction(FlowFunction.CMM_BOOK_READ_END, false, false, param1); }
        public int CHAT_CHECK_READ(int param1) { return CallFlowFunction(FlowFunction.CHAT_CHECK_READ, false, false, param1); }
        public void CHAT_SET_READ(int param1, int param2) { CallFlowFunction(FlowFunction.CHAT_SET_READ, false, false, param1, param2); }
        public int CMM_BOOK_SIZE(int param1) { return CallFlowFunction(FlowFunction.CMM_BOOK_SIZE, false, false, param1); }
        public int CMM_RAPID_BUTTON_ACTION(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.CMM_RAPID_BUTTON_ACTION, false, false, param1, param2, param3); }
        public int CMM_DAICE_BUTTON_ACTION(int param1, int param2, int param3, int param4) { return CallFlowFunction(FlowFunction.CMM_DAICE_BUTTON_ACTION, false, false, param1, param2, param3, param4); }
        public int CMM_GOLF_BUTTON_ACTION(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.CMM_GOLF_BUTTON_ACTION, false, false, param1, param2, param3); }
        public void CMM_SET_INVITE_COUNT(int param1, int param2) { CallFlowFunction(FlowFunction.CMM_SET_INVITE_COUNT, false, false, param1, param2); }
        public int CMM_GET_INVITE_COUNT(int param1) { return CallFlowFunction(FlowFunction.CMM_GET_INVITE_COUNT, false, false, param1); }
        public void CMM_COUNTUP_REVERSE_DAY() { CallFlowFunction(FlowFunction.CMM_COUNTUP_REVERSE_DAY, false, false); }
        public int CMM_GET_REVERSE_DAY(int param1) { return CallFlowFunction(FlowFunction.CMM_GET_REVERSE_DAY, false, false, param1); }
        public void CMM_START_REVERSE_RENDITION(int param1) { CallFlowFunction(FlowFunction.CMM_START_REVERSE_RENDITION, false, false, param1); }
        public void CMM_START_CANCEL_REVERSE_RENDITION(int param1) { CallFlowFunction(FlowFunction.CMM_START_CANCEL_REVERSE_RENDITION, false, false, param1); }
        public void CMM_START_BROKEN_RENDITION(int param1) { CallFlowFunction(FlowFunction.CMM_START_BROKEN_RENDITION, false, false, param1); }
        public void CMM_FUNC_LIST_DRAW_START(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.CMM_FUNC_LIST_DRAW_START, false, false, param1, param2, param3); }
        public void CMM_FUNC_LIST_DRAW_END() { CallFlowFunction(FlowFunction.CMM_FUNC_LIST_DRAW_END, false, false); }
        public int CMM_CHECK_NOW_ACTIVE(float param1) { return CallFlowFunction(FlowFunction.CMM_CHECK_NOW_ACTIVE, false, false, param1); }
        public int CMM_FLAG_CONVERT(float param1, float param2) { return CallFlowFunction(FlowFunction.CMM_FLAG_CONVERT, false, false, param1, param2); }
        public void CMM_AREA_NAME_DISP(int param1) { CallFlowFunction(FlowFunction.CMM_AREA_NAME_DISP, false, false, param1); }
        public void CMM_TIMEWARP() { CallFlowFunction(FlowFunction.CMM_TIMEWARP, false, false); }
        public int CMM_CHECK_ENABLE_FUNC(int param1) { return CallFlowFunction(FlowFunction.CMM_CHECK_ENABLE_FUNC, false, false, param1); }
        public void EVT_SET_LOCAL_COUNT(int param1, int param2) { CallFlowFunction(FlowFunction.EVT_SET_LOCAL_COUNT, false, false, param1, param2); }
        public int EVT_GET_LOCAL_COUNT(int param1) { return CallFlowFunction(FlowFunction.EVT_GET_LOCAL_COUNT, false, false, param1); }
        public int CHAT_CHECK_ARRIVAL(int param1) { return CallFlowFunction(FlowFunction.CHAT_CHECK_ARRIVAL, false, false, param1); }
        public int CHAT_GET_ARRIVAL_TIME(int param1) { return CallFlowFunction(FlowFunction.CHAT_GET_ARRIVAL_TIME, false, false, param1); }
        public int CHAT_CHECK_PASS_TIME_ARRIVAL(int param1) { return CallFlowFunction(FlowFunction.CHAT_CHECK_PASS_TIME_ARRIVAL, false, false, param1); }
        public void CALL_STAFF_ROLL() { CallFlowFunction(FlowFunction.CALL_STAFF_ROLL, false, false); }
        public void EVT_SET_LOCAL_DATA(int param1, int param2) { CallFlowFunction(FlowFunction.EVT_SET_LOCAL_DATA, false, false, param1, param2); }
        public int EVT_GET_LOCAL_DATA(int param1) { return CallFlowFunction(FlowFunction.EVT_GET_LOCAL_DATA, false, false, param1); }
        public int CMM_RAPID_BUTTON_ACTION2(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.CMM_RAPID_BUTTON_ACTION2, false, false, param1, param2, param3); }
        public int CMM_DAICE_BUTTON_ACTION2(int param1, int param2) { return CallFlowFunction(FlowFunction.CMM_DAICE_BUTTON_ACTION2, false, false, param1, param2); }
        public int CMM_DAICE_BUTTON_GET_DAICE(int param1) { return CallFlowFunction(FlowFunction.CMM_DAICE_BUTTON_GET_DAICE, false, false, param1); }
        public int CMM_GOLF_BUTTON_ACTION2(int param1, int param2, int param3, int param4) { return CallFlowFunction(FlowFunction.CMM_GOLF_BUTTON_ACTION2, false, false, param1, param2, param3, param4); }
        public int CMM_COMMAND_BUTTON_ACTION2(int param1, int param2, int param3) { return CallFlowFunction(FlowFunction.CMM_COMMAND_BUTTON_ACTION2, false, false, param1, param2, param3); }
        public void CMM_INTERROGATION_IN() { CallFlowFunction(FlowFunction.CMM_INTERROGATION_IN, false, false); }
        public void CMM_SET_LV(int param1, int param2) { CallFlowFunction(FlowFunction.CMM_SET_LV, false, false, param1, param2); }
        public void INIT_IME_DRIVER() { CallFlowFunction(FlowFunction.INIT_IME_DRIVER, false, false); }
        public void END_IME_DRIVER() { CallFlowFunction(FlowFunction.END_IME_DRIVER, false, false); }
        public void EVT_SE_PLAY(int param1, int param2) { CallFlowFunction(FlowFunction.EVT_SE_PLAY, false, false, param1, param2); }
        public void EVT_SE_STOP(int param1, float param2) { CallFlowFunction(FlowFunction.EVT_SE_STOP, false, false, param1, param2); }
        public void KFEVT_EPL_READ(float param1, float param2) { CallFlowFunction(FlowFunction.KFEVT_EPL_READ, false, false, param1, param2); }
        public void KFEVT_EPL_READ_SYNC() { CallFlowFunction(FlowFunction.KFEVT_EPL_READ_SYNC, false, false); }
        public void KFEVT_EPL_FREE() { CallFlowFunction(FlowFunction.KFEVT_EPL_FREE, false, false); }
        public void KFEVT_EPL_PLAY() { CallFlowFunction(FlowFunction.KFEVT_EPL_PLAY, false, false); }
        public int GET_CHAT_INVITE_TIMING(float param1, float param2) { return CallFlowFunction(FlowFunction.GET_CHAT_INVITE_TIMING, false, false, param1, param2); }
        public void MDL_ANIM_LINK_EVTSE(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.MDL_ANIM_LINK_EVTSE, false, false, param1, param2, param3); }
        public void INVITE_WORK_INIT() { CallFlowFunction(FlowFunction.INVITE_WORK_INIT, false, false); }
        public void SET_INVITE_WORK(float param1, float param2) { CallFlowFunction(FlowFunction.SET_INVITE_WORK, false, false, param1, param2); }
        public int GET_INVITE_WORK(float param1) { return CallFlowFunction(FlowFunction.GET_INVITE_WORK, false, false, param1); }
        public int GET_INVITE_CORP_MAX() { return CallFlowFunction(FlowFunction.GET_INVITE_CORP_MAX, false, false); }
        public void EVT_SET_LOG_DISP(int param1) { CallFlowFunction(FlowFunction.EVT_SET_LOG_DISP, false, false, param1); }
        public int CMM_CHECK_ENABLE_FUNC_DETAIL(int param1) { return CallFlowFunction(FlowFunction.CMM_CHECK_ENABLE_FUNC_DETAIL, false, false, param1); }
        public int GET_PM_CHAT_INVITE_TYPE(int param1, int param2, int param3, int param4) { return CallFlowFunction(FlowFunction.GET_PM_CHAT_INVITE_TYPE, false, false, param1, param2, param3, param4); }
        public void CMM_TIMEWARP_FADE() { CallFlowFunction(FlowFunction.CMM_TIMEWARP_FADE, false, false); }
        public int CHECK_PUBLIC_HOLIDAY_NEXTDAY(int param1, int param2) { return CallFlowFunction(FlowFunction.CHECK_PUBLIC_HOLIDAY_NEXTDAY, false, false, param1, param2); }
        public void SET_STR_PUBLIC_HOLIDAY_NEXTDAY(int param1, int param2) { CallFlowFunction(FlowFunction.SET_STR_PUBLIC_HOLIDAY_NEXTDAY, false, false, param1, param2); }
        public int GET_CONQUEST_DUNGEON() { return CallFlowFunction(FlowFunction.GET_CONQUEST_DUNGEON, false, false); }
        public int GET_DUNGEON_INVITE_CHAT(float param1) { return CallFlowFunction(FlowFunction.GET_DUNGEON_INVITE_CHAT, false, false, param1); }
        public void EVT_SET_ENABLE_CTRL_KEY(int param1) { CallFlowFunction(FlowFunction.EVT_SET_ENABLE_CTRL_KEY, false, false, param1); }
        public void MSG_BACKLOG_PAUSE_ON() { CallFlowFunction(FlowFunction.MSG_BACKLOG_PAUSE_ON, false, false); }
        public void MSG_BACKLOG_PAUSE_OFF() { CallFlowFunction(FlowFunction.MSG_BACKLOG_PAUSE_OFF, false, false); }
        public void EVT_LEADING_REQUEST(int param1, int param2) { CallFlowFunction(FlowFunction.EVT_LEADING_REQUEST, false, false, param1, param2); }
        public void EVT_SET_SKIP_KEEP_FLAG(int param1) { CallFlowFunction(FlowFunction.EVT_SET_SKIP_KEEP_FLAG, false, false, param1); }
        public void EVT_GET_SKIP_KEEP_FLAG() { CallFlowFunction(FlowFunction.EVT_GET_SKIP_KEEP_FLAG, false, false); }
        public void EVT_MSG_LOG_CLEAR() { CallFlowFunction(FlowFunction.EVT_MSG_LOG_CLEAR, false, false); }
        public void EVT_FAST_PROC_START() { CallFlowFunction(FlowFunction.EVT_FAST_PROC_START, false, false); }
        public void EVT_FAST_PROC_END() { CallFlowFunction(FlowFunction.EVT_FAST_PROC_END, false, false); }
        public void EVT_FAST_CANCEL_REQ() { CallFlowFunction(FlowFunction.EVT_FAST_CANCEL_REQ, false, false); }
        public void CMM_MEMORY_GAME_SET_BUTTON(int param1, int param2, int param3, int param4, int param5, int param6, int param7, int param8) { CallFlowFunction(FlowFunction.CMM_MEMORY_GAME_SET_BUTTON, false, false, param1, param2, param3, param4, param5, param6, param7, param8); }
        public void CMM_MEMORY_GAME_SET_TIME(int param1) { CallFlowFunction(FlowFunction.CMM_MEMORY_GAME_SET_TIME, false, false, param1); }
        public int CMM_MEMORY_GAME_START() { return CallFlowFunction(FlowFunction.CMM_MEMORY_GAME_START, false, false); }
        public void CMM_CHANGE_ARCANA_YOSIZAWA() { CallFlowFunction(FlowFunction.CMM_CHANGE_ARCANA_YOSIZAWA, false, false); }
        public void CMM_CHANGE_DISP_ID(int param1) { CallFlowFunction(FlowFunction.CMM_CHANGE_DISP_ID, false, false, param1); }
        public int CMM_CHK_RANKUP_EVENT_NEXT(int param1, int param2) { return CallFlowFunction(FlowFunction.CMM_CHK_RANKUP_EVENT_NEXT, false, false, param1, param2); }
        public int CMM_CHK_INSERT_EVENT_RUBURAN(int param1, int param2) { return CallFlowFunction(FlowFunction.CMM_CHK_INSERT_EVENT_RUBURAN, false, false, param1, param2); }
        public void EVT_CA_START() { CallFlowFunction(FlowFunction.EVT_CA_START, false, false); }
        public void EVT_CA_END() { CallFlowFunction(FlowFunction.EVT_CA_END, false, false); }
        public void EVT_SET_KFREE_SETTING(int param1, int param2) { CallFlowFunction(FlowFunction.EVT_SET_KFREE_SETTING, false, false, param1, param2); }
        public int CMM_HOLIDAY_INVITE_CHATNO(int param1, int param2, int param3, int param4, int param5) { return CallFlowFunction(FlowFunction.CMM_HOLIDAY_INVITE_CHATNO, false, false, param1, param2, param3, param4, param5); }
        public void EVT_CA_BUTTON_ANIME() { CallFlowFunction(FlowFunction.EVT_CA_BUTTON_ANIME, false, false); }
        public void EVT_MOVIE_SEEK_SYNC(int param1) { CallFlowFunction(FlowFunction.EVT_MOVIE_SEEK_SYNC, false, false, param1); }
        public void EVT_LEADING_REQUEST_TABLE(int param1, int param2) { CallFlowFunction(FlowFunction.EVT_LEADING_REQUEST_TABLE, false, false, param1, param2); }
        public void CMM_DELETE(int param1) { CallFlowFunction(FlowFunction.CMM_DELETE, false, false, param1); }
        public int CMM_GET_POINT(int param1) { return CallFlowFunction(FlowFunction.CMM_GET_POINT, false, false, param1); }
        public int CMM_GET_NEXT_POINT(int param1) { return CallFlowFunction(FlowFunction.CMM_GET_NEXT_POINT, false, false, param1); }
        public void EVT_PAUSE_PADOK_DISABLE(int param1) { CallFlowFunction(FlowFunction.EVT_PAUSE_PADOK_DISABLE, false, false, param1); }
        public void CMM_ADD_POINT_ID_ST(int param1, int param2, int param3) { CallFlowFunction(FlowFunction.CMM_ADD_POINT_ID_ST, false, false, param1, param2, param3); }
        public void CMM_SYNC_POINT_ID_ST() { CallFlowFunction(FlowFunction.CMM_SYNC_POINT_ID_ST, false, false); }
        public void EVT_BACKLOG_STOP(int param1) { CallFlowFunction(FlowFunction.EVT_BACKLOG_STOP, false, false, param1); }
        public void EVT_MOUSE_INPUT_ENABLE() { CallFlowFunction(FlowFunction.EVT_MOUSE_INPUT_ENABLE, false, false); }
    }
}
