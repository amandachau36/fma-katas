using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Yatzy.Application.Score;
using Yatzy.Client.Exceptions;
using Yatzy.Client.InputValidators;


namespace Yatzy.Client.InputProcessor
{
    public class ConsoleInputProcessor : IInputProcessor
    {
        public List<int> ConvertToDiceValues(string input, IInputValidator inputValidator)
        {
            var isDiceValuesValid = inputValidator.IsValid(input);
            
            if(!isDiceValuesValid)
                throw new InvalidValuesToHoldException(input);
            
            var valueMatches = Regex.Matches(input, @"\d+");
            
            var processedDiceValuesToHold = new List<int>();
            
            foreach (Match match in valueMatches)
            {
                foreach (Capture capture in match.Captures)
                {
                     processedDiceValuesToHold.Add(int.Parse(capture.Value));
                }
            }
            
            return processedDiceValuesToHold;
        }
        

        public ScoreCategory ConvertToScoreCategory(string scoreCategory, IInputValidator inputValidator)
        {
            var isCategoryValid = inputValidator.IsValid(scoreCategory);

            if (!isCategoryValid)
                throw new InvalidScoreCategoryException(scoreCategory);
            
            return (ScoreCategory)Enum.Parse(typeof(ScoreCategory), scoreCategory);
        }
        
    }
    
}