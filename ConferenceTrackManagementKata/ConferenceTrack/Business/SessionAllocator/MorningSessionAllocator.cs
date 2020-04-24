using System;
using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business.SessionAllocator
{
    public class MorningSessionAllocator : ISessionAllocator
    {
        public TimeSpan StartTime { get; }
        public TimeSpan MinEndTime { get; } 
        public TimeSpan MaxEndTime { get; }
        public List<List<Talk>> Sessions { get; } = new List<List<Talk>>();  //TODO: session object with total time and list of talks? 
        public MorningSessionAllocator(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            MinEndTime = endTime; //TODO: can this be simplified more 
            MaxEndTime = endTime;
        }
        public void AllocateTalksToSession(List<Talk> availableTalks)
        {

            var time = StartTime;  //TODO: take out all custom logic

            var session = new List<Talk>();

            foreach (var talk in availableTalks)
            {
                if (talk.IsAllocated) continue;

                var newTime = time.Add(TimeSpan.FromMinutes(talk.Duration));
                
                //TODO: duration > session throw exception
                
                if (newTime > MaxEndTime ) continue;
                
                AddTalkToSession(session, talk, time);
                
                time = newTime;
                
                if (time > MinEndTime) break; 
             
            }
            
            AddLunchToSession(session);
            
            Sessions.Add(session);
        }

        private void AddTalkToSession(List<Talk> session, Talk talk, TimeSpan time)
        {
            session.Add(talk);
                
            talk.SetIsAllocated(true);
                
            talk.SetTalkTime(time);
        }
        
        private void AddLunchToSession(List<Talk> allocatedTalks)
        {
            var lunch = new Talk("Lunch", 60);
            
            lunch.SetIsAllocated(true);
            
            lunch.SetTalkTime(MaxEndTime);
            
            allocatedTalks.Add(lunch);
        }
        
    }
}