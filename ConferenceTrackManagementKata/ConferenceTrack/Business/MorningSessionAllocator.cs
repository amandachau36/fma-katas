using System;
using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public class MorningSessionAllocator : ISessionAllocator
    {
        public TimeSpan StartTime { get; }
        
        public TimeSpan MinEndTime { get; }
        
        public TimeSpan MaxEndTime { get; }

        private readonly TimeSpan _sessionDuration;

        public MorningSessionAllocator(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            MinEndTime = endTime; //TODO: can this be simplified more 
            MaxEndTime = endTime;
            _sessionDuration = endTime - startTime;
        }

        public List<Talk> AllocateTalks(List<Talk> availableTalks)
        {
            var totalDuration = 0D;

            var time = StartTime;

            var allocatedTalks = new List<Talk>();

            foreach (var talk in availableTalks)
            {
                if (talk.IsAllocated) continue;
                
                if (totalDuration + talk.Duration > _sessionDuration.TotalMinutes) continue;
                
                allocatedTalks.Add(talk);
                talk.UpdateIsAllocated(true);
                talk.SetTalkTime(time);
                time = time.Add(TimeSpan.FromMinutes(talk.Duration));
                totalDuration += talk.Duration;
            }
            
            return allocatedTalks;
        }
    }
}