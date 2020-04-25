using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business.Sessions;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business.Tracks
{
    public class TrackGenerator
    {
        public List<SessionAllocator> SessionAllocators { get; } 
        
        private readonly int _numberOfTracks;

        public TrackGenerator(int numberOfTracks, List<SessionAllocator> sessionAllocators)
        {
            _numberOfTracks = numberOfTracks;
            SessionAllocators = sessionAllocators;
        }

        public List<Track> GenerateTracks(List<Block> talks)
        {
            GenerateAllSessions(talks);
            
            return GenerateTracksFromSessions();
            
        }

        private List<Track> GenerateTracksFromSessions()
        {
            var tracks = new List<Track>();   
            
            for (var i = 0; i < _numberOfTracks; i++)
            {
                var blocksForTrack = SessionAllocators.SelectMany(allocator => allocator.Sessions[i]).ToList();

                var trackTitle = $"Track {i + 1}";

                tracks.Add(new Track(blocksForTrack, trackTitle));
            }

            return tracks;
        }
        
        private void GenerateAllSessions(List<Block> talks)
        {

            foreach (var sessionAllocator in SessionAllocators) 
            {
                GenerateSessions(sessionAllocator, talks);
            }
            
        }

        private void GenerateSessions(SessionAllocator sessionAllocator, List<Block> talks)
        {
            for (var i = 0; i < _numberOfTracks; i++)
            {
                sessionAllocator.AllocateTalksToSession(talks);
            }
        } 
        

    }
}