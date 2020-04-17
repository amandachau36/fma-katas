using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConferenceTrack.Client.InputProcessor
{
    public class TextFileInputProcessor : IInputProcessor
    {
        public List<Talk> Process(string[] talks)
        {
            var processedTalks = ProcessTalks(talks).OrderByDescending(t => t.Duration);

            return processedTalks.ToList();

        }

        private List<Talk> ProcessTalks(string[] talks)
        {
            var processedTalks = new List<Talk>();
            
            foreach (var talk in talks)
            {
                var durationMatch = Regex.Match(talk, @"\d+");  
                
                if (durationMatch.Success)
                    processedTalks.Add(new Talk(talk, Int32.Parse(durationMatch.Value)));

                var lighteningMatch = Regex.Match(talk, "lightning");
                
                if(lighteningMatch.Success)
                    processedTalks.Add(new Talk(talk, 5));
            }

            return processedTalks;
        }
        
    }
}