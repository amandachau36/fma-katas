using System;
using System.Threading;

namespace ConferenceTrack.Business.Blocks
{
    public class Block
    {
        public string BlockName { get; }
        public double BlockDuration { get; }
        public bool IsAllocated { get; private set; }
        public TimeSpan TimeSlot { get; private set; }
        public string FormattedBlockNameAndTimeSlot { get; private set; }

        public Block( string blockName, double blockDuration)
        {
            BlockName = blockName;
            BlockDuration = blockDuration;
            IsAllocated = false;
        }

        public void SetIsAllocated(bool isAllocated)
        {
            IsAllocated = isAllocated;
        }

        public void SetTimeSlot(TimeSpan talkTime)
        {
            TimeSlot = talkTime;
        }

        public void SetFormattedBlockNameAndTimeSlot(string scheduledTalk)
        {
            FormattedBlockNameAndTimeSlot = scheduledTalk;
        }
        
    }
}