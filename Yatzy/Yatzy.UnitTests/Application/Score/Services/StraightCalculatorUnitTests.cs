using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;
using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests.Application.Score.Services
{
    public class StraightCalculatorUnitTests
    {
        [Fact]
        public void It_Should_Return_SumOfAllDice_When_GivenASmallStraight()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(5),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var smallStraightsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.SmallStraights, turn.Dice);

            //Assert
            Assert.Equal(15, smallStraightsCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfAllDice_When_GivenALargeStraight()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(5),
                new EchoDie(6),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var largeStraightsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.LargeStraights, turn.Dice);

            //Assert
            Assert.Equal(20, largeStraightsCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_Zero_When_NotGivenALargeStraight()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(5),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var largeStraightsCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.LargeStraights, turn.Dice);

            //Assert
            Assert.Equal(0, largeStraightsCalculator.Calculate());
        }
    }
}