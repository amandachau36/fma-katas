using System;
using System.Collections.Generic;

namespace Yatzy.Application.Exceptions
{
    public class InvalidDiceValueException : Exception
    {
        public InvalidDiceValueException(List<int> valuesToHold) : base(FormattedMessage(valuesToHold))
        {
            
        }

        private static string FormattedMessage(List<int> valuesToHold)
        {
            return "These value(s) are invalid: " + string.Join( ", ", valuesToHold);
        }
    }
}