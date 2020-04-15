using System;
using Yatzy.Application.Score;

namespace Yatzy.Application.Exceptions
{
    public class ScoreCategoryAlreadyTakenException : Exception
    {
        public ScoreCategoryAlreadyTakenException(ScoreCategory scoreCategory) : base(FormattedMessage(scoreCategory))
        {
            
        }

        private static string FormattedMessage(ScoreCategory scoreCategory)
        {
            return "This score category is already take: " + scoreCategory;
        }
    }
}