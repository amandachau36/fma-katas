using System;

namespace Yatzy.Client.Exceptions
{
    public class InvalidValuesToHoldException : Exception
    {
        public InvalidValuesToHoldException(string valuesToHold) : base(FormattedMessage(valuesToHold))
        {
            
        }

        private static string FormattedMessage(string valuesToHold)
        {
            return "One or more invalid dice values: " + valuesToHold;
        }
        
    }
}