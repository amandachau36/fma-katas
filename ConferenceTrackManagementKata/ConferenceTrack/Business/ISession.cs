using System;
using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public interface ISession
    {
        TimeSpan StartTime { get; }
        
        TimeSpan MinEndTime { get; }
        
        TimeSpan MaxEndTime { get; }
        
        TimeSpan MinSessionDuration { get; }
        
        TimeSpan MaxSessionDuration { get; }

        List<Talk> AllocateTalks(List<Talk> availableTalks);
    }
}