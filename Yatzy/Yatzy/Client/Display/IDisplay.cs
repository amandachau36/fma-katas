using System.Collections.Generic;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;

namespace Yatzy.Client.Display
{
    public interface IDisplay
    {
        void Display(string message);
        void Display(IEnumerable<IDie> dice);
        void Display(Dictionary<ScoreCategory, ScoreRecordForEachCategory> scoreCategories);
        void DisplayError(string error);
        void Display(int score);
    }
}