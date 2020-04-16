using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;

using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests.Application.Score.Services
{
    public class YatzyCalculatorUnitTests
    {
        [Fact]
        public void It_Should_Return_50_When_GivenFiveDiceOfTheSameValue()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(1),
                new EchoDie(1),
                new EchoDie(1),
                new EchoDie(1),
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();

            //Act
            var yatzyCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Yatzy, turn.Dice);

            //Assert
            Assert.Equal(50, yatzyCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_0_When_GivenFiveDiceOfNotTheSameValue()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(1),
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(1),
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();

            //Act
            var yatzyCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Yatzy, turn.Dice);

            //Assert
            Assert.Equal(0, yatzyCalculator.Calculate());

        }
    }
}