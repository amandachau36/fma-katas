using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Yatzy.Client.InputValidators
{
    public class DiceValuesToHoldValidator : IInputValidator
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return true;

            var includesInt = input.Any(char.IsDigit);
            
            if (!includesInt)
                return false;
            
            var diceValuesToHold = Regex.Matches(input, @"\d+");
            
            foreach (Match match in diceValuesToHold)
            {
                foreach (Capture capture in match.Captures)
                {
                    if(!Constants.ValidDiceValues.Contains(int.Parse(capture.Value)))
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

    }
}
