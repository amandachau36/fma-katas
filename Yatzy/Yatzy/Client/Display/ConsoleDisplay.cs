using System;
using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;


namespace Yatzy.Client.Display
{
    public class ConsoleDisplay : IDisplay
    {
        public void Display(string message) 
        {
            Console.WriteLine(message);
        }
        
        public void DisplayError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(error + Constants.TryAgainPrompt);
            
            Console.ResetColor();
        }

        public void Display(IEnumerable<IDie> dice)
        {
            var formattedDice = GetFormattedDiceList(dice);
            
            Console.WriteLine(formattedDice);
        }

        public void Display(Dictionary<ScoreCategory, ScoreRecordForEachCategory> scoreCategories)
        {
            ScoreCategoryHeader();
            
            foreach (var (key, value) in scoreCategories)
            {
                if (value.IsAvailable == false)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                
                Console.WriteLine(Constants.FormatColumns, key, value.Score);
                
                Console.ResetColor();
                
            }
        }
        
        public void Display(int score)
        {
            TableRowBorder();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Constants.FormatColumns, Constants.TotalScore, score); 
            Console.ResetColor();
            TableRowBorder();
        }

        private static void ScoreCategoryHeader()
        {
            Console.WriteLine();
            Console.WriteLine(Constants.FormatColumns, Constants.ScoreCategory, Constants.Score); 
            TableRowBorder();
        }

        private static void TableRowBorder()
        {
            Console.WriteLine(new string('-', 33));
        }
        
        private static string GetFormattedDiceList(IEnumerable<IDie> dice)
        {
            return string.Join(", ", dice.Select(d => d.Value));
        }
    }
}