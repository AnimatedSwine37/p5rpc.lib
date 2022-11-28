using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            internal SequenceInfoStruct* SequenceInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal unsafe struct EventInfoStruct
        {
            internal int Major;
            internal int Minor;
        }

        /// <summary>
        /// Information about the current sequence as it's found in memory (beware pointers!)
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        internal unsafe struct SequenceInfoStruct
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
            internal EventInfoStruct* EventInfo;
        }

        internal unsafe static SequenceInfo InternalSequenceToPublic(SequenceInfoStruct internalInfo)
        {
            return new SequenceInfo(internalInfo.CurrentSequence, internalInfo.LastSequence,
                internalInfo.EventInfo != null && (internalInfo.CurrentSequence == SequenceType.EVENT || internalInfo.CurrentSequence == SequenceType.EVENT_VIEWER) 
                ? new EventInfo((*internalInfo.EventInfo).Major, (*internalInfo.EventInfo).Minor) : null);
        }

    }
}
