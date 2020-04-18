using System;
using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public interface ISessionAllocator
    {
        TimeSpan StartTime { get; }
        
        TimeSpan MinEndTime { get; }
        
        TimeSpan MaxEndTime { get; }

        List<Talk> AllocateTalks(List<Talk> availableTalks);
    }
}