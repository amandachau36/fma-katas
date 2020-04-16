using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;
using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests.Application.Score.Services
{
    public class TwoPairsCalculatorUnitTests
    {
        [Fact]
        public void It_Should_Return_SumOfTwoPairs_When_GivenTwoPairs()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(3),
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();

            //Act
            var twoPairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.TwoPairs, turn.Dice);

            //Assert
            Assert.Equal(8, twoPairsCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_Zero_When_GivenOnePair()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(4),
            };

            var turn = new Turn(fiveMockDice);
            turn.RollDice();

            //Act
            var twoPairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.TwoPairs, turn.Dice);

            //Assert
            Assert.Equal(0, twoPairsCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfTwoPairs_When_GivenPairsAndThreeOfAKind()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(2),
                new EchoDie(2),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var twoPairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.TwoPairs, turn.Dice);

            //Assert
            Assert.Equal(6, twoPairsCalculator.Calculate());
        }
    }
}