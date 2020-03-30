using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Turn.Services.AggregationStrategy;

namespace Yatzy.Application.Turn.Services.DiceFilter
{
    public class NOfAKindFilter : IDiceFilter 
    {
        private readonly int _nOfAKind;
        private int _numberOfNofAKind;

        public NOfAKindFilter(int nOfKind, int numberOfNofAKind = 1)
        {
            _numberOfNofAKind = numberOfNofAKind;
            _nOfAKind = nOfKind;
        }
        
        public IEnumerable<Die> Filter(IEnumerable<Die> dice)  
        {
            var groupByDiceValue =
                    from d in dice
                    group d by d.Value into g  
                    where g.Count() >= _nOfAKind
                    orderby g.Key descending
                    select g.Take(_nOfAKind);

             var filteredDice = new List<Die>();

             foreach (var group in groupByDiceValue)
             {
                 filteredDice.AddRange(group);

                 if (_numberOfNofAKind == 1) return filteredDice;
             }
             
             
             if(_numberOfNofAKind == 2 && filteredDice.Count == 4) 
                 return filteredDice;

             return Enumerable.Empty<Die>();


             //return groupByDiceValue.FirstOrDefault() ?? Enumerable.Empty<Die>(); //TODO: look at linq and ?? and is there a better way to write above 

             // https://stackoverflow.com/questions/7325278/group-by-in-linq#7325306
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