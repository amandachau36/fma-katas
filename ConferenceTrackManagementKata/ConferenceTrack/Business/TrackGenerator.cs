using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public class TrackGenerator
    {
        //private readonly List<Talk> _talks;

        public List<Talk> Talks { get; private set;}
        public List<ISessionAllocator> SessionAllocators { get; }
        public int NumberOfTracks { get;}
        
        public List<List<Talk>> Tracks { get; } = new List<List<Talk>>();

        public TrackGenerator(int numberOfTracks, List<ISessionAllocator> sessionAllocators)
        {
            NumberOfTracks = numberOfTracks;
            SessionAllocators = sessionAllocators;
        }

        
        public void GenerateAllSessions(List<Talk> talks)
        {
            Talks = talks;
            
            foreach (var sessionAllocator in SessionAllocators)
            {
                GenerateSessions(sessionAllocator);
            }
            
        }

        public void GenerateTracks()
        {
            for (var i = 0; i < NumberOfTracks; i++)
            {
                foreach (var allocator in SessionAllocators)
                {
                    Tracks.Add(allocator.Sessions[i]);
                }   
            }
        }
        
        private void GenerateSessions(ISessionAllocator sessionAllocator)
        {
            for (var i = 0; i < NumberOfTracks; i++)
            {
                sessionAllocator.AllocateTalksToSession(Talks);
            }
        }

    }
}