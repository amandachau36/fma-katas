using System;
using System.Collections.Generic;
using ConferenceTrack.Business.Blocks;
using ConferenceTrack.Business.Config;
using ConferenceTrack.Business.Validators;

namespace ConferenceTrack.Business.Sessions
{
    public class SessionAllocator
    {
        
        private readonly Block _breakEvent;
        private readonly TimeSpan _startTime;
        private readonly TimeSpan _minEndTime;
        private readonly TimeSpan _maxEndTime;
        public TimeSpan MaxDuration { get; }
      
        public List<List<Block>> Sessions { get; } = new List<List<Block>>();  //TODO: session object with total time and list of talks? 
        
        public SessionAllocator(SessionConfiguration sessionConfiguration)
        {
            _breakEvent = sessionConfiguration.BreakEvent;
            _startTime = sessionConfiguration.StartTime;
            _minEndTime = sessionConfiguration.MinEndTime;
            _maxEndTime = sessionConfiguration.MaxEndTime;
            
            MaxDuration = _maxEndTime - _startTime;
        }
        
        
        public void AllocateTalksToSession(IEnumerable<Block> availableTalks)
        {

            var time = _startTime;  

            var session = new List<Block>();

            foreach (var talk in availableTalks)
            {
                if (talk.IsAllocated) continue;

                var newTime = time.Add(TimeSpan.FromMinutes(talk.BlockDuration));

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