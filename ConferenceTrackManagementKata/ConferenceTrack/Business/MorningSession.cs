using System;
using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public class MorningSession
    {
        public TimeSpan StartTime { get; }
        public TimeSpan StopTime { get; }
        
        private readonly TimeSpan _durationOfSession;

        public MorningSession(TimeSpan startTime, TimeSpan stopTime)
        {
            StartTime = startTime;
            StopTime = stopTime;
            _durationOfSession = stopTime - startTime;
        }

        public List<Talk> AllocateTalks(List<Talk> availableTalks)
        {
            var totalDuration = 0;

            var allocatedTalks = new List<Talk>();
            
            //TODO: perhaps best to convert talk times to TimeSpan instead . . .
            
            foreach (var talk in availableTalks)
            {
                if (talk.IsAllocated) continue;
                
                if (totalDuration + talk.Duration > (int) _durationOfSession.TotalMinutes) continue;
                
                allocatedTalks.Add(talk);
                talk.UpdateIsAllocated(true);
                totalDuration += talk.Duration;
                
            }
            
            return allocatedTalks;
        }
    }
}