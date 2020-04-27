using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business.Blocks;
using ConferenceTrack.Business.Exceptions;
using ConferenceTrack.Business.Sessions;
using ConferenceTrack.Business.Validators;

namespace ConferenceTrack.Business.Tracks
{
    public class TrackGenerator
    {
        public List<SessionAllocator> SessionAllocators { get; } 
        
        private readonly int _numberOfTracks;
        
        private readonly TalkDurationValidator _talkDurationValidator;

        public TrackGenerator(int numberOfTracks, List<SessionAllocator> sessionAllocators, TalkDurationValidator talkDurationValidator)
        {
            _numberOfTracks = numberOfTracks;
            
            _talkDurationValidator = talkDurationValidator;
            
            SessionAllocators = sessionAllocators;
        }

        public List<Track> GenerateTracks(IEnumerable<Block> talks)
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
        
        private void GenerateAllSessions(IEnumerable<Block> talks)
        {
            ThrowExceptionIfAnyTalkDurationsAreInvalid(talks);
            
            foreach (var sessionAllocator in SessionAllocators) 
            {
                GenerateSessions(sessionAllocator, talks);
            }
            
        }

        private void ThrowExceptionIfAnyTalkDurationsAreInvalid(IEnumerable<Block> talks)
        {
            var maxSessionDuration = SessionAllocators.Max(x => x.MaxDuration).TotalMinutes;

            foreach (var talk in talks.Where(talk => !_talkDurationValidator.IsValid(talk, maxSessionDuration)))
            {
                throw new InvalidTalkDurationException(talk);
            }
        }

        private void GenerateSessions(SessionAllocator sessionAllocator, IEnumerable<Block> talks)
        {
            for (var i = 0; i < _numberOfTracks; i++)
            {
                
                sessionAllocator.AllocateTalksToSession(talks);
            }
        }
        
        
        

    }
}