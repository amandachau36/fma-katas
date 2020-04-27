using System;
using ConferenceTrack.Business.Blocks;

namespace ConferenceTrack.Business.Config
{
    public class SessionConfiguration
    {
        public TimeSpan StartTime { get;}
        
        public TimeSpan MinEndTime { get;}
        
        public TimeSpan MaxEndTime { get;}
        
        public Block BreakEvent { get;}

        public SessionConfiguration(TimeSpan startTime, TimeSpan minEndTime, TimeSpan maxEndTime, Block breakEvent)
        {
            StartTime = startTime;
            MinEndTime = minEndTime;
            MaxEndTime = maxEndTime;
            BreakEvent = breakEvent;
        }

    }
}