using System.Collections.Generic;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Turn.Services.DiceFilter
{
    public interface IDiceFilter
    {
        IEnumerable<Die> Filter(IEnumerable<Die> dice);
    }
}