using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDoubles
{
    public class FareCalculator
    {
        private readonly List<ILiveRate> _liveRates;
        
        public decimal Commission { get; set; } 

        public FareCalculator(List<ILiveRate> liveRates)
        {
            _liveRates = liveRates;
        }
        
        public decimal CalculateFare(string liveRateName)
        {
            var liveRate = _liveRates.FirstOrDefault(x => x.Name == liveRateName);

            return liveRate.GetRate() * Commission;
        }
    }
}