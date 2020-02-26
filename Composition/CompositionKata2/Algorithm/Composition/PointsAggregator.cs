﻿using System.Collections.Generic;

namespace Algorithm.Composition
{
    public class PointsAggregator
    {
        public PointsAggregator(     // why do we want to take in measurements here? why not just pass in measurements for Aggregate?>
            IEnumerable<Measurement> measurements, 
            IMeasurementFilter filter, 
            IAggregationStrategy aggregator)
        {
            _measurements = measurements;  
            _filter = filter;
            _aggregator = aggregator;
        }

        public virtual Measurement Aggregate() // virtual - this means it can be overridden in a derived class  
        {
            var measurements = _measurements;
            measurements = _filter.Filter(measurements);            
            return _aggregator.Aggregate(measurements);
        }

        private readonly IEnumerable<Measurement> _measurements;  // private fields that can only be set before the constructor exits
        private readonly IMeasurementFilter _filter;
        private readonly IAggregationStrategy _aggregator;
    }        
}