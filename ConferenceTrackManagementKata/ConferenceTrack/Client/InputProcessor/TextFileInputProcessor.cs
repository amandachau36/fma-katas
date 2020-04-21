using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ConferenceTrack.Client.Exceptions;
using ConferenceTrack.Client.InputValidator;

namespace ConferenceTrack.Client.InputProcessor
{
    public class TextFileInputProcessor : IInputProcessor
    {
        private readonly IValidator _validator;

        public TextFileInputProcessor(IValidator validator)
        {
            _validator = validator;
        }
        
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
                
                if (!_validator.IsValid(talk))
                    throw new InvalidTalkException(talk); 
                
                var durationMatch = Regex.Match(talk, @"\d+");

                if (durationMatch.Success)
                    processedTalks.Add(new Talk(talk, Double.Parse(durationMatch.Value)));

                var lighteningMatch = Regex.Match(talk, "lightning");
                
                if(lighteningMatch.Success)
                    processedTalks.Add(new Talk(talk, 5));
               
            }

            return processedTalks;
        }
        
        
    }
}