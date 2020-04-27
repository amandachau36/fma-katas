using System;

namespace ConferenceTrack.Client.Exceptions
{
    public class InvalidTalkException : Exception
    {
        public InvalidTalkException(string talk) : base(FormatMessage(talk))
        {
            
        }

        private static string FormatMessage(string talk)
        {
            return $"Not a valid talk: {talk}. \nMust contain duration in minutes or be a lightning talk.";
        }
    }
}