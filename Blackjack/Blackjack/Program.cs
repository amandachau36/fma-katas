﻿using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.PlayBlackJack();
            game.PlayBlackJack();

        }
    }
}


// We are going to build a text based Blackjack engine that allows us to play against a dealer who follows conventional house rules.
//
// Our blackjack engine has several simplifications compared to a commercial Blackjack platform, namely:
//
// It will be entirely text based.
// It will have just a single player and the dealer.
// It will have no gambling system.
// The object of blackjack is for the player to make the sum of their card values as close to 21, without going over. If the player makes 21 exactly, they have blackjack, which can't be beat. If they go over 21 they are 'bust' and lose the round. Once the player has finalised the sum of their cards the dealer then tries to beat the players sum.
//
// The rules of blackjack are as follows:
//
// The player and the dealer receive two cards from a shuffled deck. In our case, we'll use a single deck, though casinos usually use a 'shoe' consisting of six decks.
//
// After the first two cards are dealt to the dealer and player, the player is asked if they'd like another card (called 'hitting'), or if they are happy with the cards they have already (called 'staying'). The player is allowed to stop hitting at any point.
//
// The number cards (2 through 10) are worth the number displayed, face cards are worth 10, and an Ace can be worth either 1 or 11. For example, if our first two cards are a Jack and an Ace, we'd want to count the Ace as 11 since 10 + 11 = 21 and we'd have blackjack, but, if we had already had a hand worth 18, decided to hit, and got an Ace, we'd want to count it as 1, since counting it as 11 would put us at 29 and we'd bust.
//
// Once the players hand is finished, the dealer tries to do the same. The dealer must keep hitting until they get to 17. If they get above 17 without busting, they can stay.
//
// Scoring
// The game is scored by simple rules
//
// If the player has blackjack, they win, unless the dealer also has blackjack, in which case the game is a tie.
// If the dealer busts and the player doesn't, the player wins.
// // If the player busts, the dealer wins.


//Tuple<>
//simple data structure
//contains n elements
// already exists 
// has many variations ready to use
// are immutable


// var b = new Tuple<int, string, List<double>>(1234, "hello", new List<double>(){ 3.14, 6.28});
//
// Console.WriteLine(b.Item2);


// var game = new Game();
// var deck = game.GenerateDeck();
//
// var shuffledDeck = game.Shuffle(deck);
//             
// foreach (var card in shuffledDeck)
// {
// Console.WriteLine(card.Item1 + " "  + card.Item2);
//                 
// }
// Console.WriteLine("num of cards" + shuffledDeck.Count);
//             
//
// var cardsDealt = game.Deal(2, shuffledDeck);
//
// Console.WriteLine("Cards dealt:");
// foreach (var card in cardsDealt)
// {
// Console.WriteLine(card.Item1 + " "  + card.Item2);
//                 
// }
//
// Console.WriteLine("num of cards" + shuffledDeck.Count);
//
//             
// var cardsDealt2 = game.Deal(1, shuffledDeck);
//
// var newHand = game.AddCardToHand(cardsDealt, cardsDealt2);
// // why is cardsDealt/CardsInHand unchanged 
// // shouldn't it be changed because it's a reference type
//             
// Console.WriteLine("There should be 3 cards beloww .. ");
//
// foreach (var card in newHand)
//            
// {
// Console.WriteLine(card.Item1 + " "  + card.Item2);
//}
