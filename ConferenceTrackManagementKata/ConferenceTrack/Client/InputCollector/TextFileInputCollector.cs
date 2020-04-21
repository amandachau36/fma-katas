using System;
using ConferenceTrack.Client.Exceptions;
using ConferenceTrack.Client.InputValidator;

namespace ConferenceTrack.Client.InputCollector
{
    public class TextFileInputCollector : IInputCollector
    {
        private readonly IValidator _validator;

        public TextFileInputCollector(IValidator pathValidator)
        {
            _validator = pathValidator;
        }
        public string[] Collect()
        {
            var path = Console.ReadLine();

            if (!_validator.IsValid(path))
                throw new InvalidPathOrFileException(path);

            return System.IO.File.ReadAllLines(path);

        }
        
    }
}

//TODO: Don't need to test as part of the unit test because there's no logic would be just testing the dotnet framework