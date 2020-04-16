using System.Collections.Generic;
using Yatzy.Application.Dice.Models;

namespace Yatzy.Application.Score.Services.DiceFilter
{
    public interface IDiceFilter
    {
        IEnumerable<IDie> Filter(IEnumerable<IDie> dice);
    }
}