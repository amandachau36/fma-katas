using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class ConsoleBlackjackDisplay : IDisplay
    {
   

     
        public void DisplayHitOrStayPrompt()
        {
            Console.Write("\nHit or stay? (Hit = 1, Stay = 0): ");
        }

        public void DisplayInputErrorMessage()
        {
            Console.WriteLine("We don't understand you, try again!");
        }


        public void DisplayTurn(bool isUserTurn)
        {
            var displayTurn = isUserTurn ? "\nYou are at currently at " : "\nDealer is at ";
            Console.Write(displayTurn);
        }

        public void DisplayScore(bool isUserBust, int currentScore)
        {
            var displayScore = isUserBust ? "Bust!" : currentScore.ToString();
            Console.WriteLine(displayScore);
        }
        

        public void DisplayHand(List<Card> currentHand)
        {
            Console.WriteLine("with the hand [" + string.Join(", ", Card.ToListOfStrings(currentHand)) + "]");
        }

        public void DisplayWhoDraws(bool isUserTurn)
        {
            var displayTurn = isUserTurn ? "You draw " : "Dealer draws ";

            Console.Write(displayTurn);
        }

        public void DisplayCardsDrawn(List<Card> cards)
        {
            Console.WriteLine(String.Join(' ', Card.ToListOfStrings(cards)));
        }

    

        public void DisplayUserWins()
        {
            Console.WriteLine("You beat the dealer");
        }

        public void DisplayDealerWins()
        {
            Console.WriteLine("Dealer Wins");
        }

        public void DisplayTie()
        {
            Console.WriteLine("It's a tie!");
        }
    }
}