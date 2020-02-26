using Algorithm.Inheritance;
using Xunit;

namespace Algorithm.Tests.Inheritance
{
    public class AggregationTests
    {
        [Fact]
        public void SummingAggregation_Produces_Sum()
        {
            var aggregator = new SummingAggregator(_measurements); // _measurements is passed into the base constructor (points aggregator)

            var result = aggregator.Aggregate();

            Assert.Equal(107, result.X);
            Assert.Equal(30, result.Y);
        }

        [Fact]
        public void AveragingAggregagtor_Produces_Average()
        {
            var aggregator = new AveragingAggregator(_measurements);

            var result = aggregator.Aggregate();

            Assert.Equal(35, result.X); // 35.7  but no decimal b/c it's an int
            Assert.Equal(10, result.Y); 
        }

        [Fact]
        public void LowPassAveragingAggregator_Applys_Filter()  // lowpass means both x and y of a measurement are < 100 
        {
            var aggregator = new LowPassAveragingAggregator(_measurements);

            var result = aggregator.Aggregate();

            Assert.Equal(3, result.X);  // averages { X = 5, Y = 10}  and this { X = 2, Y = 15},
            Assert.Equal(12, result.Y);            
        }

        /// Uncomment this test and make it pass reusing as much code as 
        /// possible from other classes that are availalbe in the Inheritance folder
        [Fact]
        public void HighPassSummingAggregator_Applys_Filter()
        {                
            var aggregator = new HighPassSummingAggregator(_measurements);

            var result = aggregator.Aggregate();

            Assert.Equal(105, result.X);
            Assert.Equal(15, result.Y);
        }

        Measurement[] _measurements = new[]
        {
            new Measurement { X = 5, Y = 10},
            new Measurement { X = 2, Y = 15},
            new Measurement { X = 100, Y = 5}                  
        };
    }
}