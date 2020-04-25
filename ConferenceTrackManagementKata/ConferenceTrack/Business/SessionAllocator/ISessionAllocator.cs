using System;
using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business.SessionAllocator
{
    public interface ISessionAllocator
    {
        TimeSpan StartTime { get; }
        
        TimeSpan MinEndTime { get; }
        
        TimeSpan MaxEndTime { get; }
        
        public List<List<Block>> Sessions { get; }

        void AllocateTalksToSession(List<Block> availableTalks);
    }
}