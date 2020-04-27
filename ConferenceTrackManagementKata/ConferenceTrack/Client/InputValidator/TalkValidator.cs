using System;
using System.Text.RegularExpressions;

namespace ConferenceTrack.Client.InputValidator
{
    public class TalkValidator : IValidator
    {
        public bool IsValid(string input)
        {
            var durationMatch = Regex.Match(input, @"\d+min");

            var lighteningMatch = Regex.Match(input, "lightning");

            if (durationMatch.Success && lighteningMatch.Success) return false;
            
            return durationMatch.Success || lighteningMatch.Success;
        }
    }
}