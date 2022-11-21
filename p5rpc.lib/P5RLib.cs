using p5rpc.lib.interfaces;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5rpc.lib
{
    internal class P5RLib : IP5RLib
    {
        public IFlowCaller FlowCaller { get; }

        internal P5RLib(IStartupScanner startupScanner, IReloadedHooks hooks)
        {
            FlowCaller = new FlowCaller(startupScanner, hooks);
        }
    }
}
