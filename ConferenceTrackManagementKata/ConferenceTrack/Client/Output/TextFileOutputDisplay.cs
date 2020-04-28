using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConferenceTrack.Business.Tracks;

namespace ConferenceTrack.Client.Output
{
    public class TextFileOutputDisplay : IOutputDisplay
    {
        public List<Track> PrepareDisplay(List<Track> tracks) //TODO: put this logic somewhere else, may be in the business layer
        {
            foreach (var talk in tracks.SelectMany(t => t.Blocks))
            {
                
                talk.SetFormattedBlockNameAndTimeSlot($"{FormatTime(talk.TimeSlot)}  {talk.BlockName}");
            }
        
            return tracks;
        }
        
        public void WriteDisplay(List<Track> tracks)
        {
            
            var sw = new StreamWriter(
                "/Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack/Client/Output/output.txt");
                //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Client", "Output", "output.txt"));
            
            foreach (var t in tracks)
            {
                sw.WriteLine(t.TrackTitle);
                
                foreach (var talk in t.Blocks)
                {
                    sw.WriteLine(talk.FormattedBlockNameAndTimeSlot); 
                }
            }
        
            sw.Close();
            
            Console.WriteLine("Check Output/output.txt");
        
        }
        
        private string FormatTime(TimeSpan time)
        {
            var dateTime = DateTime.Today.Add(time);
            
            return dateTime.ToString("hh:mm tt");
        }

    }
}