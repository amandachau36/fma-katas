using System.IO;
using System.Text.RegularExpressions;

namespace ConferenceTrack.Client.InputValidator
{
    public class PathValidator : IValidator
    {
        public bool IsValid(string input)
        {
            var regex = new Regex(@"\.txt$");
            
            return File.Exists(input) && regex.IsMatch(input);
        }
    }
}