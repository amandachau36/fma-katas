using System;
using ConferenceTrack.Business.Blocks;

namespace ConferenceTrack.Business.Exceptions
{
    public class InvalidTalkDurationException : Exception
    {
        public InvalidTalkDurationException(Block block) : base(FormatMessage(block))
        {
            
        }

        private static string FormatMessage(Block block)
        {
            return $"Invalid talk duration: {block.BlockDuration}min.\nThe duration of talks must be shorter then the session duration";
        }
    }
}