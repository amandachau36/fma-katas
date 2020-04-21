using System.IO;
using System.Text.RegularExpressions;

namespace ConferenceTrack.Client.InputValidator
{
    public class PathValidator : IValidator
    {
        public bool IsValid(string input)
        {
            
            var regex = new Regex(@"\.txt$");

            var match = regex.Match(input);

            return File.Exists(input) && match.Success;
            
        }
    }
}