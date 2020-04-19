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
        public List<List<Talk>> Sessions { get; } = new List<List<Talk>>();

        public AfternoonSessionAllocator(TimeSpan startTime, TimeSpan minEndTime, TimeSpan maxEndTime)
        {
            StartTime = startTime;
            MinEndTime = minEndTime;
            MaxEndTime = maxEndTime;
        }

        public void AllocateTalks(List<Talk> availableTalks)
        {

            var time = StartTime;

            var allocatedTalks = new List<Talk>();

            foreach (var talk in availableTalks)
            {
                if (talk.IsAllocated) continue;

                var newTime = time.Add(TimeSpan.FromMinutes(talk.Duration));

                if (newTime > MaxEndTime) continue;

                allocatedTalks.Add(talk);

                talk.UpdateIsAllocated(true);
                talk.SetTalkTime(time);

                time = time.Add(TimeSpan.FromMinutes(talk.Duration));

                if (time > MinEndTime) break;  //TODO: should this be >=
            }

            Sessions.Add(allocatedTalks);
        }
    }
}