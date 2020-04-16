using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;
using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests.Application.Score.Services
{
    public class OnesTwosThreesCalculatorUnitTests
    {
        [Fact]
        public void It_Should_Return_SumOfSixes_When_PlacedOnSix_And_GivenSix()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(6),
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(4),
                new EchoDie(4),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var sixesCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Sixes, turn.Dice);

            //Assert
            Assert.Equal(6, sixesCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfFives_When_PlacedOnFive_And_GivenFives()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(6),
                new EchoDie(5),
                new EchoDie(2),
                new EchoDie(5),
                new EchoDie(5),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var fivesCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Fives, turn.Dice);

            //Assert
            Assert.Equal(15, fivesCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfFours_When_PlacedOnFours_And_GivenFours()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(1),
                new EchoDie(2),
                new EchoDie(4),
                new EchoDie(4),
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            
            
            //Act
            var foursCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Fours, turn.Dice);

            //Assert
            Assert.Equal(8, foursCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfThrees_When_PlacedOnThrees_And_GivenThrees()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(3),
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var threesCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Threes, turn.Dice);

            //Assert
            Assert.Equal(12, threesCalculator.Calculate());
        }

        
        [Fact]
        public void It_Should_Return_SumOfTwos_When_PlacedOnTwos_And_GivenTwos()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(2),
                new EchoDie(3),
                new EchoDie(2),
                new EchoDie(5),
                new EchoDie(1),
            };
     
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var twosCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Twos, turn.Dice);

            //Assert
            Assert.Equal(4, twosCalculator.Calculate());
        }
        
        [Fact]
        public void It_Should_Return_SumOfZero_When_PlacedOnOnes_NotGivenOnes()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(4),
                new EchoDie(4),
                new EchoDie(5),
            };
         
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();

            //Act
            var onesCalculator = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Ones, turn.Dice);

            //Assert
            Assert.Equal(0, onesCalculator.Calculate());
        }
    }
}