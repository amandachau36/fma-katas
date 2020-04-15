using System;
using System.Collections.Generic;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score.Services.AggregationStrategy;
using Yatzy.Application.Score.Services.DiceFilter;

namespace Yatzy.Application.Score.Services.CategoryCalculator
{
    public static class CategoryCalculatorFactory  //public abstract class, with private constructor (sealed just can't inherit but can make a new instance)
    {
        
        public static CategoryScoreCalculator CreateCalculator(ScoreCategory scoreCategory, List<Die> dice) =>
            
            //functional inspired programming (F#)/decorative way of programming
            scoreCategory switch 
            {
                ScoreCategory.Yatzy => BuildYatzy(dice),
                ScoreCategory.FourOfAKind => BuildFourOfKind(dice),
                ScoreCategory.ThreeOfAKind => BuildThreeOfKind(dice),
                ScoreCategory.Pairs => BuildPairs(dice),
                ScoreCategory.TwoPairs => BuildTwoPairs(dice),
                ScoreCategory.Chance => BuildChance(dice),
                ScoreCategory.Ones => BuildOnes(dice),
                ScoreCategory.Twos => BuildTwos(dice),
                ScoreCategory.Threes => BuildThrees(dice),
                ScoreCategory.Fours => BuildFours(dice),
                ScoreCategory.Fives => BuildFives(dice),
                ScoreCategory.Sixes => BuildSixes(dice),
                ScoreCategory.SmallStraights => BuildSmallStraights(dice),
                ScoreCategory.LargeStraights => BuildLargeStraights(dice),
                ScoreCategory.FullHouse => BuildFullHouse(dice),

                _ => throw new ArgumentException("Enum does not exist")  //_ everything else
            
            };

        
        //Doesn't have to be static
        private static CategoryScoreCalculator BuildYatzy(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NOfAKindFilter(5),
                new YatzyStrategy()
            );
        }
        
        private static CategoryScoreCalculator BuildFourOfKind(List<Die> dice) 
        {
            return new CategoryScoreCalculator(
                dice,
                new NOfAKindFilter(4),
                new SummingStrategy()
            );
        }

        private static CategoryScoreCalculator BuildThreeOfKind(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NOfAKindFilter(3),
                new SummingStrategy()
            );
        }

        private static CategoryScoreCalculator BuildPairs(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NOfAKindFilter(2),
                new SummingStrategy()
            );
        }

        private static CategoryScoreCalculator BuildTwoPairs(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NOfAKindFilter(2, 2),
                new SummingStrategy()
                );
        }
        
        private static CategoryScoreCalculator BuildChance(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NoFilter(),
                new SummingStrategy()
            );
        }
        
        private static CategoryScoreCalculator BuildOnes(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(1), 
                new SummingStrategy()
            );
        }
        
        private static CategoryScoreCalculator BuildTwos(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(2), 
                new SummingStrategy()
            );
        }
        
        private static CategoryScoreCalculator BuildThrees(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(3), 
                new SummingStrategy()
            );
        }
        
        private static CategoryScoreCalculator BuildFours(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(4), 
                new SummingStrategy()
            );
        }
        
        private static CategoryScoreCalculator BuildFives(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(5), 
                new SummingStrategy()
            );
        }
        
        private static CategoryScoreCalculator BuildSixes(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(6), 
                new SummingStrategy()
            );
        }
        
        private static CategoryScoreCalculator BuildSmallStraights(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new StraightsFilter(Constants.SmallStraightValues), 
                new SummingStrategy()
            );
        }
        
        private static CategoryScoreCalculator BuildLargeStraights(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new StraightsFilter(Constants.LargeStraightValues), 
                new SummingStrategy()
            );
        }

        private static CategoryScoreCalculator BuildFullHouse(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new FullHouseFilter(), 
                new SummingStrategy()
            );
        }

    }
    
}
