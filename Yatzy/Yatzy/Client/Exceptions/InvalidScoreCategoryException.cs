using System;

namespace Yatzy.Client.Exceptions
{
    public class InvalidScoreCategoryException : Exception
    {
        public InvalidScoreCategoryException(string scoreCategory) : base(FormattedMessage(scoreCategory))
        {
            
        }

        private static string FormattedMessage(string scoreCategory)
        {
            return scoreCategory + " is not a valid score category";
        }
    }
}