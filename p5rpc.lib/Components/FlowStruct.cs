using System;
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
            internal short NumArgs;
            [FieldOffset(0x2e)]
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
    }
}
