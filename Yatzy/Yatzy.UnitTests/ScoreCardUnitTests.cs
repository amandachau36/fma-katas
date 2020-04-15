using System;
using System.Collections.Generic;

using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Exceptions;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Models;


namespace Yatzy.UnitTests
{
    public class ScoreCardUnitTests
    {
        [Fact]
        public void It_Should_ReturnScoreForPairs_When_PlacedOnPairs_And_PairsIsValid()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller2 = new Mock<IRoller>();
            mockRoller2.Setup(x => x.Roll()).Returns(1);
            
            var mockRoller3 = new Mock<IRoller>();
            mockRoller3.Setup(x => x.Roll()).Returns(2);
            
            var mockRoller4 = new Mock<IRoller>();
            mockRoller4.Setup(x => x.Roll()).Returns(3);
            
            var mockRoller5 = new Mock<IRoller>();
            mockRoller5.Setup(x => x.Roll()).Returns(4);
            
            
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller1.Object),
                new Die(mockRoller2.Object),
                new Die(mockRoller3.Object),
                new Die(mockRoller4.Object),
                new Die(mockRoller5.Object)
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            var scoreCard = new ScoreCard();
            
            //Act
            scoreCard.UpdateScoreCard(ScoreCategory.Pairs, turn.Dice);  
        
            //Assert
            Assert.Equal(2, scoreCard.Total);
        }
        
        [Fact]
        public void It_Should_ThrowScoreCategoryAlreadyTakenException_When_PlacedOnYatzy_And_YatztyAlreadyHasAScore()
        {
            //Arrange
            var mockRoller1 = new Mock<IRoller>();
            mockRoller1.Setup(x => x.Roll()).Returns(1);

            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller1.Object),
                new Die(mockRoller1.Object),
                new Die(mockRoller1.Object),
                new Die(mockRoller1.Object),
                new Die(mockRoller1.Object)
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            var scoreCard = new ScoreCard();
            scoreCard.UpdateScoreCard(ScoreCategory.Yatzy, turn.Dice);  
            
            //Act
            Action actual = () => scoreCard.UpdateScoreCard(ScoreCategory.Yatzy, turn.Dice); 
        
            //Assert
            var exception = Assert.Throws<ScoreCategoryAlreadyTakenException>(actual);
            Assert.Equal("This score category is already take: Yatzy", exception.Message);
        } 
        
        [Fact]
        public void It_Should__ReturnTotalScore_When_PlacedOn_Yatzy_Then_Chance()
        {
            //Arrange
            var mockRoller = new Mock<IRoller>();
            mockRoller.Setup(x => x.Roll()).Returns(1);

            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller.Object),
                new Die(mockRoller.Object),
                new Die(mockRoller.Object),
                new Die(mockRoller.Object),
                new Die(mockRoller.Object)
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            var scoreCard = new ScoreCard();
            scoreCard.UpdateScoreCard(ScoreCategory.Yatzy, turn.Dice);  
            
            //Act
            scoreCard.UpdateScoreCard(ScoreCategory.Chance, turn.Dice); 
        
            //Assert
            Assert.Equal(55, scoreCard.Total);
        }

        [Fact]
        public void It_Should_ShowAllPossibleScoresForAvailableCategories_When_ScoreCardIsPreviewed()
        {
            //Arrange
            var mockRoller = new Mock<IRoller>();
            mockRoller.Setup(x => x.Roll()).Returns(1);
            
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller.Object),
                new Die(mockRoller.Object),
                new Die(mockRoller.Object),
                new Die(mockRoller.Object),
                new Die(mockRoller.Object)
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            
            var scoreCard = new ScoreCard();
            scoreCard.UpdateScoreCard(ScoreCategory.FourOfAKind, turn.Dice); 
            
            mockRoller.Setup(x => x.Roll()).Returns(2);
            turn.RollDice();
            
            //Act
            scoreCard.PreviewScoreCard(turn.Dice);
            
            //Assert
            Assert.Equal(50, scoreCard.ScoreCategories[ScoreCategory.Yatzy].Score);
            Assert.Equal(4, scoreCard.ScoreCategories[ScoreCategory.FourOfAKind].Score);
            Assert.Equal(6, scoreCard.ScoreCategories[ScoreCategory.ThreeOfAKind].Score);
            Assert.Equal(4, scoreCard.ScoreCategories[ScoreCategory.Pairs].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.TwoPairs].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Ones].Score);
            Assert.Equal(10, scoreCard.ScoreCategories[ScoreCategory.Twos].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Threes].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Fours].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Fives].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Sixes].Score);
            Assert.Equal(10, scoreCard.ScoreCategories[ScoreCategory.Chance].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.SmallStraights].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.LargeStraights].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.FullHouse].Score);
            
        }
        
        [Fact]
        public void It_Should_ClearPossibleScores_When_ScoreCardIsPreviewed_Then_Updated()
        {
            //Arrange
            var mockRoller = new Mock<IRoller>();
            mockRoller.Setup(x => x.Roll()).Returns(1);
            
            var fiveMockDice = new List<Die>
            {
                new Die(mockRoller.Object),
                new Die(mockRoller.Object),
                new Die(mockRoller.Object),
                new Die(mockRoller.Object),
                new Die(mockRoller.Object)
            };
            
            var turn = new Turn(fiveMockDice);
            turn.RollDice();
            
            var scoreCard = new ScoreCard();
            scoreCard.UpdateScoreCard(ScoreCategory.FourOfAKind, turn.Dice); 
            
            mockRoller.Setup(x => x.Roll()).Returns(2);
            turn.RollDice();
            scoreCard.PreviewScoreCard(turn.Dice);

            //Act
            scoreCard.UpdateScoreCard(ScoreCategory.Yatzy, turn.Dice); 
            
            //Assert 
            Assert.Equal(50, scoreCard.ScoreCategories[ScoreCategory.Yatzy].Score);
            Assert.Equal(4, scoreCard.ScoreCategories[ScoreCategory.FourOfAKind].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.ThreeOfAKind].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Pairs].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.TwoPairs].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Ones].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Twos].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Threes].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Fours].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Fives].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Sixes].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.Chance].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.SmallStraights].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.LargeStraights].Score);
            Assert.Equal(0, scoreCard.ScoreCategories[ScoreCategory.FullHouse].Score);

        }
    }
}