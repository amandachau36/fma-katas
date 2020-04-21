using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public class TrackGenerator
    {
        public List<Talk> Talks { get; private set;}
        public List<ISessionAllocator> SessionAllocators { get; }
        public int NumberOfTracks { get;}
        public List<Track> Tracks { get; } = new List<Track>();
        
        public TrackGenerator(int numberOfTracks, List<ISessionAllocator> sessionAllocators)
        {
            NumberOfTracks = numberOfTracks;
            SessionAllocators = sessionAllocators;
        }

        public void GenerateTracks(List<Talk> talks)
        {
            GenerateAllSessions(talks);
            
            GenerateTracksFromSessions();
        }

        private void GenerateTracksFromSessions()
        {
            for (var i = 0; i < NumberOfTracks; i++)
            {
                var talksForTrack = SessionAllocators.SelectMany(allocator => allocator.Sessions[i]).ToList();

                Tracks.Add(new Track(talksForTrack));
            }
        }
        
        private void GenerateAllSessions(List<Talk> talks)
        {
            Talks = talks;
            
            foreach (var sessionAllocator in SessionAllocators)
            {
                GenerateSessions(sessionAllocator);
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