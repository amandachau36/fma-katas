using System.Collections.Generic;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Services.CategoryCalculator;
using Yatzy.Application.Score.Models;

namespace Yatzy.UnitTests.Application.Score.Services
{
    internal class EchoDie : IDie
    {
        public int Value { get; }
        public bool IsHeld { get; private set; }

        public EchoDie(int staticResult)
        {
            Value = staticResult;
        }

        public void Roll()
        {
        }

        public void UpdateIsHeld(bool isHeld)
        {
            IsHeld = isHeld;
        }
    }
    public class ChanceCalculatorUnitTests 
    {
        [Fact]
        public void It_Should_ReturnSumOfAllDice_When_GivenFiveDice()
        {
            //Arrange
            var fiveMockDice = new List<IDie>
            {
                new EchoDie(1),
                new EchoDie(1),
                new EchoDie(3),
                new EchoDie(3),
                new EchoDie(6),
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();

            //Act
            var calculateChance = CategoryCalculatorFactory.CreateCalculator(ScoreCategory.Chance, turn.Dice);

            //Assert
            Assert.Equal(14, calculateChance.Calculate());

        }
        
    }
}

//Is it okay that the tests for calculators are in separate classes even though the calculators are all in the same class? yes different scenarios 