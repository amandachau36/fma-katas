using System;

namespace ConferenceTrack.Client.InputCollector
{
    public class TextFileInputCollector : IInputCollector
    {
        public string[] Collect()
        {
            //TODOConsoleReadLine(); 
            // inject console 
            var path = Console.ReadLine();
            return System.IO.File.ReadAllLines(path); //TODO: Don't need to test as part of the unit test because there's no logic would be just testing the dotnet framework
            
            //Validate that file exists and path exists path.exist path.exist
        }
        
    }
}