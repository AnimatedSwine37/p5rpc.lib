using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static p5rpc.lib.interfaces.Sequence;

namespace p5rpc.lib.Components
{
    internal class InternalSequence
    {
        /// <summary>
        /// The struct that contains the pointer to sequence info (probably other useful stuff as well)
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        internal unsafe struct SequenceStruct
        {
            [FieldOffset(72)]
            internal InternalSequenceInfo* SequenceInfo;
        }

        /// <summary>
        /// Information about the current sequence
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        internal unsafe struct InternalSequenceInfo
        {
            [FieldOffset(0)]
            internal int Field0;
            [FieldOffset(4)]
            internal SequenceType CurrentSequence;
            [FieldOffset(8)]
            internal SequenceType LastSequence;
            [FieldOffset(12)]
            internal int Field3;
            [FieldOffset(16)]
            internal int Field4;
            [FieldOffset(20)]
            internal int Field5;
            /// <summary>
            /// Information about the current event (if there is one). Always check that this isn't null before using it!
            /// </summary>
            [FieldOffset(24)]
            internal EventInfo* EventInfo;
        }

        internal static unsafe SequenceInfo InternalSequenceToPublic(InternalSequenceInfo internalInfo)
        {
            return new SequenceInfo(internalInfo.CurrentSequence, internalInfo.LastSequence, internalInfo.EventInfo == null ? new EventInfo() : *internalInfo.EventInfo);
        }

    }
}
