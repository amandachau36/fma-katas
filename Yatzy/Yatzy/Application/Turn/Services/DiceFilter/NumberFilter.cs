using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Turn.Services.DiceFilter
{
    public class NumberFilter : IDiceFilter
    {
        private readonly int _number;

        public NumberFilter(int number)
        {
            _number = number;
        }
        
        public IEnumerable<Die> Filter(IEnumerable<Die> dice)
        {
            var diceWithNumber = dice.Where(d => d.Value == _number);
            
            return diceWithNumber;
        }
    }
}