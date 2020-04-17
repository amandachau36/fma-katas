using System;
using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public class AfternoonSession : ISession
    {
        public TimeSpan StartTime { get; }
        public TimeSpan MinEndTime { get; }
        public TimeSpan MaxEndTime { get; }
        
        public TimeSpan MinSessionDuration { get; }
        
        public TimeSpan MaxSessionDuration { get; }

        public AfternoonSession(TimeSpan startTime, TimeSpan minEndTime, TimeSpan maxEndTime)
        {
            StartTime = startTime;
            MinEndTime = minEndTime;
            MaxEndTime = maxEndTime;
            MinSessionDuration = minEndTime - startTime;
            MaxSessionDuration = MaxEndTime - startTime;
        }

        public List<Talk> AllocateTalks(List<Talk> availableTalks)
        {
            var totalDuration = 0;

            var allocatedTalks = new List<Talk>();
            
            //TODO: perhaps best to convert talk times to TimeSpan instead . . .
            
            foreach (var talk in availableTalks)
            {
                if (talk.IsAllocated) continue;
                
                if (totalDuration + talk.Duration > (int) MaxSessionDuration.TotalMinutes) continue;
                
                allocatedTalks.Add(talk);
                talk.UpdateIsAllocated(true);
                totalDuration += talk.Duration;

                if (totalDuration > (int) MinSessionDuration.TotalMinutes) break;

            }
            
            return allocatedTalks;
        }
    }
}