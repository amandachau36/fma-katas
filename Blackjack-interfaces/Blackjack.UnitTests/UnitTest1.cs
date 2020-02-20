using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Blackjack.UnitTests
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        // write tests for card class 
        // write tests for generate deck 
        // rewrite unit cl

        
        
        [Test]
        public void GenerateDeck_ByDefault_Returns52Cards()
        {
            var consoleBlackjackDisplay = new ConsoleBlackjackDisplay();
            var consoleBlackjackInput = new ConsoleBlackjackInput(); 
            var game = new Game(consoleBlackjackDisplay, consoleBlackjackInput);

            var deck = game.GenerateDeck();

            var result = deck.Count;
            
            Assert.AreEqual(52, result );
        }
        
        [Test]
        public void GenerateDeck_ByDefault_ReturnsAceOfClubAsFirstCard()
        {
            var consoleBlackjackDisplay = new ConsoleBlackjackDisplay();
            var consoleBlackjackInput = new ConsoleBlackjackInput(); 
            var game = new Game(consoleBlackjackDisplay, consoleBlackjackInput);

            var deck = game.GenerateDeck();

            var result = deck[0].ToOtherString();
            
            Assert.AreEqual("Ace of Club", result );
        }
        



        [Test]
        public void CalculateScore_HandIsAceAceTwoKing_Returns14()
        {
            var consoleBlackjackDisplay = new ConsoleBlackjackDisplay();
            var consoleBlackjackInput = new ConsoleBlackjackInput(); 
            var game = new Game(consoleBlackjackDisplay, consoleBlackjackInput);

            var hand = new List<Card>();
            hand.Add(new Card(Rank.Two, Suit.Club));  // 14, 24, 34 
            hand.Add(new Card(Rank.King, Suit.Diamond ));
            hand.Add(new Card(Rank.Ace, Suit.Club));
            hand.Add(new Card(Rank.Ace, Suit.Heart));
            
            var result = game.CalculateScore(hand);
            
            Assert.AreEqual(14, result );
        }
        
        
        
        [Test]
        public void CalculateScore_HandIsAceAceAce_Returns13()
        {
            var consoleBlackjackDisplay = new ConsoleBlackjackDisplay();
            var consoleBlackjackInput = new ConsoleBlackjackInput(); 
            var game = new Game(consoleBlackjackDisplay, consoleBlackjackInput);
            
            var hand = new List<Card>();
            hand.Add(new Card(Rank.Ace, Suit.Diamond)); //3, 13, 23, 33
            hand.Add(new Card(Rank.Ace, Suit.Club));
            hand.Add(new Card(Rank.Ace, Suit.Heart));
        
        
            
            var result = game.CalculateScore(hand);
            
            Assert.AreEqual(13, result );
        
        }
        
        [Test]
        public void CalculateScore_HandIsAceKing_Returns21()
        {
            var consoleBlackjackDisplay = new ConsoleBlackjackDisplay();
            var consoleBlackjackInput = new ConsoleBlackjackInput(); 
            var game = new Game(consoleBlackjackDisplay, consoleBlackjackInput);
            
            var hand = new List<Card>();
            hand.Add(new Card(Rank.King, Suit.Diamond)); // 11, 21 
            hand.Add(new Card(Rank.Ace, Suit.Club));

            var result = game.CalculateScore(hand);
            
            Assert.AreEqual(21, result );
        
        }
        
        
    }
}