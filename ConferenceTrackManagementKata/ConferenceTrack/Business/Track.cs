using System.Collections.Generic;
using ConferenceTrack.Client;

namespace ConferenceTrack.Business
{
    public class Track
    {
        public List<Talk> Talks { get;}

        public Track(List<Talk> talks)
        {
            Talks = talks;
        }
        
    }
}