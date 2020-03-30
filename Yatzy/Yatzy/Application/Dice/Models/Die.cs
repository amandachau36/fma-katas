

namespace Yatzy.Application.Dice.Models
{
    public class Die  //TODO: can't move this to the Dice Directory 
    {
        private readonly IRoller _roller;
        public int Value { get; private set; }

        public Die(IRoller roller)  //state design pattern //constructor injection
        {
            _roller = roller;
        }
        
        public void Roll()
        {
            Value = _roller.Roll();
        }
    }
    
}