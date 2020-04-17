using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public class TrackManager
    {
        private readonly List<Talk> _talks;
        
        private readonly MorningSession _morningSession;
        public List<List<Talk>> MorningSessions { get; } = new List<List<Talk>>();
        public int NumberOfTracks { get;}
        
        public TrackManager(int numberOfTracks, List<Talk> talks, MorningSession morningSession)
        {
            _talks = talks;
            _morningSession = morningSession;
            NumberOfTracks = numberOfTracks;
        }

        public void GenerateSessions()
        {
            for (var i = 0; i < NumberOfTracks; i++)
            {
                MorningSessions.Add(_morningSession.AllocateTalks(_talks));
            }
            
        }
        
        
    
        
        
        
        
        
    }
}