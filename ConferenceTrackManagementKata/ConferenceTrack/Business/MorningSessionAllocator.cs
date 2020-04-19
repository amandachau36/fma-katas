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
        
        public List<List<Talk>> Sessions { get; } = new List<List<Talk>>();
        
        public MorningSessionAllocator(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            MinEndTime = endTime; //TODO: can this be simplified more 
            MaxEndTime = endTime;
        }

        public void AllocateTalks(List<Talk> availableTalks)
        {

            var time = StartTime;

            var allocatedTalks = new List<Talk>();

            foreach (var talk in availableTalks)
            {
                if (talk.IsAllocated) continue;

                var newTime = time.Add(TimeSpan.FromMinutes(talk.Duration));
                
                if (newTime > MaxEndTime ) continue;
                
                allocatedTalks.Add(talk);
                
                talk.UpdateIsAllocated(true);
                
                talk.SetTalkTime(time);
                
                time = newTime;
            }
            
            Sessions.Add(allocatedTalks);
        }
    }
}