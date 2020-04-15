using System.Collections.Generic;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Exceptions;
using Yatzy.Application.Score.Services.CategoryCalculator;


namespace Yatzy.Application.Score
{
    
    public class ScoreCard
    {
        public int Total { get; private set; }

        public Dictionary<ScoreCategory, ScoreRecordForEachCategory> ScoreCategories { get;} =
            new Dictionary<ScoreCategory, ScoreRecordForEachCategory>
            {
                {ScoreCategory.Yatzy, new ScoreRecordForEachCategory()},
                {ScoreCategory.FourOfAKind, new ScoreRecordForEachCategory()},
                {ScoreCategory.ThreeOfAKind, new ScoreRecordForEachCategory()},
                {ScoreCategory.Pairs, new ScoreRecordForEachCategory()},
                {ScoreCategory.TwoPairs, new ScoreRecordForEachCategory()},
                {ScoreCategory.Ones, new ScoreRecordForEachCategory()},
                {ScoreCategory.Twos, new ScoreRecordForEachCategory()},
                {ScoreCategory.Threes, new ScoreRecordForEachCategory()},
                {ScoreCategory.Fours, new ScoreRecordForEachCategory()},
                {ScoreCategory.Fives, new ScoreRecordForEachCategory()},
                {ScoreCategory.Sixes, new ScoreRecordForEachCategory()},
                {ScoreCategory.Chance, new ScoreRecordForEachCategory()},
                {ScoreCategory.LargeStraights, new ScoreRecordForEachCategory()},
                {ScoreCategory.SmallStraights, new ScoreRecordForEachCategory()}, 
                {ScoreCategory.FullHouse, new ScoreRecordForEachCategory()},
            };
        
        
        public void UpdateScoreCard(ScoreCategory scoreCategory, List<Die> diceHeld)
        {
            if(!ScoreCategories[scoreCategory].IsAvailable)
                    throw new ScoreCategoryAlreadyTakenException(scoreCategory);

            ClearPreviewScoreCard();
            var scoreForTurn = GetScoreForCategory(scoreCategory, diceHeld);
            UpdateScoreCategory(scoreCategory, scoreForTurn);
            UpdateTotalScore(scoreForTurn);
        }

        public void PreviewScoreCard(List<Die> diceHeld)
        {
            foreach (var (key, value) in ScoreCategories)
            {
                if (!value.IsAvailable) continue;
                
                var scoreForCategory = GetScoreForCategory(key, diceHeld);
                value.UpdateCategory(scoreForCategory, true);
            }
        }
        
        private void ClearPreviewScoreCard()
        {
            foreach (var (key, value) in ScoreCategories)
            {
                if (!value.IsAvailable) continue;
                
                value.UpdateCategory(0, true);
            }
        }


        private int GetScoreForCategory(ScoreCategory scoreCategory, List<Die> diceHeld)
        {
            var categoryCalculator = CategoryCalculatorFactory.CreateCalculator(scoreCategory, diceHeld);
            return categoryCalculator.Calculate();
        }
        
        private void UpdateTotalScore(int scoreForTurn)
        {
            Total += scoreForTurn;
        }
        
        private void UpdateScoreCategory(ScoreCategory scoreCategory, int scoreForTurn)
        {
            ScoreCategories[scoreCategory].UpdateCategory(scoreForTurn, false);
        }
        
    }
}

