using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;
using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests.Application.Score.Services
{
    public class TwoPairsCalculatorUnitTests
    {
        [Fact]
        public void It_Should_Return_SumOfTwoPairs_When_GivenTwoPairs()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller5 = new Mock<IRoller>();
            mockRoller5.Setup(x => x.Roll()).Returns(3);
            
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller1.Object),
                new Die(mockRoller2.Object),
                new Die(mockRoller3.Object),
                new Die(mockRoller4.Object),
                new Die(mockRoller5.Object)
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();

            //Act
            var twoPairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.TwoPairs, turn.Dice);

            //Assert
            Assert.Equal(8, twoPairsCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_Zero_When_GivenOnePair()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller5 = new Mock<IRoller>();
            mockRoller5.Setup(x => x.Roll()).Returns(4);
            
            
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller1.Object),
                new Die(mockRoller2.Object),
                new Die(mockRoller3.Object),
                new Die(mockRoller4.Object),
                new Die(mockRoller5.Object)
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();

            //Act
            var twoPairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.TwoPairs, turn.Dice);

            //Assert
            Assert.Equal(0, twoPairsCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfTwoPairs_When_GivenPairsAndThreeOfAKind()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller5 = new Mock<IRoller>();
            mockRoller5.Setup(x => x.Roll()).Returns(2);
            
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller1.Object),
                new Die(mockRoller2.Object),
                new Die(mockRoller3.Object),
                new Die(mockRoller4.Object),
                new Die(mockRoller5.Object)
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();

            //Act
            var twoPairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.TwoPairs, turn.Dice);

            //Assert
            Assert.Equal(6, twoPairsCalculator.Calculate());
        }
    }
}