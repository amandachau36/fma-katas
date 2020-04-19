using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public class TrackManager
    {
        private readonly List<Talk> _talks;
        public ISessionAllocator MorningSessionAllocator { get;}
        public ISessionAllocator AfternoonSessionAllocator { get;}
        public int NumberOfTracks { get;}
        
        public TrackManager(int numberOfTracks, List<Talk> talks, MorningSessionAllocator morningSessionAllocator, AfternoonSessionAllocator afternoonSessionAllocator)
        {
            _talks = talks;
            MorningSessionAllocator = morningSessionAllocator;
            AfternoonSessionAllocator = afternoonSessionAllocator;
            NumberOfTracks = numberOfTracks;
        }

        public void GenerateAllSessions()
        {
            GenerateSessions(MorningSessionAllocator);
            
            GenerateSessions(AfternoonSessionAllocator);
        }

        private void GenerateSessions(ISessionAllocator sessionAllocator)
        {
            for (var i = 0; i < NumberOfTracks; i++)
            {
                sessionAllocator.AllocateTalks(_talks);
            }

        }

    }
}