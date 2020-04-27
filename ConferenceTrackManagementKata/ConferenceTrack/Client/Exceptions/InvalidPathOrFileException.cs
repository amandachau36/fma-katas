using System;

namespace ConferenceTrack.Client.Exceptions
{
    public class InvalidPathOrFileException : Exception
    {
        public InvalidPathOrFileException(string path) : base(FormatMessage(path))
        {
            
        }

        private static string FormatMessage(string path)
        {
            return $"Not a valid path or file: {path}. \nOnly .txt files are valid";
        }
    }
}