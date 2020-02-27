using System.Collections.Generic;

namespace Algorithm.Composition
{
    public class HighPassSummingAggregator
    {
        private readonly IEnumerable<Measurement> _measurements;
        public HighPassSummingAggregator(IEnumerable<Measurement> measurements)
        {
            _measurements = measurements;
        }
        public Measurement Aggregate()
        {
            var aggregator = new PointsAggregator( _measurements, new HighPassFilter(), new SummingStrategy() );  // this but it seems not that great of an idea to create a new instance every time you want to use the HighPassSummingAggregator 
            return aggregator.Aggregate();
        }
    }
    
    
    // this works  but it duplicates code 
    // public class HighPassSummingAggregator 
    // {
    //     public HighPassSummingAggregator (     
    //         IEnumerable<Measurement> measurements )
    //     {
    //         _measurements = measurements;  
    //         _filter = new HighPassFilter();
    //         _aggregator = new SummingStrategy();
    //     }
    //
    //     public virtual Measurement Aggregate() 
    //     {
    //         var measurements = _measurements;
    //         measurements = _filter.Filter(measurements);            
    //         return _aggregator.Aggregate(measurements);
    //     }
    //
    //     private readonly IEnumerable<Measurement> _measurements;  
    //     private readonly IMeasurementFilter _filter;
    //     private  readonly IAggregationStrategy _aggregator;
    //     
    // }
}