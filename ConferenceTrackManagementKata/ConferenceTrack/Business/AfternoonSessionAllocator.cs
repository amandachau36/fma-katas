using System;
using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public class AfternoonSessionAllocator : ISessionAllocator
    {
        public TimeSpan StartTime { get; }
        public TimeSpan MinEndTime { get; }
        public TimeSpan MaxEndTime { get; }

        private readonly TimeSpan _minSessionDuration;

        private readonly TimeSpan _maxSessionDuration;

        public AfternoonSessionAllocator(TimeSpan startTime, TimeSpan minEndTime, TimeSpan maxEndTime)
        {
            StartTime = startTime;
            MinEndTime = minEndTime;
            MaxEndTime = maxEndTime;
            _minSessionDuration = minEndTime - startTime;
            _maxSessionDuration = maxEndTime - startTime;
        }

        public List<Talk> AllocateTalks(List<Talk> availableTalks)
        {
            var totalDuration = 0D;

            var allocatedTalks = new List<Talk>();

            foreach (var talk in availableTalks)
            {
                if (talk.IsAllocated) continue;

                if (totalDuration + talk.Duration > _maxSessionDuration.TotalMinutes) continue;
                
                allocatedTalks.Add(talk);
                talk.UpdateIsAllocated(true);
                totalDuration += talk.Duration;

                if (totalDuration > _minSessionDuration.TotalMinutes) break;
            }
            return allocatedTalks;
        }
    }
}