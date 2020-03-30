using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Turn.Models;
using Yatzy.Application.Turn.Services.CategoryCalculator;

namespace Yatzy.UnitTests
{
    public class OnesTwosThreesCalculatorUnitTests
    {
        [Fact]
        public void It_Should_Return_SumOfSixes_When_PlacedOnSix_And_GivenSix()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(6);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(2);
            
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
            turn.Roll();
            turn.Hold(new List<int>{0, 1, 2, 3, 4});
            
            //Act
            var sixesCalculator = CategoryCalculatorFactory.BuildSixes(turn.DiceHeld);

            //Assert
            Assert.Equal(6, sixesCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfFives_When_PlacedOnFive_And_GivenFives()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(6);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(5);
            
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
            var fivesCalculator = CategoryCalculatorFactory.BuildFives(turn.DiceHeld);

            //Assert
            Assert.Equal(15, fivesCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfFours_When_PlacedOnFours_And_GivenFours()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(2);
            
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
            turn.Roll();
            turn.Hold(new List<int>{0, 1, 2, 3, 4});
            
            //Act
            var foursCalulator = CategoryCalculatorFactory.BuildFours(turn.DiceHeld);

            //Assert
            Assert.Equal(8, foursCalulator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfThrees_When_PlacedOnThrees_And_GivenThrees()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(3);
            
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
            turn.Roll();
            turn.Hold(new List<int>{0, 1, 2, 3, 4});
            
            //Act
            var threesCalculator = CategoryCalculatorFactory.BuildThrees(turn.DiceHeld);

            //Assert
            Assert.Equal(12, threesCalculator.Calculate());
        }

        
        [Fact]
        public void It_Should_Return_SumOfTwos_When_PlacedOnTwos_And_GivenTwos()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(5);
            
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
            turn.Roll();
            turn.Hold(new List<int>{0, 1, 2, 3, 4});
            
            //Act
            var twosCalculator = CategoryCalculatorFactory.BuildTwos(turn.DiceHeld);

            //Assert
            Assert.Equal(4, twosCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfZero_When_PlacedOnOnes_NotGivenOnes()
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
            var onesCalculator = CategoryCalculatorFactory.BuildOnes(turn.DiceHeld);

            //Assert
            Assert.Equal(0, onesCalculator.Calculate());
        }
    }
}