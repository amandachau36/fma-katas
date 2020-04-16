using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Score.Services.DiceFilter
{
    public class StraightsFilter : IDiceFilter
    {
        private readonly IList<int> _straightsNumbers;

        public StraightsFilter(IList<int> straightsNumbers)
        {
            _straightsNumbers = straightsNumbers;
        }

        public IEnumerable<IDie> Filter(IEnumerable<IDie> dice)
        {
            var diceList = dice.ToList(); //Need to do convert IEnumerable to List to allocate it to separate memory 
            var diceByAscendingOrder =
                from d in diceList //Access IEnumerable  //TODO: what does possible enumeration mean? 
                orderby d.Value 
                select d.Value;
            
            return diceByAscendingOrder.SequenceEqual(_straightsNumbers) ? diceList : Enumerable.Empty<IDie>();
        }
    }
}


//IEnumerable can't access dice[0], access by iterating only
// when we declare new array/list, we are allocating each element to consecutive memory/fixed length
// IEnumberable like linked lists