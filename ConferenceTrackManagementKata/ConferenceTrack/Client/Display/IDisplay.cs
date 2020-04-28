using System.Collections.Generic;
using ConferenceTrack.Business;
using ConferenceTrack.Business.Tracks;

namespace ConferenceTrack.Client.Display
{
    public interface IDisplay
    {
        void Display(string message);

        void DisplayError(string error);
        

    }
}