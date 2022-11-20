using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static p5rpc.lib.interfaces.FlowStruct;

namespace p5rpc.lib.interfaces
{
    public interface IFlowCaller
    {
        /// <summary>
        /// Calls a flow function with the given id
        /// </summary>
        /// <param name="group">The type of function it is (thye names of the folders the Functions are in in the script compiler library)</param>
        /// <param name="functionId">The id of the flow function (look at script compiler library for ids)</param>
        public void CallFlowFunction(FlowFunctionGroupType group, int functionId);

        /// <summary>
        /// Calls a flow function
        /// </summary>
        /// <param name="function">The flow function to call</param>
        public void CallFlowFunction(FlowFunctions function);
    }
}
