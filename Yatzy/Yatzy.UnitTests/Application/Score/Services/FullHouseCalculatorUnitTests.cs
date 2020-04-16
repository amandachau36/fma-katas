using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;
using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests.Application.Score.Services
{
    public class FullHouseCalculatorUnitTests
    {
        [Fact]
        public void It_Should_Return_SumOfAllDice_When_GivenFullHouse()
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
            var fullHouseCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.FullHouse, turn.Dice);

            //Assert
            Assert.Equal(8, fullHouseCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_Zero_When_GivenTwoPairs()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(2),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(4),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();
        
            
            //Act
            var fullHouseCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.FullHouse, turn.Dice);

            //Assert
            Assert.Equal(0, fullHouseCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_Zero_When_GivenFiveOfAKind()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(4),
                new EchoDie(4),
                new EchoDie(4),
                new EchoDie(4),
                new EchoDie(4),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            
            //Act
            var fullHouseCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.FullHouse, turn.Dice);

            //Assert
            Assert.Equal(0, fullHouseCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_Zero_When_GivenFourOfAKind()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(4),
                new EchoDie(4),
                new EchoDie(4),
                new EchoDie(4),
                new EchoDie(1),
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();

            //Act
            var fullHouseCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.FullHouse, turn.Dice);

            //Assert
            Assert.Equal(0, fullHouseCalculator.Calculate());
        }
        
    }
}