using Algorithm.Composition;
using Xunit;
using PointsAggregator = Algorithm.Composition.PointsAggregator;

namespace Algorithm.Tests.Composition
{
    public class AggregationTests
    {
        [Fact]
        public void SummingAggregation_Produces_Sum()
        {
            var aggregator = new PointsAggregator(_measurements, new EmptyFilter(), new SummingStrategy());

            var result = aggregator.Aggregate();

            Assert.Equal(107, result.X); //sums up x and ys
            Assert.Equal(30, result.Y);
        }

        [Fact]
        public void AveragingAggregagtor_Produces_Average()
        {
            var aggregator = new PointsAggregator(_measurements, new EmptyFilter(), new AveragingStrategy());

            var result = aggregator.Aggregate();

            Assert.Equal(35, result.X);
            Assert.Equal(10, result.Y);
        }

        [Fact]
        public void LowPassAveragingAggregator_Applys_Filter()
        {
            var aggregator = new PointsAggregator(_measurements, new LowPassFilter(), new AveragingStrategy());

            var result = aggregator.Aggregate();

            Assert.Equal(3, result.X);
            Assert.Equal(12, result.Y);            
        }

        // Uncomment this test and make it pass reusing as much code as 
         //possible from other classes that are available in the Composition folder
        [Fact]
        public void HighPassSummingAggregator_Applys_Filter()
        {                
            var aggregator = new PointsAggregator(_measurements, new HighPassFilter(), new SummingStrategy());
        
            var result = aggregator.Aggregate();
        
            Assert.Equal(105, result.X); // add everything that that is > 2 together 
            Assert.Equal(15, result.Y);
        }

        // Uncomment this test and make it pass by building a new class to 
        // hide the "composition" of strategies and filters ...
        
        // this passed without me doing anything  . . .
        [Fact]
        public void CustomHighPassSummingAggregator_Applys_Filter()  
        {                
            var aggregator = new HighPassSummingAggregator(_measurements); 
        
            var result = aggregator.Aggregate();
        
            Assert.Equal(105, result.X);
            Assert.Equal(15, result.Y);
        }

        Measurement[] _measurements = new[] //arrange
        {
            new Measurement { X = 5, Y = 10},
            new Measurement { X = 2, Y = 15},
            new Measurement { X = 100, Y = 5}                  
        };
    }
}