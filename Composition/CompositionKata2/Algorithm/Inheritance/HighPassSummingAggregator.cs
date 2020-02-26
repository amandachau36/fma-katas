﻿using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Inheritance
{
    /// <summary>
    /// Should filter out measurements with an X or Y that are less than or equal to 2
    /// You'll need to inherit and override methods from other classes in the inheritance folder
    /// </summary>
    
    

    public class HighPassSummingAggregator : SummingAggregator
    {
        // this constructor is required because SummingAgregator inherits from point Aggregator which has protected constructor
        public HighPassSummingAggregator(IEnumerable<Measurement> measurements) : base(measurements)
        {
        }
        
        // able to override because it's an abstract
        protected override IEnumerable<Measurement> FilterMeasurements(IEnumerable<Measurement> measurements)  //can override because parent method is abstract. This protected because parent method is protected
        {    // not m.X > 2 && m.Y > 2 because  { X = 2, Y = 15} is NOT Filtered out Y is > 2  which means the whole expression evaluates to true  
            return measurements.Where(m => m.X > 2 && m.Y > 2);
        }
        
        // It will use AggregateMeasurements method for SummingAggregator
        
        
    }    
}