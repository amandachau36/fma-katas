using System;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.Exceptions;
using ConferenceTrack.Client.InputValidator;

namespace ConferenceTrack.Client.InputCollector
{
    public class ConsoleInputCollector : IInputCollector
    {
        public string Collect()
        {
            return Console.ReadLine();
        }
    }
}

//Don't need to test Console.ReadLine as part of the unit test because there's no logic would be just testing the dotnet framework