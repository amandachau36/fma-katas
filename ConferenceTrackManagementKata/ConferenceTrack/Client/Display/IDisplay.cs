using System.Collections.Generic;
using ConferenceTrack.Business;

namespace ConferenceTrack.Client.Display
{
    public interface IDisplay
    {

        void Display(List<Track> tracks);

    }
}