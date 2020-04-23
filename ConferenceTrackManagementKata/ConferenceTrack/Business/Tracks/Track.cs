using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business.Tracks
{
    public class Track
    {
        public List<Talk> Talks { get;}
        public string TrackTitle { get; }
        public Track(List<Talk> talks, string trackTitle)
        {
            Talks = talks;
            TrackTitle = trackTitle;
        }
        
    }
}