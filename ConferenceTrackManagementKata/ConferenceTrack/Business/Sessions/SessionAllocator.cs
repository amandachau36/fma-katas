using System;
using System.Collections.Generic;
using ConferenceTrack.Business.Blocks;
using ConferenceTrack.Business.Config;
using ConferenceTrack.Business.Exceptions;
using ConferenceTrack.Business.Validators;

namespace ConferenceTrack.Business.Sessions
{
    public class SessionAllocator
    {
        private readonly TalkDurationValidator _talkDurationValidator;
        
        private readonly Block _breakEvent;
        private readonly TimeSpan _startTime;
        private readonly TimeSpan _minEndTime;
        private readonly TimeSpan _maxEndTime;
        private readonly TimeSpan _maxDuration;
        public List<List<Block>> Sessions { get; } = new List<List<Block>>();  //TODO: session object with total time and list of talks? 
        
        public SessionAllocator(SessionConfiguration sessionConfiguration, TalkDurationValidator talkDurationValidator)
        {
            _breakEvent = sessionConfiguration.BreakEvent;
            _startTime = sessionConfiguration.StartTime;
            _minEndTime = sessionConfiguration.MinEndTime;
            _maxEndTime = sessionConfiguration.MaxEndTime;
            _maxDuration = _maxEndTime - _startTime;
            
            _talkDurationValidator = talkDurationValidator;
        }
        
        
        public void AllocateTalksToSession(List<Block> availableTalks)
        {

            var time = _startTime;  

            var session = new List<Block>();

            foreach (var talk in availableTalks)
            {
                if (!_talkDurationValidator.IsValid(talk, _maxDuration.TotalMinutes))
                    throw new InvalidTalkDurationException(talk);
                
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