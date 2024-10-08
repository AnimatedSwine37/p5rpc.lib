﻿using p5rpc.lib.interfaces;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static p5rpc.lib.Components.InternalSequence;
using static p5rpc.lib.interfaces.Sequence;

namespace p5rpc.lib.Components
{
    internal unsafe class Sequencer : ISequencer
    {
        private SequenceStruct** _sequenceStruct;
        private SequenceInfo _lastSequence;
        private Timer _timer;

        internal Sequencer(IStartupScanner startupScanner)
        {
            startupScanner.AddMainModuleScan("48 8B 05 ?? ?? ?? ?? 66 44 89 4C 24 ??", result =>
            {
                if (!result.Found)
                {
                    Utils.LogError("Unable to find sequence info, sequence stuff won't work :(");
                    return;
                }

                _sequenceStruct = (SequenceStruct**)Utils.GetGlobalAddress((nuint)result.Offset + (nuint)Utils.BaseAddress + 3);
                Utils.LogDebug($"Sequence struct address: 0x{(nuint)_sequenceStruct:X}");
                _timer = new Timer(InitTimer, null, 0, 100);
            });
        }

        private void InitTimer(object? state)
        {
            if (*(nuint*)_sequenceStruct == 0)
                return;
            _timer.Dispose();
            _timer = new Timer(UpdateSequence, null, 0, 10);
            Utils.LogDebug($"Sequence info address: 0x{(nuint)(*_sequenceStruct)->SequenceInfo:X}");
        }


        private void UpdateSequence(object? state)
        {
            SequenceInfo currentSequence = InternalSequenceToPublic(*(*_sequenceStruct)->SequenceInfo);
            if (_lastSequence != null && _lastSequence.Equals(currentSequence))
                return;
            Utils.LogDebug($"Current sequence: {currentSequence}");
            _lastSequence = currentSequence;
            SequenceChanged?.Invoke(currentSequence);
            if (currentSequence.EventInfo != null)
                EventStarted?.Invoke(currentSequence.EventInfo);
        }

        public SequenceInfo GetSequenceInfo()
        {
            if (_sequenceStruct == null || *_sequenceStruct == null)
                return new SequenceInfo();
            else
            {
                var result = InternalSequenceToPublic(*(*_sequenceStruct)->SequenceInfo);
                Utils.LogDebug(result.ToString());
                return result;
            }
        }

        public event SequenceChangedEvent SequenceChanged;
        public event EventStartedEvent EventStarted;
    }
}
