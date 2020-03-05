using System;

namespace TDD
{
    public class Card
    {
        public decimal Total { get; private set; }
        
        public Tap _TapOn { get; private set; } // naming convention?

        public Tap _TapOff { get; private set; }
        
        public void TopUp(decimal amount)
        {
            Total += amount;
        }

        public void TapOn(Tap tap)
        {
            _TapOn = tap;
        }

        public void TapOff(Tap tap)
        {
            _TapOff = tap;
        }

    }
} 

// just have tap for both ? 