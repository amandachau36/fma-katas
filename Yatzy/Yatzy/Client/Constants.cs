using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Yatzy.Client
{
    public static class Constants
    {
        public const int MaximumNumberOfRounds = 15;

        public const string WelcomeMessage = "Welcome to Yatzy!";

        public const string PlayerRolledMessage = "\nYou rolled: ";

        public const string ReRollPrompt = "\nWhich dice values would you like to hold? (ex. 5, 5, 5)";

        public const string FinalDiceValuesMessage = "\nYour final dice values are: ";

        public const string TryAgainPrompt = "\nPlease try again!";

        public const string ScoreCategoryPrompt = "\nPick a scoring category: ";

        public const string TotalScore = "Total Score";
        
        public const string ScoreCategory = "Score Category";

        public const string Score = "Score";

        public const string FormatColumns = "|{0,-20}|{1,10}|";

        public static readonly IList<int> ValidDiceValues = new ReadOnlyCollection<int>(
            new List<int>
            {
                1, 2, 3, 4, 5, 6
            });


    }
}