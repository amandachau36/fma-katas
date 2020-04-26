using System;
using System.IO;
using ConferenceTrack.Client;
using Microsoft.Extensions.Configuration;

namespace ConferenceTrack.Business.Config
{
    public static class ConfigurationLoader
    {
        private const string StartTime = "Start Time";
        
        private const string MinEndTime = "Minimum End Time";
        
        private const string MaxEndTime =  "Maximum End Time";
        
        private const string BreakEventName = "Break Event Name";
        
        private const string BreakEventDuration = "Break Event Duration";

        public static SessionConfiguration LoadSessionConfiguration(string jsonFile)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Business","Config"))
                .AddJsonFile(jsonFile)
                .Build();

            //TODO: need to validate here
            
            var startTime = TimeSpan.Parse(config[StartTime]);
            
            var minEndTime = TimeSpan.Parse(config[MinEndTime]); 
            
            var maxEndTime = TimeSpan.Parse(config[MaxEndTime]);
            
            var breakEventDuration = Double.Parse(config[BreakEventDuration]);
            
            var breakEvent = new Block(config[BreakEventName], breakEventDuration);

            return new SessionConfiguration(startTime, minEndTime, maxEndTime, breakEvent);
        }
        
    }
}