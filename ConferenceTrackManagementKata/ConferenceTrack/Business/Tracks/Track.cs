using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business.Tracks
{
    public class Track
    {
        public List<Block> Talks { get;}
        public string TrackTitle { get; }
        public Track(List<Block> talks, string trackTitle)
        {
            Talks = talks;
            TrackTitle = trackTitle;
        }
        
    }
}