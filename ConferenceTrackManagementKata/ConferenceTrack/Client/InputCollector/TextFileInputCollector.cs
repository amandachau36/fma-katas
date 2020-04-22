using System;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.Exceptions;
using ConferenceTrack.Client.InputValidator;

namespace ConferenceTrack.Client.InputCollector
{
    public class TextFileInputCollector : IInputCollector
    {
        private readonly IValidator _validator;
        private readonly IDisplay _display;

        public TextFileInputCollector(IValidator pathValidator, IDisplay display)
        {
            _validator = pathValidator;
            _display = display;
        }
        public string[] Collect()
        {
            var path = _display.ReadDisplay();

            if (!_validator.IsValid(path))
                throw new InvalidPathOrFileException(path);

            return System.IO.File.ReadAllLines(path);

        }
        
    }
}

//TODO: Don't need to test as part of the unit test because there's no logic would be just testing the dotnet framework