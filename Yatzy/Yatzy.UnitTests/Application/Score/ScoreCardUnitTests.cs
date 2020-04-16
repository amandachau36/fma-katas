using System;
using System.Collections.Generic;

using Moq;
using Xunit;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Exceptions;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Models;
using Yatzy.UnitTests.Application.Score.Services;


namespace Yatzy.UnitTests.Application.Score
{
    public class ScoreCardUnitTests
    {
        [Fact]
        public void It_Should_ReturnScoreForPairs_When_PlacedOnPairs_And_PairsIsValid()
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
            //turn.RollDice();
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
            var mockDice = new Mock<IDie>();
            mockDice.Setup(x => x.Value).Returns(1);
            var fiveMockDice = new List<IDie>
            {
              mockDice.Object,
              mockDice.Object,
              mockDice.Object,
              mockDice.Object,
              mockDice.Object,
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();
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
            var mockDice = new Mock<IDie>();
            mockDice.Setup(x => x.Value).Returns(1);
            var fiveMockDice = new List<IDie>
            {
                mockDice.Object,
                mockDice.Object,
                mockDice.Object,
                mockDice.Object,
                mockDice.Object,
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();
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
            var mockDice = new Mock<IDie>();
            mockDice.Setup(x => x.Value).Returns(1);
            
            var fiveMockDice = new List<IDie>
            {
                mockDice.Object,
                mockDice.Object,
                mockDice.Object,
                mockDice.Object,
                mockDice.Object,
            };
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();
            
            var scoreCard = new ScoreCard();
            scoreCard.UpdateScoreCard(ScoreCategory.FourOfAKind, turn.Dice);

            mockDice.Setup(x => x.Value).Returns(2);
            //turn.RollDice();
            
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
            var mockDice = new Mock<IDie>();
            mockDice.Setup(x => x.Value).Returns(1);
            
            var fiveMockDice = new List<IDie>
            {
                mockDice.Object,
                mockDice.Object,
                mockDice.Object,
                mockDice.Object,
                mockDice.Object,
            };
            
            var turn = new Turn(fiveMockDice);
            //turn.RollDice();
            
            var scoreCard = new ScoreCard();
            scoreCard.UpdateScoreCard(ScoreCategory.FourOfAKind, turn.Dice); 
            
            mockDice.Setup(x => x.Value).Returns(2);
            //turn.RollDice();
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