using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;
using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests
{
    public class PairsCalculatorUnitTests 
    {
        [Fact]
        public void It_Should_Return_SumOfHighestPairs_When_GivenTwoPairs()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(4);
            
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
            var pairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Pairs, turn.Dice);

            //Assert
            Assert.Equal(8, pairsCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfPairs_When_FourOfAKindIsGiven()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller5 = new Mock<IRoller>();
            mockRoller5.Setup(x => x.Roll()).Returns(1);
            
            
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
            var pairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Pairs, turn.Dice);

            //Assert
            Assert.Equal(6, pairsCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_Zero_When_NotGivenTwoOfAKind()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(4);
            
            var mockRoller5 = new Mock<IRoller>();
            mockRoller5.Setup(x => x.Roll()).Returns(6);
            
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
            var pairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Pairs, turn.Dice);

            //Assert
            Assert.Equal(0, pairsCalculator.Calculate());
        }
      
    }
}