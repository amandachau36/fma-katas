using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business;

namespace ConferenceTrack.Client.Display
{
    public class ConsoleDisplay : IDisplay
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        public void Display(List<Track> tracks)  //TODO: test this but not through a unit test. Can use MOQ but better not use MOQ
        {
            for (var i = 0; i < tracks.Count; i++)
            {
                TrackHeader(i+1);
                
                foreach (var talk in tracks[i].Talks)
                {
                    Console.WriteLine($"{talk.TalkTime.ToString(Constants.FormatTime)}  {talk.TalkTitle}"); // TODO: ? make this a string and test it. PrepareDisplay and WriteDisplay 
                }
           
            }
        }

        public void DisplayError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error + "\nPlease try again");
            Console.ResetColor();
        }

        private void TrackHeader(int trackNumber)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Constants.Track + trackNumber);
            Console.ResetColor();
        }
        
    }
}