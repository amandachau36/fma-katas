using System;

namespace Yatzy.Application.Dice.Models
{
    public class RandomDie : IDie
    {
        public int Value { get; private set; }
        
        public bool IsHeld { get; private set;  }

        public void Roll()
        {
            var random = new Random();

            Value = random.Next(Constants.MinimumDiceValue, Constants.MaximumDiceValue + 1);
        }

        public void UpdateIsHeld(bool isHeld)
        {
            IsHeld = isHeld;
        }
    }
}