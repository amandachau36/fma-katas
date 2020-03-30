using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Turn.Services.DiceFilter
{
    public class FullHouseFilter : IDiceFilter
    {
        
        public IEnumerable<Die> Filter(IEnumerable<Die> dice)
        {
            var groupByDiceValue =
                from d in dice
                group d by d.Value;

            return groupByDiceValue.Count() == 2 ? dice : Enumerable.Empty<Die>();  //TODO: check dice
        }
    }
}