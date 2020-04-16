using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;
using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests.Application.Score.Services
{
    public class FourOfAKindCalculatorUnitTests
    {
        [Fact]
        public void It_Should_Return_SumOfFourDiceWithTheSameNumber_When_GivenFourOfAKind()
        {
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(2),
                new EchoDie(2),
                new EchoDie(2),
                new EchoDie(5),
                new EchoDie(2),
            };

            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice(); //TODO: is this okay that it's no longer required, could just pass in fiveMockDice below

            //Act
            var fourOfAKindCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.FourOfAKind, turn.Dice);

            //Assert
            Assert.Equal(8, fourOfAKindCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfFourDiceWithTheSameNumber_When_GivenFiveOfAKind()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(2),
                new EchoDie(2),
                new EchoDie(2),
                new EchoDie(2),
                new EchoDie(2),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();
        
            //Act
            var fourOfAKindCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.FourOfAKind, turn.Dice);
        
            //Assert
            Assert.Equal(8, fourOfAKindCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfZero_When_NotGivenFourOfAKind()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(2),
                new EchoDie(2),
                new EchoDie(2),
                new EchoDie(5),
                new EchoDie(5),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();
        
            //Act
            var fourOfAKindCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.FourOfAKind, turn.Dice);
        
            //Assert
            Assert.Equal(0, fourOfAKindCalculator.Calculate());
        }
    }
}