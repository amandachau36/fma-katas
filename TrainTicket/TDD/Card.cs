using System.Collections.Generic;


namespace TDD
{
    public class Card
    {
        private readonly FareCalculator _fareCalculator;

        public Card(FareCalculator fareCalculator)
        {
            _fareCalculator = fareCalculator;
        }
        
        public decimal Total { get; private set; }
        
        public Tap TappedOn { get; private set; }

        public Tap TappedOff { get; private set; }
        
        public List<Trip> Trips { get; private set; } = new List<Trip>(); 
        
        public void TopUp(decimal amount)
        {
            Total += amount;
        }

        public void TapOn(Tap tap)
        {
            TappedOn = tap;
        }

        public void TapOff(Tap tap)
        {
            TappedOff = tap;

            var fare = _fareCalculator.CalculateFare(TappedOn, TappedOff);

            Adjust(fare);
            
            Trips.Add(new Trip(TappedOn, TappedOff, fare));
        }

        public void Adjust(decimal fare)
        {
            Total -= fare;
        }
        
        

    }
} 

