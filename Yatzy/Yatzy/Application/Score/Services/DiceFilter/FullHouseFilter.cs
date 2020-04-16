using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Score.Services.DiceFilter
{
    public class FullHouseFilter : IDiceFilter
    {
        public IEnumerable<IDie> Filter(IEnumerable<IDie> dice)
        {
            var groupByDiceValue =
                from d in dice
                group d by d.Value;

            return IsFullHousePresent(groupByDiceValue) ? dice : Enumerable.Empty<IDie>();  
        }

        private static bool IsFullHousePresent(IEnumerable<IGrouping<int, IDie>> groupByDiceValue)
        {
            return groupByDiceValue.Count() == 2 && new[] {2, 3}.Contains(groupByDiceValue.First().Count());
        }
        
    }
    
}




