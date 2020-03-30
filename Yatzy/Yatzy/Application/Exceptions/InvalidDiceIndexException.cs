using System;

namespace Yatzy.Application.Exceptions
{
    public class InvalidDiceIndexException : Exception
    {
        public InvalidDiceIndexException(int index) : base(FormattedMessage(index))
        {
            
        }

        private static string FormattedMessage(int index)
        {
            return index + " is not a valid index. Index must be a non-negative number and 4 or less.";
        }
    }
}