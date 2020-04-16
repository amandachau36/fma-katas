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
            var dice = new MockDie {Value = 4};

            //act
            dice.Roll();

            //assert
            Assert.Equal(4, dice.Value);
        }
        
        [Fact] 
        public void It_Should_ReturnANewValue_When_RolledAgain()
        {
            //arrange
            var dice = new MockDie {Value = 4};
            dice.Roll();
            dice.Value = 2;

            //act
            dice.Roll();
        
            //assert
            Assert.Equal(2, dice.Value);
        }

        [Fact]
         public void It_Should_ReturnANewValue_When_Rolled_MoqVersion()
         {
             //arrange
             var mockDie = new Mock<IDie>();
             mockDie.Setup(x => x.Value).Returns(4);
             mockDie.Object.Roll();
             
             //act
             mockDie.Setup(x => x.Value).Returns(2);
             mockDie.Object.Roll();
        
             //assert
             Assert.Equal(2, mockDie.Object.Value);
         }
         


        internal class MockDie : IDie
        {
            public int Value { get; set; }
            public bool IsHeld { get; set; }

            public void Roll()
            {
            }

            public void UpdateIsHeld(bool isHeld)
            {
                IsHeld = isHeld;
            }
        }
        
        

    }
}


   