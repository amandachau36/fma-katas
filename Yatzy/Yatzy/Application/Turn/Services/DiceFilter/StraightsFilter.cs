using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Turn.Services.DiceFilter
{
    public class StraightsFilter : IDiceFilter
    {
        private readonly IList<int> _straightsNumbers;

        public StraightsFilter(IList<int> straightsNumbers)
        {
            _straightsNumbers = straightsNumbers;
        }

        public IEnumerable<Die> Filter(IEnumerable<Die> dice)
        {
            var diceByAscendingOrder =
                from d in dice   //TODO: what does possible enumeration mean?
                orderby d.Value
                select d.Value;

            return diceByAscendingOrder.SequenceEqual(_straightsNumbers) ? dice : Enumerable.Empty<Die>();
        }
    }
}