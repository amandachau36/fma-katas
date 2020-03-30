using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Turn.Services.AggregationStrategy
{
    public class YatzyStrategy : IAggregationStrategy
    {
        public int Aggregate(IEnumerable<Die> dice)
        {
            return dice.Count() >= Constants.MaximumNumberOfDice ? 50 : 0;
        }
    }
}