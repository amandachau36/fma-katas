using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Turn.Services.AggregationStrategy
{
    public class SummingStrategy : IAggregationStrategy
    {
        public int Aggregate(IEnumerable<Die> dice)  //TODO: should this be static??? but can't use static methods with interfaces  
        {
            return dice.Sum(d => d.Value);
        }
    }
}