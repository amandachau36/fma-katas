using System.Collections.Generic;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Dice;

namespace Yatzy.Application.Score.Services.AggregationStrategy
{
    public interface IAggregationStrategy
    {
        int Aggregate(IEnumerable<Die> dice); 
    }
}