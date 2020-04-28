using System;

namespace ConferenceTrack.Client.Output
{
    public static class OutputDisplayFactory
    {
        public static IOutputDisplay CreateOutputDisplay(OutputDisplayType outputDisplayType) =>
        
            outputDisplayType switch
            {
                OutputDisplayType.Console => new ConsoleOutputDisplay(),
                OutputDisplayType.TextFile => new TextFileOutputDisplay(),

            _ => throw new ArgumentException("Enum does not exist")
            
            };
        
    }
}