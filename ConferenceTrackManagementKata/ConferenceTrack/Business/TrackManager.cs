using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public class TrackManager
    {
        private readonly List<Talk> _talks;
        public List<ISessionAllocator> SessionAllocators { get; }
        public int NumberOfTracks { get;}

        public TrackManager(int numberOfTracks, List<Talk> talks, List<ISessionAllocator> sessionAllocators)
        {
            _talks = talks;
            NumberOfTracks = numberOfTracks;
            SessionAllocators = sessionAllocators;
        }

        public void GenerateAllSessions()
        {
            foreach (var sessionAllocator in SessionAllocators)
            {
                GenerateSessions(sessionAllocator);
            }
           
        }

        private void GenerateSessions(ISessionAllocator sessionAllocator)
        {
            for (var i = 0; i < NumberOfTracks; i++)
            {
                sessionAllocator.AllocateTalksToSession(_talks);
            }

        }

    }
}