using System.Collections.Generic;
using Xunit;
using Moq;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;

using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests
{
    public class YatzyCalculatorUnitTests
    {
        [Fact]
        public void It_Should_Return_50_When_GivenFiveDiceOfTheSameValue()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(1);
            
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
            
            var yatzyCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Yatzy, turn.Dice);

            //Assert
            Assert.Equal(50, yatzyCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_0_When_GivenFiveDiceOfNotTheSameValue()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(1);
            
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
            var yatzyCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Yatzy, turn.Dice);

            //Assert
            Assert.Equal(0, yatzyCalculator.Calculate());

        }
    }
}