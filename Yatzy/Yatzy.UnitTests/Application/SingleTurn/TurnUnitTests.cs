using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Exceptions;
using Yatzy.Application.Score.Models;
using Yatzy.UnitTests.Application.Dice;
using Yatzy.UnitTests.Application.Score.Services;


namespace Yatzy.UnitTests.Application.SingleTurn
{
    public class TurnUnitTests
    {
        [Fact]
        public void It_Should_ReturnFiveValues_When_DiceAreRolled()
        {
            //arrange
            var fiveMockDice = new List<IDie>
            {
                new RandomDie(),
                new RandomDie(),
                new RandomDie(),
                new RandomDie(),
                new RandomDie(),
            };
            var turn = new Turn(fiveMockDice);
            
          
            //act
            turn.RollDice();
            
            //assert  
            foreach (var die in turn.Dice)
            {
                Assert.NotEqual(0, die.Value);
            }
        }
        
        [Fact]
        public void It_Should_Throw_MaxNumberOfRollsExceededException_When_RolledFourTimes()
        {
            //arrange
            var fiveMockDice = new List<IDie>
            {
                new RandomDie(),
                new RandomDie(),
                new RandomDie(),
                new RandomDie(),
                new RandomDie(),
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
        public void It_Should_Return_TwoDiceHeld_When_TwoDiceAreHeld()
        {
            //arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(5),
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            
            //act
            turn.HoldDice(new List<int>{1, 4});
            
        
            //assert 
            Assert.Equal(2, turn.Dice.Count(d => d.IsHeld));
        }
        
        [Fact]
        public void It_Should_Return_ThreeDiceToRoll_When_TwoDiceAreHeld()
        {
            //arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(5),
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
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(5),
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            
            //act
            turn.HoldDice(new List<int>{1, 4});
            
            //assert 
            var expectedIsHeld = new List<bool>{true, false, false, true, false};
        
            var diceIsHeldStatus = turn.Dice.Select(x => x.IsHeld);
            
            Assert.True(diceIsHeldStatus.SequenceEqual(expectedIsHeld));
            
        }
        
        
        [Fact]
        public void It_Should_Throw_InvalidDiceValueException_When_Hold_Receives_InvalidDiceValue()
        {
            //arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(5),
            };

            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            
            //act
            Action actual = () => turn.HoldDice(new List<int>{3, 6, 3});
            
            //assert 
            var exception = Assert.Throws<InvalidDiceValueException>(actual);
            Assert.Equal("These value(s) are invalid: 6, 3", exception.Message);
        }
        
        // [Fact]
        // public void It_Should_ReturnCorrectReRolledDice_When_Rolled_AfterSomeDiceAreHeld()
        // {
        //     //arrange
        //     // var mockRoller1 = new Mock<IRoller>();
        //     // mockRoller1.Setup(x => x.Roll()).Returns(1);
        //     //
        //     // var mockRoller2 = new Mock<IRoller>();
        //     // mockRoller2.Setup(x => x.Roll()).Returns(2);
        //     //
        //     // var mockRoller3 = new Mock<IRoller>();
        //     // mockRoller3.Setup(x => x.Roll()).Returns(3);
        //     //
        //     // var mockRoller4 = new Mock<IRoller>();
        //     // mockRoller4.Setup(x => x.Roll()).Returns(4);
        //     //
        //     // var mockRoller5 = new Mock<IRoller>();
        //     // mockRoller5.Setup(x => x.Roll()).Returns(5);
        //     //
        //     //
        //     // var fiveMockDice = new List<Die>
        //     // {
        //     //     new Die(mockRoller1.Object),
        //     //     new Die(mockRoller2.Object),
        //     //     new Die(mockRoller3.Object),
        //     //     new Die(mockRoller4.Object),
        //     //     new Die(mockRoller5.Object)
        //     // };
        //     
        //     var mockDie1 =  new Mock<IDie>();
        //     mockDie1.Setup(x => x.Value).Returns(1);
        //     
        //     var mockDie2 =  new Mock<IDie>();
        //     mockDie2.Setup(x => x.Value).Returns(2);
        //     
        //     var mockDie3 =  new Mock<IDie>();
        //     mockDie3.Setup(x => x.Value).Returns(3);
        //     
        //     var mockDie4 =  new Mock<IDie>();
        //     mockDie4.Setup(x => x.Value).Returns(4);
        //     
        //     var mockDie5 =  new Mock<IDie>();
        //     mockDie5.Setup(x => x.Value).Returns(5);
        //     
        //     
        //     var fiveMockDice = new List<IDie>
        //     {
        //         mockDie1.Object,
        //         mockDie2.Object,
        //         mockDie3.Object,
        //         mockDie4.Object,
        //         mockDie5.Object
        //     };
        //
        //     
        //     var turn = new Turn(fiveMockDice);
        //     turn.RollDice();
        //     turn.HoldDice(new List<int>{1, 4});
        //     
        //     mockRoller2.Setup(x => x.Roll()).Returns(6);  //TODO: how do I test that REROll is working. . 
        //     mockRoller3.Setup(x => x.Roll()).Returns(6);
        //     mockRoller5.Setup(x => x.Roll()).Returns(1);
        //
        //     //act
        //     turn.RollDice();
        //     
        //     //assert 
        //     var expectedValues = new List<int> {1, 6, 6, 4, 1};
        //
        //     var actualDiceValues = turn.Dice.Select(x => x.Value);
        //     
        //     Assert.True(actualDiceValues.SequenceEqual(expectedValues));
        //     
        // }
        
        [Fact]
        public void It_Should_HoldAllDice_When_RolledThreeTimes()
        {
            //arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(5),
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
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(3),
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
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(3),
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