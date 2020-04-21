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

        public void Display(List<Track> tracks)
        {
            for (var i = 0; i < tracks.Count; i++)
            {
                TrackHeader(i+1);
                
                foreach (var talk in tracks[i].Talks)
                {
                    Console.WriteLine( talk.TalkTime.ToString("hh':'mm") +  " " + talk.TalkTitle);
                }
           
            }
        }

        private void TrackHeader(int trackNumber)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nTrack " + trackNumber);
            Console.ResetColor();
        }
        
    }
}