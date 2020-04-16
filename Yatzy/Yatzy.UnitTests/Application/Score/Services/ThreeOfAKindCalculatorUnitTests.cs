using System.Collections.Generic;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;
using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests.Application.Score.Services
{
    public class ThreeOfAKindCalculatorUnitTests
    {
        [Fact]
        public void It_Should_Return_SumOfThreeDiceWithTheSameNumber_When_GivenThreeOfAKind()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(5),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var threeOfAKindCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.ThreeOfAKind, turn.Dice);

            //Assert
            Assert.Equal(9, threeOfAKindCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfThreeDiceWithTheSameNumber_When_GivenFourOfAKind()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(5),
            };
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var threeOfAKindCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.ThreeOfAKind, turn.Dice);

            //Assert
            Assert.Equal(9, threeOfAKindCalculator.Calculate());
        }

        
        [Fact]
        public void It_Should_Return_SumOfZero_When_NotGivenThreeOfAKind()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(5),
                new EchoDie(5),
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();

            //Act
            var threeOfAKindCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.ThreeOfAKind, turn.Dice);

            //Assert
            Assert.Equal(0, threeOfAKindCalculator.Calculate());
        }
        
    }
}