using System;
using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business.Sessions
{
    public class SessionAllocator
    {
        private readonly Block _breakEvent;
        public TimeSpan StartTime { get; }
        public TimeSpan MinEndTime { get; } 
        public TimeSpan MaxEndTime { get; }
        public List<List<Block>> Sessions { get; } = new List<List<Block>>();  //TODO: session object with total time and list of talks? 
        
        public SessionAllocator(TimeSpan startTime, TimeSpan endTime, Block breakEvent)
        {
            _breakEvent = breakEvent;
            StartTime = startTime;
            MinEndTime = endTime;  
            MaxEndTime = endTime;
        }
        
        public SessionAllocator(TimeSpan startTime, TimeSpan minEndTime, TimeSpan maxEndTime, Block breakEvent)
        {
            _breakEvent = breakEvent;
            StartTime = startTime;
            MinEndTime = minEndTime;
            MaxEndTime = maxEndTime;
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

                session.Add(talk);
                
                UpdateBlock(talk, time);
                
                time = newTime;
                
                if (time > MinEndTime) break; 
             
            }
            
            session.Add(_breakEvent);
            
            UpdateBlock(_breakEvent, MaxEndTime);

            Sessions.Add(session);
        }

        private void UpdateBlock(Block block, TimeSpan time)
        {
            
            block.SetIsAllocated(true);
                
            block.SetTimeSlot(time);
        }
        
        
    }
}