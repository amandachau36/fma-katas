using System;
using System.Text.RegularExpressions;

namespace ConferenceTrack.Client.InputValidator
{
    public class TalkValidator : IValidator
    {
        public bool IsValid(string input)
        {
            var isMinutesMatch = new Regex(@"\d+min").IsMatch(input);

            var isLightningMatch = new Regex("lightning").IsMatch(input);
            
            if (isMinutesMatch && isLightningMatch) return false;
            
            return isMinutesMatch || isLightningMatch;
        }
    }
}