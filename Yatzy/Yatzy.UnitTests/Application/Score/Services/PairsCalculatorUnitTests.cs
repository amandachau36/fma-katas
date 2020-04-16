using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;
using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests.Application.Score.Services
{
    public class PairsCalculatorUnitTests 
    {
        [Fact]
        public void It_Should_Return_SumOfHighestPairs_When_GivenTwoPairs()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(4),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var pairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Pairs, turn.Dice);

            //Assert
            Assert.Equal(8, pairsCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfPairs_When_FourOfAKindIsGiven()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(1),
                new EchoDie(1),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var pairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Pairs, turn.Dice);

            //Assert
            Assert.Equal(6, pairsCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_Zero_When_NotGivenTwoOfAKind()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(6),
            };
         
            var turn = new Turn(fiveMockDice);
            turn.RollDice();

            //Act
            var pairsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Pairs, turn.Dice);

            //Assert
            Assert.Equal(0, pairsCalculator.Calculate());
        }
      
    }
}