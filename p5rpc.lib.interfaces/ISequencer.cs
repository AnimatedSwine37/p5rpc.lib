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
        /// This event occurs whenever an event starts in game
        /// </summary>
        public event EventStartedEvent EventStarted;

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

    /// <summary>
    /// A delegate for an event that occurs whenever the game starts a new event
    /// </summary>
    /// <param name="eventInfo">The information about the event that's starting</param>
    public delegate void EventStartedEvent(EventInfo eventInfo);
}
