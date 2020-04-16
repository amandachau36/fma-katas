using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score.Services.AggregationStrategy;

namespace Yatzy.Application.Score.Services.DiceFilter
{
    public class NOfAKindFilter : IDiceFilter 
    {
        private readonly int _nOfAKind;
        private readonly int _numberOfNofAKind;
        
        public NOfAKindFilter(int nOfKind, int numberOfNofAKind = 1)
        {
            _numberOfNofAKind = numberOfNofAKind;
            _nOfAKind = nOfKind;
        }
        
        public IEnumerable<IDie> Filter(IEnumerable<IDie> dice)  
        {
            var groupByDiceValue =
                    from d in dice
                    group d by d.Value into g  
                    where g.Count() >= _nOfAKind
                    orderby g.Key descending
                    select g.Take(_nOfAKind);
            
            if (_numberOfNofAKind == 1) return groupByDiceValue.FirstOrDefault() ?? Enumerable.Empty<IDie>(); 
            
             var filteredDice = new List<IDie>();

             foreach (var group in groupByDiceValue)
             {
                 filteredDice.AddRange(group);
             }
             
           
             return IsPlacedOnTwoPairs(_numberOfNofAKind) && TwoPairsPresent(filteredDice) 
                 ? filteredDice 
                 : Enumerable.Empty<IDie>();
             

             // https://stackoverflow.com/questions/7325278/group-by-in-linq#7325306
        }

        private static bool IsPlacedOnTwoPairs(int numberOfNOfAKind)
        {
            return numberOfNOfAKind == 2 ;
        }

        private static bool TwoPairsPresent(List<IDie> filteredDice)
        {
            return filteredDice.Count == 4;
        }
        
    }
}





// var groupByDiceValue = dice
// .OrderByDescending(x => x.Value)
// .GroupBy(x => x.Value);
//             
//             
// var filteredDice = new List<Die>();
//
// foreach (var group in groupByDiceValue)
// {
// if (group.Count() >= NOfAKind)
// {
//     var count = 0;
//     foreach (var die in group)
//     {
//         if (count >= NOfAKind) break;
//                         
//         filteredDice.Add(die);
//
//         count++;
//
//     }
//
//     break;
// }
//                 
// }

//return filteredDice;