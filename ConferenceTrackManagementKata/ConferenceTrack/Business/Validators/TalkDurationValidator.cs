using System;
using ConferenceTrack.Business.Blocks;

namespace ConferenceTrack.Business.Validators
{
    public class TalkDurationValidator
    {
        public bool IsValid(Block block, double sessionDuration)
        {
            return block.BlockDuration <= sessionDuration;
        }
    }
}