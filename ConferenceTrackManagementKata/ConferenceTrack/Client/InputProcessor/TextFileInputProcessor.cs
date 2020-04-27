using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ConferenceTrack.Business.Blocks;
using ConferenceTrack.Client.Exceptions;
using ConferenceTrack.Client.InputValidator;

namespace ConferenceTrack.Client.InputProcessor
{
    public class TextFileInputProcessor : IInputProcessor
    {
        private readonly IValidator _validator;

        public TextFileInputProcessor(IValidator talkValidator)
        {
            _validator = talkValidator;
        }
        
        public List<Block> Process(string[] talks)
        {
            var processedTalks = ProcessTalks(talks).OrderByDescending(t => t.BlockDuration);

            return processedTalks.ToList();

        }

        private List<Block> ProcessTalks(string[] talks)
        {
            var processedTalks = new List<Block>();
            
            foreach (var talk in talks)
            {
                
                if (!_validator.IsValid(talk))
                    throw new InvalidTalkException(talk); 
                
                var durationMatch = Regex.Match(talk, @"\d+min");

                if (durationMatch.Success)
                    processedTalks.Add(new Block(talk, Double.Parse(durationMatch.Value)));

                var lighteningMatch = Regex.Match(talk, "lightning");
                
                if(lighteningMatch.Success)
                    processedTalks.Add(new Block(talk, 5));
               
            }

            return processedTalks;
        }
        
        
    }
}