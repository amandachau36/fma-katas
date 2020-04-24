using System;
using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business.SessionAllocator
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

        public void AllocateTalksToSession(List<Talk> availableTalks)
        {

            var time = StartTime;

            var session = new List<Talk>();

            foreach (var talk in availableTalks)
            {
                if (talk.IsAllocated) continue;

                var newTime = time.Add(TimeSpan.FromMinutes(talk.Duration));

                if (newTime > MaxEndTime) continue;

                AddTalkToSession(session, talk, time);

                time = newTime;

                if (time > MinEndTime) break;  //TODO: should this be >=
            }
            
            AddNetworkingEventToSession(session);
                
            Sessions.Add(session);
        }
        
        private void AddTalkToSession(List<Talk> session, Talk talk, TimeSpan time)
        {
            session.Add(talk);
            
            talk.SetIsAllocated(true);
                
            talk.SetTalkTime(time);
        }
        
        private void AddNetworkingEventToSession(List<Talk> allocatedTalks)
        {
            var networkingEvent = new Talk("Networking Event", 60);
            
            networkingEvent.SetIsAllocated(true);
            
            networkingEvent.SetTalkTime(MaxEndTime);
            
            allocatedTalks.Add(networkingEvent);
        }
    }
}