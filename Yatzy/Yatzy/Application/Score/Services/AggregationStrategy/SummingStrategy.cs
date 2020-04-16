using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Score.Services.AggregationStrategy
{
    public class SummingStrategy : IAggregationStrategy
    {
        public int Aggregate(IEnumerable<IDie> dice)  
        {
            return dice.Sum(d => d.Value);
        }
    }
}