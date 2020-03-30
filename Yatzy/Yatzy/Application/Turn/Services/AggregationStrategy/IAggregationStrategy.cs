using System.Collections.Generic;
using Yatzy.Application.Dice;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Turn.Services.AggregationStrategy
{
    public interface IAggregationStrategy
    {
        int Aggregate(IEnumerable<Die> dice); 
    }
}