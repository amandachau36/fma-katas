using System.Collections.Generic;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Turn.Services.AggregationStrategy;
using Yatzy.Application.Turn.Services.DiceFilter;

namespace Yatzy.Application.Turn.Services.CategoryCalculator
{
    public static class CategoryCalculatorFactory  //public abstract class, with private constructor (sealed just can't inheritant but can make a new instance)
    {
        public static CategoryScoreCalculator BuildYatzy(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NOfAKindFilter(5),
                new YatzyStrategy()
            );
        }
        
        public static CategoryScoreCalculator BuildFourOfKind(List<Die> dice) 
        {
            return new CategoryScoreCalculator(
                dice,
                new NOfAKindFilter(4),
                new SummingStrategy()
            );
        }

        public static CategoryScoreCalculator BuildThreeOfKind(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NOfAKindFilter(3),
                new SummingStrategy()
            );
        }

        public static CategoryScoreCalculator BuildTwoOfKind(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NOfAKindFilter(2),
                new SummingStrategy()
            );
        }

        public static CategoryScoreCalculator BuildTwoPairs(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NOfAKindFilter(2, 2),
                new SummingStrategy()
                );
        }
        
        public static CategoryScoreCalculator BuildChance(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NoFilter(),
                new SummingStrategy()
            );
        }
        
        public static CategoryScoreCalculator BuildOnes(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(1), 
                new SummingStrategy()
            );
        }
        
        public static CategoryScoreCalculator BuildTwos(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(2), 
                new SummingStrategy()
            );
        }
        
        public static CategoryScoreCalculator BuildThrees(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(3), 
                new SummingStrategy()
            );
        }
        
        public static CategoryScoreCalculator BuildFours(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(4), 
                new SummingStrategy()
            );
        }
        
        public static CategoryScoreCalculator BuildFives(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(5), 
                new SummingStrategy()
            );
        }
        
        public static CategoryScoreCalculator BuildSixes(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new NumberFilter(6), 
                new SummingStrategy()
            );
        }
        
        public static CategoryScoreCalculator BuildSmallStraights(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new StraightsFilter(Constants.SmallStraightValues), 
                new SummingStrategy()
            );
        }
        
        public static CategoryScoreCalculator BuildLargeStraights(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new StraightsFilter(Constants.LargeStraightValues), 
                new SummingStrategy()
            );
        }

        public static CategoryScoreCalculator BuildFullHouse(List<Die> dice)
        {
            return new CategoryScoreCalculator(
                dice,
                new FullHouseFilter(), 
                new SummingStrategy()
            );
        }

        

        
        
    }

}