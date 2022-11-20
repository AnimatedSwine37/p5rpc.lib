using p5rpc.lib.interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static p5rpc.lib.interfaces.FlowStruct;

namespace p5rpc.lib
{
    internal unsafe class FlowCaller : IFlowCaller
    {

        private FlowFunctionGroup* _flowFunctions;
        
        internal FlowCaller(IStartupScanner startupScanner, IReloadedHooks hooks)
        {
            startupScanner.AddMainModuleScan("4C 8D 3D ?? ?? ?? ?? 8B F5", result =>
            {
                if(!result.Found)
                {
                    Utils.LogError("Unable to find call flow function, won't be able to call flow functions :(");
                    return;
                }
                Utils.LogDebug($"Found call flow function at 0x{result.Offset + Utils.BaseAddress:X}");
                _flowFunctions = (FlowFunctionGroup*)Utils.GetGlobalAddress((nuint)result.Offset + (nuint)Utils.BaseAddress + 3);
                InitFlowFunctions();
            });
        }

        private void InitFlowFunctions()
        {
            foreach (FlowFunctionGroupType groupType in Enum.GetValues(typeof(FlowFunctionGroupType)))
            {
                FlowFunctionGroup group = _flowFunctions[(int)groupType];
                for(int i = 0; i < group.NumFunctions; i++)
                {
                    
                }
            }
        }

        public void CallFlowFunction(FlowFunctions function)
        {
            CallFlowFunction((FlowFunctionGroupType)((int)function >> 0xc & 0xf), (int)function & 0xfff);
        }

        public void CallFlowFunction(FlowFunctionGroupType group, int functionId)
        {
            if (functionId > _flowFunctions[(int)group].NumFunctions)
            {
                Utils.LogError($"Function id {functionId} is out of range for group {group}");
                return;
            }
            FlowFunctionInfo function = _flowFunctions[(int)group].Functions[functionId];
            string name = Marshal.PtrToStringAnsi((nint)function.Name);
            Utils.LogDebug($"Calling flow function {name} with id {functionId} at 0x{function.Function:X} with {function.NumArguments} arguments");
            
            ((delegate* unmanaged[Stdcall]<nuint, void>)function.Function)(0);
        }

        private void SetArg(int argNum, int value)
        {
            
        }
    }
}
