using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business.SessionAllocator;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business.Tracks
{
    public class TrackGenerator
    {
        public List<ISessionAllocator> SessionAllocators { get; } //TODO: can make this private
        
        private readonly int _numberOfTracks;
        
        
        public TrackGenerator(int numberOfTracks, List<ISessionAllocator> sessionAllocators)
        {
            _numberOfTracks = numberOfTracks;
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
            
            for (var i = 0; i < _numberOfTracks; i++)
            {
                var talksForTrack = SessionAllocators.SelectMany(allocator => allocator.Sessions[i]).ToList();

                var trackTitle = $"Track {i + 1}";

                tracks.Add(new Track(talksForTrack, trackTitle));
            }

            return tracks;
        }
        
        private void GenerateAllSessions(List<Talk> talks)
        {

            foreach (var sessionAllocator in SessionAllocators) 
            {
                GenerateSessions(sessionAllocator, talks);
            }
            
        }

        private void GenerateSessions(ISessionAllocator sessionAllocator, List<Talk> talks)
        {
            for (var i = 0; i < _numberOfTracks; i++)
            {
                sessionAllocator.AllocateTalksToSession(talks);
            }
        } 
        

    }
}