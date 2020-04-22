using System.Collections.Generic;
using ConferenceTrack.Business;

namespace ConferenceTrack.Client.Display
{
    public interface IDisplay
    {
        void Display(string message);

        List<Track> PrepareDisplay(List<Track> tracks);

        void WriteDisplay(List<Track> tracks);

        void DisplayError(string error);

        string ReadDisplay(); 

    }
}