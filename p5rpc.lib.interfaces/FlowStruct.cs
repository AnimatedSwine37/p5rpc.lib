using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p5rpc.lib.interfaces
{
    public unsafe class FlowStruct
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct FlowFunctionGroup
        {
            public FlowFunctionInfo* Functions { get; }
            public long NumFunctions { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FlowFunctionInfo
        {
            public nuint Function { get; }
            public long NumArguments { get; }
            public char* Name { get; }
        }

        public enum FlowFunctionGroupType
        {
            Common,
            Field,
            AI,
            Social,
            Facility,
            Net
        }

        public class FlowFunction<T>
        {
            public FlowFunctionGroupType Group { get; }
            public int Id { get; }

            public Func<T> Function { get; }

            public FlowFunction(FlowFunctionGroupType group, int id, Func<T> function)
            {
                Group = group;
                Id = id;
                Function = function;
            }
        }
    }
}
