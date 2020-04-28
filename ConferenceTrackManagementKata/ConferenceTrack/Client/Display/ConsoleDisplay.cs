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

        public void DisplayError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine(error + "\nPlease try again");
            
            Console.ResetColor();
        }
        

        private void TrackHeader(string trackTitle)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            
            Console.WriteLine($"\n{trackTitle}");
            
            Console.ResetColor();
        }

        private string FormatTime(TimeSpan time)
        {
            var dateTime = DateTime.Today.Add(time);
            
            return dateTime.ToString("hh:mm tt");
        }
        
    }
}