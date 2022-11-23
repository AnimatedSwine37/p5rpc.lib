using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5rpc.lib.interfaces
{
    public interface IP5RLib
    {
        public IFlowCaller FlowCaller { get; }
        public ISequencer Sequencer { get; }
    }
}
