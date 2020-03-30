using System.Collections.Generic;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Turn.Services.AggregationStrategy;
using Yatzy.Application.Turn.Services.DiceFilter;

namespace Yatzy.Application.Turn.Services.CategoryCalculator
{
    public class CategoryScoreCalculator 
    {
        private readonly List<Die> _dice;
        private readonly IDiceFilter _diceFilter;
        private readonly IAggregationStrategy _aggregationStrategy;

        public CategoryScoreCalculator(List<Die> dice, IDiceFilter diceFilter, IAggregationStrategy aggregationStrategy) // dependency injection
        {
            _dice = dice;
            _diceFilter = diceFilter;
            _aggregationStrategy = aggregationStrategy;
        }

        public int Calculate()
        {
            var filteredDice = _diceFilter.Filter(_dice);
            
            return _aggregationStrategy.Aggregate(filteredDice);
            
        }

    }
}