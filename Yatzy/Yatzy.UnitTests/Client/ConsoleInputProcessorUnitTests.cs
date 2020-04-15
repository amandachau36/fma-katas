using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yatzy.Application.Score;
using Yatzy.Client.Exceptions;
using Yatzy.Client.InputProcessor;
using Yatzy.Client.InputValidators;

namespace Yatzy.UnitTests.Client
{
    public class ConsoleInputProcessorUnitTests
    {
        [Fact] 
        public void It_Should_ReturnCorrectDiceValuesToHold_When_GiveAValidString()
        {
            //arrange
            var consoleInputProcessor = new ConsoleInputProcessor();
            var input = "2, 6";
            
            //act
            var diceValuesToHold = consoleInputProcessor.ConvertToDiceValues(input, new DiceValuesToHoldValidator());
            
            //assert
            Assert.True(diceValuesToHold.SequenceEqual(new List<int>{2, 6}));
        }
        
        [Fact] 
        public void It_Should_Return_ZeroValuesToHold_When_GiveAnEmptyString()
        {
            //arrange
            var consoleInputProcessor = new ConsoleInputProcessor();
            var input = "";
            
            //act
            var diceValuesToHold = consoleInputProcessor.ConvertToDiceValues(input, new DiceValuesToHoldValidator());
            
            //assert
            Assert.Empty(diceValuesToHold);
        }
        
        [Fact] 
        public void It_Should_Throw_InvalidValueToHoldException_When_GiveAnInvalidString()
        {
            //arrange
            var consoleInputProcessor = new ConsoleInputProcessor();
            var input = "I win";
            
            //act
            Action actual = () => consoleInputProcessor.ConvertToDiceValues(input, new DiceValuesToHoldValidator());
            
            //assert
            var exception = Assert.Throws<InvalidValuesToHoldException>(actual);
            Assert.Equal("One or more invalid dice values: I win", exception.Message);
        }
        
        [Fact] 
        public void It_Should_Throw_InvalidValueToHoldException_When_GiveAnStringWithInvalidValue()
        {
            //arrange
            var consoleInputProcessor = new ConsoleInputProcessor();
            var input = "22";
            
            //act
            Action actual = () => consoleInputProcessor.ConvertToDiceValues(input, new DiceValuesToHoldValidator());
            
            //assert
            var exception = Assert.Throws<InvalidValuesToHoldException>(actual);
            Assert.Equal("One or more invalid dice values: 22", exception.Message);
        }
        
        [Fact] 
        public void It_Should_Throw_InvalidValueToHoldException_When_GiveAnStringWithValidAndInvalidValues()
        {
            //arrange
            var consoleInputProcessor = new ConsoleInputProcessor();
            var input = "2, 3, 4, 65";
            
            //act
            Action actual = () => consoleInputProcessor.ConvertToDiceValues(input, new DiceValuesToHoldValidator());
            
            //assert
            var exception = Assert.Throws<InvalidValuesToHoldException>(actual);
            Assert.Equal("One or more invalid dice values: 2, 3, 4, 65", exception.Message);
        }
        
        [Fact] 
        public void It_Should_ReturnAnEnum_When_GiveAValidString()
        {
            //arrange
            var consoleInputProcessor = new ConsoleInputProcessor();
            var input = "TwoPairs";
            
            //act
            var scoreCategory = consoleInputProcessor.ConvertToScoreCategory(input, new ScoreCategoryInputValidator());
            
            //assert
            Assert.Equal(ScoreCategory.TwoPairs, scoreCategory);
        }
        
        [Fact] 
        public void It_Should_Throw_InvalidScoreCategoryException_GiveAnInvalidString()
        {
            //arrange
            var consoleInputProcessor = new ConsoleInputProcessor();
            var input = "Monopoly";
            
            //act
            Action actual = () => consoleInputProcessor.ConvertToScoreCategory(input, new ScoreCategoryInputValidator());
            
            //assert
            var exception = Assert.Throws<InvalidScoreCategoryException>(actual);
            Assert.Equal("Monopoly is not a valid score category", exception.Message);
        }
    }
}