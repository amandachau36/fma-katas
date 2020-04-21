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
            foreach (var track in tracks)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Track ");
                Console.ResetColor();
                
                foreach (var talk in track.Talks)
                {
                    Console.WriteLine( talk.TalkTime.ToString("hh':'mm") +  " " + talk.TalkTitle);
                }
           
            }
        }
    }
}