using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using Yatzy.Application;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Exceptions;
using Yatzy.Application.Score.Models;
using Yatzy.UnitTests.Application.Dice;


namespace Yatzy.UnitTests.Application.SingleTurn
{
    public class TurnUnitTests
    {
        [Fact]
        public void It_Should_ReturnFiveValues_When_DiceAreRolled()
        {
            //arrange
            var mockRoller = new DiceUnitTests.MockRoller(); //TODO: fix thiss . . . . 
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
            turn.RollDice();
            
            //assert  
            foreach (var die in turn.Dice)
            {
                Assert.Equal(3, die.Value);
            }
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
            turn.RollDice();
            turn.RollDice();
            turn.RollDice();
            
            //act
            Action actual = () => turn.RollDice();
            
            
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
            turn.RollDice();
            
            //act
            turn.HoldDice(new List<int>{1, 4});
            

            //assert 
            Assert.Equal(2, turn.Dice.Count(d => d.IsHeld));
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
            turn.RollDice();
            
            //act
            turn.HoldDice(new List<int>{1, 4});
            
            //assert 
            Assert.Equal(3, turn.Dice.Count(d => d.IsHeld == false));
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
            turn.RollDice();
            
            //act
            turn.HoldDice(new List<int>{1, 4});
            
            //assert 
            var expectedIsHeld = new List<bool>{true, false, false, true, false};

            for (var i = 0; i < turn.Dice.Count; i++) //TODO: is there a better way to write this?  
            {
                Assert.Equal(expectedIsHeld[i], turn.Dice[i].IsHeld);
            }
            
  
        }
        
        
        [Fact]
        public void It_Should_Throw_InvalidDiceValueException_When_Hold_Receives_InvalidDiceValue()
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
            turn.RollDice();
            
            //act
            Action actual = () => turn.HoldDice(new List<int>{3, 6, 3});
            
            //assert 
            var exception = Assert.Throws<InvalidDiceValueException>(actual);
            Assert.Equal("These value(s) are invalid: 6, 3", exception.Message);
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
            turn.RollDice();
            turn.HoldDice(new List<int>{1, 4});
            
            mockRoller2.Setup(x => x.Roll()).Returns(6);
            mockRoller3.Setup(x => x.Roll()).Returns(6);
            mockRoller5.Setup(x => x.Roll()).Returns(1);

            //act
            turn.RollDice();
            
            //assert 
            var expectedValues = new List<int> {1, 6, 6, 4, 1};
            
            for (var i = 0; i < turn.Dice.Count; i++)
            {
                Assert.Equal(expectedValues[i], turn.Dice[i].Value );
            }
      
        }
        
        [Fact]
        public void It_Should_HoldAllDice_When_RolledThreeTimes()
        {
            //arrange
            var mockRoller = new DiceUnitTests.MockRoller {Value = 3};
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
            };
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            turn.RollDice();
            
            //act
            turn.RollDice();
            
            
            //assert  
            foreach (var die in turn.Dice)
            {
                Assert.True(die.IsHeld);
            }

        } 
        
        
        [Fact]
        public void It_Should_ResetRollCountToZero_When_TurnIsReset()
        {
            //arrange
            var mockRoller = new DiceUnitTests.MockRoller {Value = 3};
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
            };
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            turn.RollDice();
            turn.RollDice();
            turn.HoldDice(new List<int>{3, 3, 3, 3, 3});
            
            //act
            turn.ResetTurn();
            
            //assert  
            Assert.Equal(0, turn.RollCount);
        } 
        
        [Fact]
        public void It_Should_ResetIsHeldToFalse_When_TurnIsReset()
        {
            //arrange
            var mockRoller = new DiceUnitTests.MockRoller {Value = 3};
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
                new Die(mockRoller),
            };
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            turn.RollDice();
            turn.RollDice();
            turn.HoldDice(new List<int>{3, 3, 3, 3, 3});
            
            //act
            turn.ResetTurn();
            
            //assert  
            foreach (var die in turn.Dice)
            {
                Assert.False(die.IsHeld);
            }
        } 
    }
}