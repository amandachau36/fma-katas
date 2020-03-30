using System;
using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Exceptions;
using Yatzy.Application.Turn.Models;


namespace Yatzy.UnitTests
{
    public class TurnUnitTests
    {
        [Fact]
        public void It_Should_ReturnFiveValues_When_DiceAreRolled()
        {
            //arrange
            var mockRoller = new DiceUnitTests.MockRoller();
            mockRoller.Value = 3;
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
            };
            var turn = new Turn(fiveMockDice);
            
            //act
            turn.Roll();
            
            //assert  
            foreach (var die in turn.DiceToRoll)
            {
                Assert.Equal(3, die.Value);
            }
        }

        [Fact]
        public void It_Should_Throw_ArgumentOutOfRangeException_When_TotalNumOfDiceIsNotFive()
        {
            //arrange
            var mockRoller = new DiceUnitTests.MockRoller();
            mockRoller.Value = 3;
            var fourMockDice = new List<Die>
            {
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
            };
            
            //act
            Action actual = () =>  new Turn(fourMockDice);


            //assert 
            Assert.Throws<ArgumentOutOfRangeException>(actual);
        }
  
        [Fact]
        public void It_Should_Throw_MaxNumberOfRollsExceededException_When_RolledFourTimes()
        {
            //arrange
            var mockRoller = new DiceUnitTests.MockRoller();
            mockRoller.Value = 3;
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
            };
            var turn = new Turn(fiveMockDice);
            turn.Roll();
            turn.Roll();
            turn.Roll();
            
            //act
            Action actual = () => turn.Roll();
            
            
            //assert  
            Assert.Throws<MaxNumberOfRollsExceededException>(actual);
            
        }
        
        
        [Fact]
        public void It_Should_Return_TwoDiceHeld_When_DiceIndexZeroAndThreeAreHeld()
        {
            //arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(2);
            
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
            
            //act
            turn.Hold(new List<int>{0, 3});
            
            //assert 
            Assert.Equal(2, turn.DiceHeld.Count);
        }
        
        [Fact]
        public void It_Should_Return_ThreeDiceToRoll_When_DiceIndexZeroAndThreeAreHeld()
        {
            //arrange
            
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(2);
            
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
            
            //act
            turn.Hold(new List<int>{0, 3});
            
            //assert 
            Assert.Equal(3, turn.DiceToRoll.Count);
        }
        
        [Fact]
        public void It_Should_Return_CorrectDiceHeld_When_DiceAreHeld()
        {
            //arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(2);
            
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
            
            //act
            turn.Hold(new List<int>{0, 3});
            
            //assert 
            Assert.Equal(1, turn.DiceHeld[0].Value);
            Assert.Equal(4, turn.DiceHeld[1].Value);
            
        }
        
        
        [Fact]
        public void It_Should_Return_CorrectDiceToReRoll_When_SomeDiceAreHeld()
        {
            //arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(2);
            
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
            
            //act
            turn.Hold(new List<int>{0, 3});
            
            //assert 
            Assert.Equal(2, turn.DiceToRoll[0].Value);
            Assert.Equal(3, turn.DiceToRoll[1].Value);
            Assert.Equal(5, turn.DiceToRoll[2].Value);
            
        }
        
        [Fact]
        public void It_Should_Throw_InvalidDiceIndexException_When_Hold_Receives_InvalidDiceIndex()
        {
            //arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(2);
            
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
            
            //act
            Action actual = () => turn.Hold(new List<int>{0, 5});
            
            //assert 
            var exception = Assert.Throws<InvalidDiceIndexException>(actual);
            Assert.Equal("5 is not a valid index. Index must be a non-negative number and 4 or less.", exception.Message);
        }
        
        [Fact]
        public void It_Should_ReturnCorrectReRolledDice_When_Rolled_AfterSomeDiceAreHeld()
        {
            //arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(2);
            
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
            turn.Hold(new List<int>{0, 3});
            
            mockRoller2.Setup(x => x.Roll()).Returns(6);
            mockRoller3.Setup(x => x.Roll()).Returns(6);
            mockRoller5.Setup(x => x.Roll()).Returns(1);

            //act
            turn.Roll();
            
            //assert 
            Assert.Equal(6, turn.DiceToRoll[0].Value);
            Assert.Equal(6, turn.DiceToRoll[1].Value);
            Assert.Equal(1, turn.DiceToRoll[2].Value);
        }
        
        
    }
}