using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public class TrackManager
    {
        private readonly List<Talk> _talks;
        
        private readonly MorningSessionAllocator _morningSessionAllocator;
        
        private readonly AfternoonSessionAllocator _afternoonSessionAllocator;
        public List<List<Talk>> MorningSessions { get; } = new List<List<Talk>>();
        public List<List<Talk>> AfternoonSessions { get; } = new List<List<Talk>>();
        public int NumberOfTracks { get;}
        
        public TrackManager(int numberOfTracks, List<Talk> talks, MorningSessionAllocator morningSessionAllocator, AfternoonSessionAllocator afternoonSessionAllocator)
        {
            _talks = talks;
            _morningSessionAllocator = morningSessionAllocator;
            _afternoonSessionAllocator = afternoonSessionAllocator;
            NumberOfTracks = numberOfTracks;
            
        }

        public void GenerateAllSessions()
        {
            GenerateSessions(MorningSessions, _morningSessionAllocator);
            
            GenerateSessions(AfternoonSessions, _afternoonSessionAllocator);
        }

        private void GenerateSessions(List<List<Talk>> sessions, ISessionAllocator typeOfSessionAllocator)
        {
            for (var i = 0; i < NumberOfTracks; i++)
            {
                sessions.Add(typeOfSessionAllocator.AllocateTalks(_talks));
            }

        }
        
        
    
        
        
        
        
        
    }
}