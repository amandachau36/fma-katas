using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Blackjack.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateScore_HandIsAceAceTwoKing_Returns14()
        {
            var game = new Game();

            var hand = new List<Tuple<string, string>>();
            hand.Add(new Tuple<string, string>("2", "HEART"));  // 14, 24, 34 
            hand.Add(new Tuple<string, string>("KING", "HEART"));
            hand.Add(new Tuple<string, string>("ACE", "HEART"));
            hand.Add(new Tuple<string, string>("ACE", "SPADE"));
            
            var result = game.CalculateScore(hand);
            
            Assert.AreEqual(14, result );
            

        }
        
        [Test]
        public void CalculateScore_HandIsAceAceAce_Returns14()
        {
            var game = new Game();

            var hand = new List<Tuple<string, string>>();
            hand.Add(new Tuple<string, string>("ACE", "DIAMOND")); //3, 13, 23, 33
            hand.Add(new Tuple<string, string>("ACE", "HEART")); 
            hand.Add(new Tuple<string, string>("ACE", "SPADE"));
            
            var result = game.CalculateScore(hand);
            
            Assert.AreEqual(13, result );
            

        }
    }
}