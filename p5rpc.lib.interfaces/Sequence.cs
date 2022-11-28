using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p5rpc.lib.interfaces
{
    public class Sequence
    {
        /// <summary>
        /// Information about the current sequence
        /// </summary>
        public class SequenceInfo
        {
            public SequenceType CurrentSequence { get; }
            public SequenceType LastSequence { get; }
            public EventInfo? EventInfo { get; }
            
            public SequenceInfo(SequenceType currentSequence, SequenceType lastSequence, EventInfo? eventInfo)
            {
                CurrentSequence = currentSequence;
                LastSequence = lastSequence;
                EventInfo = eventInfo;
            }

            /// <summary>
            /// A default SequenceInfo has no Current and Last sequence and an empty event
            /// </summary>
            public SequenceInfo()
            {
                CurrentSequence = SequenceType.NONE;
                LastSequence = SequenceType.NONE;
            }

            public override bool Equals(object? obj)
            {
                if (obj is not SequenceInfo)
                    return false;
                SequenceInfo other = (SequenceInfo)obj;
                if (other.LastSequence != LastSequence || other.CurrentSequence != CurrentSequence)
                    return false;
                if (other.EventInfo == null)
                    return other.EventInfo == EventInfo;
                return other.EventInfo.Equals(EventInfo);
            }

            public override string ToString()
            {
                return $"Current {CurrentSequence}, Last {LastSequence}";
            }
        }


        /// <summary>
        /// Contains information about the current event
        /// </summary>
        public class EventInfo
        {
            public int Major { get; }
            public int Minor { get; }

            public EventInfo(int major, int minor)
            {
                Major = major;
                Minor = minor;
            }

            public override string ToString()
            {
                return $"{Major}_{Minor}";
            }

            public override bool Equals(object? obj)
            {
                if (obj is not EventInfo)
                    return false;
                EventInfo other = (EventInfo)obj;
                return other.Major == Major && other.Minor == Minor;
            }
        }

        
        /// <summary>
        /// The type of sequence that is currently being played (not completely accurate)
        /// </summary>
        public enum SequenceType : int
        {
            NONE = -1,
            TITLE,
            TITLE_RAPID,
            LOAD,
            FIELD,
            BATTLE,
            FIELD_VIEWER,
            EVENT,
            EVENT_VIEWER,
            MOVIE,
            MOVIE_VIEWER,
            INIT_READ,
            CALENDAR,
            CALENDAR_RESET,
            DUNGEON_RESULT
        }
    }

}

