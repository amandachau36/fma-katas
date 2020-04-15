using Moq;
using Xunit;
using Yatzy.Application;
using Yatzy.Application.Dice.Models;

namespace Yatzy.UnitTests.Application.Dice
{
    public class DiceUnitTests
    {
        
        [Fact]
        public void It_Should_ReturnANumber_When_Rolled()
        {
            //arrange
            var mockRoller = new MockRoller();
            mockRoller.Value = 4;
            var dice = new Die(mockRoller);
            
            //act
            dice.Roll();

            //assert
            Assert.Equal(4, dice.Value);
        }
        
        [Fact] 
        public void It_Should_ReturnANewValue_When_RolledAgain()
        {
            //arrange
            var mockRoller = new MockRoller();
            mockRoller.Value = 4;
            var dice = new Die(mockRoller);
            
            //act
            dice.Roll();
            mockRoller.Value = 2;
            dice.Roll();

            //assert
            Assert.Equal(2, dice.Value);
        }

        [Fact]
         public void It_Should_ReturnANewValue_When_Rolled_MoqVersion()
         {
             //arrange
             var mock = new Mock<IRoller>();
             mock.Setup(x => x.Roll()).Returns(4);
             var dice = new Die(mock.Object);
             dice.Roll();
             
             //act
             mock.Setup(x => x.Roll()).Returns(2);
             dice.Roll();
        
             //assert
             Assert.Equal(2, dice.Value);
         }
         
        internal class MockRoller : IRoller //internal within the project
        {
            public int Value { get; set; }
            public int Roll()
            {
                return Value;
            }
        }
        
        

    }
}


   