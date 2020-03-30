using System;

namespace Yatzy.Application.Exceptions
{
    public class MaxNumberOfRollsExceededException : Exception
    {
        public MaxNumberOfRollsExceededException(string message) : base(message)
        {
            
        }
    }
}