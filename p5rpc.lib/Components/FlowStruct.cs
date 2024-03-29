﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p5rpc.lib.Components
{
    internal unsafe class FlowStruct
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct FlowFunctionGroup
        {
            internal FlowFunctionInfo* Functions { get; }
            internal long NumFunctions { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct FlowFunctionInfo
        {
            internal nuint Function { get; }
            internal long NumArguments { get; }
            internal char* Name { get; }
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct FlowContext
        {
            [FieldOffset(0x2c)]
            internal int NumArgs;
            [FieldOffset(0x30)]
            internal fixed byte ArgTypes[32];
            [FieldOffset(0x58)]
            internal fixed long Arguments[32];
            [FieldOffset(0x1D8)]
            internal int IntReturnValue;
            [FieldOffset(0x1D8)]
            internal float FloatReturnValue;
            [FieldOffset(0x224)]
            internal int WaitingFlag;
        }

        public enum ArgType : byte
        {
            Integer = 0,
            Float = 1,
        }
        internal class FlowCallInfo
        {
            internal FlowFunctionInfo FunctionInfo { get; }
            internal FlowContext* Context { get; }
            internal volatile bool CallFinished;
            internal FlowCallInfo(FlowFunctionInfo functionInfo, FlowContext* context)
            {
                FunctionInfo = functionInfo;
                Context = context;
                CallFinished = false;
            }
        }
    }
}
