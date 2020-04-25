using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business.Tracks
{
    public class Track
    {
        public List<Block> Blocks { get;}
        public string TrackTitle { get; }
        public Track(List<Block> blocks, string trackTitle)
        {
            Blocks = blocks;
            TrackTitle = trackTitle;
        }
        
    }
}