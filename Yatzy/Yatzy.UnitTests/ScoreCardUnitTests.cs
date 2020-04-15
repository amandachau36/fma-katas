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
            var testScoreCategories  =
                new Dictionary<ScoreCategory, int>
                {
                    {ScoreCategory.Yatzy, 50},
                    {ScoreCategory.FourOfAKind, 4},
                    {ScoreCategory.ThreeOfAKind, 6},
                    {ScoreCategory.Pairs, 4},
                    {ScoreCategory.TwoPairs, 0},
                    {ScoreCategory.Ones, 0},
                    {ScoreCategory.Twos, 10},
                    {ScoreCategory.Threes, 0},
                    {ScoreCategory.Fours, 0},
                    {ScoreCategory.Fives, 0},
                    {ScoreCategory.Sixes, 0},
                    {ScoreCategory.Chance, 10},
                    {ScoreCategory.LargeStraights, 0},
                    {ScoreCategory.SmallStraights, 0}, 
                    {ScoreCategory.FullHouse, 0},
                };

            foreach (var (key, value) in testScoreCategories )
            {
                Assert.Equal(value, scoreCard.ScoreCategories[key].Score);
            }
            
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
            scoreCard.UpdateScoreCard(ScoreCategory.Yatzy, turn.Dice); 
            
            //Act
            
            
            //Assert 
            var testScoreCategories  =
                new Dictionary<ScoreCategory, int>
                {
                    {ScoreCategory.Yatzy, 50},
                    {ScoreCategory.FourOfAKind, 4},
                    {ScoreCategory.ThreeOfAKind, 0},
                    {ScoreCategory.Pairs, 0},
                    {ScoreCategory.TwoPairs, 0},
                    {ScoreCategory.Ones, 0},
                    {ScoreCategory.Twos, 0},
                    {ScoreCategory.Threes, 0},
                    {ScoreCategory.Fours, 0},
                    {ScoreCategory.Fives, 0},
                    {ScoreCategory.Sixes, 0},
                    {ScoreCategory.Chance, 0},
                    {ScoreCategory.LargeStraights, 0},
                    {ScoreCategory.SmallStraights, 0}, 
                    {ScoreCategory.FullHouse, 0},
                };

            foreach (var (key, value) in testScoreCategories )
            {
                Assert.Equal(value, scoreCard.ScoreCategories[key].Score);
            }
            
        }
    }
}