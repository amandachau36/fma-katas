using System.Collections.Generic;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Turn.Services.DiceFilter
{
    public class NoFilter : IDiceFilter
    {
        public IEnumerable<Die> Filter(IEnumerable<Die> dice)
        {
            return dice;
        }
    }
}