using System.Collections.Generic;
using Moq;
using TestDoubles;
using Xunit;
using TestDoubles;

namespace TestDoubles.UnitTests
{
    
    public class UnitTest1
    {
        [Fact]
        public void TestWithCustomMock()
        {
            //arrange
            var mockGoogleLiveRate = new MockGoogleLiveRate();
            mockGoogleLiveRate.Name = "google";
            
            var fareCalculator = new FareCalculator(new List<ILiveRate>{mockGoogleLiveRate});
            fareCalculator.Commission = 2m;

            //act
            var fare = fareCalculator.CalculateFare(mockGoogleLiveRate.Name);


            //assert
            Assert.Equal(10.6m, fare);

        }
        
        [Fact]
        public void TestWithMoq()
        {
            //arrange
            var mock = new Mock<ILiveRate>();  //more dependencies. //if tests are too difficult to write, consider rewriting the application
            mock.Setup(x => x.GetRate()).Returns(5.3m);
            mock.Setup(x => x.Name).Returns("google"); 

            var fareCalculator = new FareCalculator(new List<ILiveRate>{mock.Object});
            fareCalculator.Commission = 2m;

            //act
            var fare = fareCalculator.CalculateFare("google");
            
            //assert
            Assert.Equal(10.6m, fare);

        }

        internal class MockGoogleLiveRate : ILiveRate
        {
            public string Name { get; set; }

            public decimal GetRate()
            {
                return 5.3m;
            }
        }
    }
}