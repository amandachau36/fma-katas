using System;
using System.Text.RegularExpressions;

namespace ConferenceTrack.Client.InputValidator
{
    public class TalkValidator : IValidator
    {
        public bool IsValid(string input)
        {
            var durationMatch = Regex.Match(input, @"\d+");

            var lighteningMatch = Regex.Match(input, "lightning");

            return durationMatch.Success || lighteningMatch.Success;
        }
    }
}