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
        //public List<Track> Tracks { get; } = new List<Track>();
        
        public TrackGenerator(int numberOfTracks, List<ISessionAllocator> sessionAllocators)
        {
            NumberOfTracks = numberOfTracks;
            SessionAllocators = sessionAllocators;
        }

        public List<Track> GenerateTracks(List<Talk> talks)
        {
            GenerateAllSessions(talks);
            
            return GenerateTracksFromSessions();
            
        }

        private List<Track> GenerateTracksFromSessions()
        {
            var tracks = new List<Track>();   
            
            for (var i = 0; i < NumberOfTracks; i++)
            {
                var talksForTrack = SessionAllocators.SelectMany(allocator => allocator.Sessions[i]).ToList();

                tracks.Add(new Track(talksForTrack));
            }

            return tracks;
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