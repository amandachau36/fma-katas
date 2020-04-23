using ConferenceTrack.Client.Exceptions;
using ConferenceTrack.Client.InputValidator;

namespace ConferenceTrack.Client.InputProvider
{
    public class TextFileInputProvider : IInputProvider
    {
        private readonly IValidator _pathValidator;
        public TextFileInputProvider(IValidator pathValidator)
        {
            _pathValidator = pathValidator;
        }
        
        public string[] ProvideInput(string input)
        {
            if (!_pathValidator.IsValid(input))
                throw new InvalidPathOrFileException(input);
            
            return System.IO.File.ReadAllLines(input);
        }
    }
}