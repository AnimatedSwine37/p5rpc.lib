using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static p5rpc.lib.interfaces.Sequence;

namespace p5rpc.lib.interfaces
{
    public interface ISequencer
    {
        /// <summary>
        /// This event occurs whenever the current sequence changes in any way
        /// </summary>
        public event SequenceChangedEvent SequenceChanged;

        /// <summary>
        /// Gets information about the current sequence
        /// </summary>
        public SequenceInfo GetSequenceInfo();
    }

    /// <summary>
    /// A delegate for an event that occurs whenever the current sequence changes in any way
    /// </summary>
    /// <param name="sequence">The information about the new sequence</param>
    public delegate void SequenceChangedEvent(SequenceInfo sequence);
}
