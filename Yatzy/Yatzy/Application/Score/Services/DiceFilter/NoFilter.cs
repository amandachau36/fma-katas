using System.Collections.Generic;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Score.Services.DiceFilter
{
    public class NoFilter : IDiceFilter
    {
        public IEnumerable<IDie> Filter(IEnumerable<IDie> dice)
        {
            return dice;
        }
    }
}