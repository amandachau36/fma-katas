using System;

namespace TDD
{
    public class Card
    {
        public decimal Total { get; private set; }
        
        public TapOn _TapOn { get; private set; }

        public void TopUp(decimal amount)
        {
            Total += amount;
        }

        public void TapOn(TapOn tapOn)
        {
            _TapOn = tapOn;
        }
        
        
    }
}