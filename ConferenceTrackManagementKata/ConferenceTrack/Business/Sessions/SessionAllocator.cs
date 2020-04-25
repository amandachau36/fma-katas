using System;
using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business.Sessions
{
    public class SessionAllocator
    {
        private readonly Block _breakEvent;
        
        private readonly TimeSpan _startTime;
        
        private readonly TimeSpan _minEndTime;
        
        private readonly TimeSpan _maxEndTime;
        public List<List<Block>> Sessions { get; } = new List<List<Block>>();  //TODO: session object with total time and list of talks? 
        
        public SessionAllocator(TimeSpan startTime, TimeSpan endTime, Block breakEvent)
        {
            _breakEvent = breakEvent;
            _startTime = startTime;
            _minEndTime = endTime;  
            _maxEndTime = endTime;
        }
        
        public SessionAllocator(TimeSpan startTime, TimeSpan minEndTime, TimeSpan maxEndTime, Block breakEvent)
        {
            _breakEvent = breakEvent;
            _startTime = startTime;
            _minEndTime = minEndTime;
            _maxEndTime = maxEndTime;
        }
        
        
        public void AllocateTalksToSession(List<Block> availableTalks)
        {

            var time = _startTime;  //TODO: take out all custom logic

            var session = new List<Block>();

            foreach (var talk in availableTalks)
            {
                if (talk.IsAllocated) continue;

                var newTime = time.Add(TimeSpan.FromMinutes(talk.BlockDuration));
                
                //TODO: duration > session throw exception
                
                if (newTime > _maxEndTime ) continue;

                session.Add(talk);
                
                UpdateBlock(talk, time);
                
                time = newTime;
                
                if (time > _minEndTime) break; 
             
            }
            
            session.Add(_breakEvent);
            
            UpdateBlock(_breakEvent, _maxEndTime);

            Sessions.Add(session);
        }

        private void UpdateBlock(Block block, TimeSpan time)
        {
            
            block.SetIsAllocated(true);
                
            block.SetTimeSlot(time);
        }
        
        
    }
}