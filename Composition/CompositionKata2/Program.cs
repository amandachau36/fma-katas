using System;
using System.Collections.Generic;
using System.Linq;
using Algorithm;
using Algorithm.Inheritance;

namespace CompositionKata2
{
    class Program
    {
        static void Main(string[] args)
        {
            Measurement[] _measurements = new[] //arrange
            {
                new Measurement { X = 5, Y = 10},
                new Measurement { X = 2, Y = 15},
                new Measurement { X = 100, Y = 5}                  
            };

            IEnumerable<Measurement> FilterMeasurements(IEnumerable<Measurement> measurements) 
            {    
                return measurements.Where(m =>  m.Y > 2);
            }

            var filtered = FilterMeasurements(_measurements);

            foreach (var measurement in filtered)
            {
                Console.WriteLine(measurement.X + " " + measurement.Y);
            }
            
            // var aggregator = new LowPassAveragingAggregator(_measurements);
            
            
        }
    }
}