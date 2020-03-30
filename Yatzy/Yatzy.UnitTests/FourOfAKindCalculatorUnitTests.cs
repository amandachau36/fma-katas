using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Turn.Models;
using Yatzy.Application.Turn.Services;
using Yatzy.Application.Turn.Services.CategoryCalculator;

namespace Yatzy.UnitTests
{
    public class FourOfAKindCalculatorUnitTests
    {
        [Fact]
        public void It_Should_Return_SumOfFourDiceWithTheSameNumber_When_GivenFourOfAKind()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(5);
            
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
            turn.Roll();
            turn.Hold(new List<int>{0, 1, 2, 3, 4});
            
            //Act
            var fourOfAKindCalulator = CategoryCalculatorFactory.BuildFourOfKind(turn.DiceHeld);

            //Assert
            Assert.Equal(8, fourOfAKindCalulator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfFourDiceWithTheSameNumber_When_GivenFiveOfAKind()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(2);
            
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
            turn.Roll();
            turn.Hold(new List<int>{0, 1, 2, 3, 4});
            
            //Act
            var fourOfAKindCalculator = CategoryCalculatorFactory.BuildFourOfKind(turn.DiceHeld);

            //Assert
            Assert.Equal(8, fourOfAKindCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfZero_When_NotGivenFourOfAKind()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(5);
            
            var mockRoller5 = new Mock<IRoller>();
            mockRoller5.Setup(x => x.Roll()).Returns(5);
            
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller1.Object),
                new Die(mockRoller2.Object),
                new Die(mockRoller3.Object),
                new Die(mockRoller4.Object),
                new Die(mockRoller5.Object)
            };
            
            var turn = new Turn(fiveMockDice);
            turn.Roll();
            turn.Hold(new List<int>{0, 1, 2, 3, 4});
            
            //Act
            var fourOfAKindCalculator = CategoryCalculatorFactory.BuildFourOfKind(turn.DiceHeld);

            //Assert
            Assert.Equal(0, fourOfAKindCalculator.Calculate());
        }
    }
}