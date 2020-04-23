using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business;
using ConferenceTrack.Business.Tracks;

namespace ConferenceTrack.Client.Display
{
    public class ConsoleDisplay : IDisplay
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteDisplay(List<Track> tracks)   //can test this using MOQ but it's better not use MOQ
        {
            foreach (var t in tracks)
            {
                TrackHeader(t.TrackTitle);
                
                foreach (var talk in t.Talks)
                {
                    Console.WriteLine(talk.ScheduledTalk); 
                }
            }
        }

        public List<Track> PrepareDisplay(List<Track> tracks)
        {
            foreach (var talk in tracks.SelectMany(t => t.Talks))
            {
                talk.SetScheduledTalk($"{talk.TalkTime.ToString(Constants.FormatTime)}  {talk.TalkTitle}");
            }

            return tracks;
        }

        public void DisplayError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error + "\nPlease try again");
            Console.ResetColor();
        }

        public string ReadDisplay()
        {
            return Console.ReadLine();
        }

        private void TrackHeader(string trackTitle)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(trackTitle);
            Console.ResetColor();
        }
        
    }
}