using System.Collections.Generic;

namespace Algorithm.Inheritance
{
    public abstract class PointsAggregator //base class of other classes, cannot be instantiated
    {
                                    //Uses the IEnumerable interface, things that can be looped over with foreach
        protected PointsAggregator(IEnumerable<Measurement> measurements)  // Protected constructor: can only be accessible from this class and classes that inherit from it but not instances of the class 
        {
            Measurements = measurements;
        }

        public virtual Measurement Aggregate()  // virtual method allows it to be overriden in a derived class 
        {
            var measurements = Measurements;
            measurements = FilterMeasurements(measurements);
            return AggregateMeasurements(measurements);
        }

        protected abstract IEnumerable<Measurement> FilterMeasurements(IEnumerable<Measurement> measurements); // an abstract method is implicitly a virtual method - only has declarations, no body
        protected abstract Measurement AggregateMeasurements(IEnumerable<Measurement> measurements);
        
        protected readonly IEnumerable<Measurement> Measurements;  //readonly canNOT be assigned after the constructor exits
    }        
}