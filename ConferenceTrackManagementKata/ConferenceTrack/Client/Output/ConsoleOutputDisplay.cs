using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business.Tracks;

namespace ConferenceTrack.Client.Output
{
    public class ConsoleOutputDisplay : IOutputDisplay
    {
        public void WriteDisplay(List<Track> tracks)   //can test this using MOQ but it's better not use MOQ
        {
            foreach (var t in tracks)
            {
                TrackHeader(t.TrackTitle);
                
                foreach (var talk in t.Blocks)
                {
                    Console.WriteLine(talk.FormattedBlockNameAndTimeSlot); 
                }
            }
        }

        public List<Track> PrepareDisplay(List<Track> tracks)
        {
            foreach (var talk in tracks.SelectMany(t => t.Blocks))
            {
                
                talk.SetFormattedBlockNameAndTimeSlot($"{FormatTime(talk.TimeSlot)}  {talk.BlockName}");
            }

            return tracks;
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