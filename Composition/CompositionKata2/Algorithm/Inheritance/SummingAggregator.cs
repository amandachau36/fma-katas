using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Inheritance
{
    public class SummingAggregator : PointsAggregator  // inherits from abstract class 
    {
        public SummingAggregator(IEnumerable<Measurement> measurements) : base(measurements) // this required because the base class has a constructor which takes an arg
        {                                                                                    // ? a static constructor because there are no parameters
        }

        protected override IEnumerable<Measurement> FilterMeasurements(IEnumerable<Measurement> measurements)  //can override because parent method is abstract. This protected because parent method is protected
        {
            return measurements;  // just return measurements because no filtering for this class 
        }

        protected override Measurement AggregateMeasurements(IEnumerable<Measurement> measurements)
        {
            return new Measurement
            {
                X = measurements.Sum(m => m.X), 
                Y = measurements.Sum(m => m.Y)
            };
        }
    }
}