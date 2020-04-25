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
        public List<List<Block>> Sessions { get; } = new List<List<Block>>();  //TODO: session object with total time and list of talks? 
        public MorningSessionAllocator(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            MinEndTime = endTime; //TODO: can this be simplified more 
            MaxEndTime = endTime;
        }
        public void AllocateTalksToSession(List<Block> availableTalks)
        {

            var time = StartTime;  //TODO: take out all custom logic

            var session = new List<Block>();

            foreach (var talk in availableTalks)
            {
                if (talk.IsAllocated) continue;

                var newTime = time.Add(TimeSpan.FromMinutes(talk.BlockDuration));
                
                //TODO: duration > session throw exception
                
                if (newTime > MaxEndTime ) continue;
                
                AddTalkToSession(session, talk, time);
                
                time = newTime;
                
                if (time > MinEndTime) break; 
             
            }
            
            AddLunchToSession(session);
            
            Sessions.Add(session);
        }

        private void AddTalkToSession(List<Block> session, Block block, TimeSpan time)
        {
            session.Add(block);
                
            block.SetIsAllocated(true);
                
            block.SetTimeSlot(time);
        }
        
        private void AddLunchToSession(List<Block> allocatedTalks)
        {
            var lunch = new Block("Lunch", 60);
            
            lunch.SetIsAllocated(true);
            
            lunch.SetTimeSlot(MaxEndTime);
            
            allocatedTalks.Add(lunch);
        }
        
    }
}