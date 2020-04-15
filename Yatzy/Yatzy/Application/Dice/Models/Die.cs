

namespace Yatzy.Application.Dice.Models
{
    public class Die  
    {
        private readonly IRoller _roller;
        public int Value { get; private set; }

        public bool IsHeld { get; private set;  }
        

        public Die(IRoller roller)  //state design pattern //constructor injection
        {
            _roller = roller;  //TODO: from a domain perspective a roller should have a die, currently the other way around.
                               //TODO: Get rid of roller and just have dice
        }
        
        public void Roll()
        {
            Value = _roller.Roll();
        }

        public void UpdateIsHeld(bool isHeld)
        {
            IsHeld = isHeld;
        }
    }
    
}