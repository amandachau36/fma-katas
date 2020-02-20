using System;
using System.Collections.Generic;

namespace Blackjack
{
    public interface IDisplay
    {


        void DisplayHitOrStayPrompt();

        void DisplayInputErrorMessage();
        void DisplayTurn(bool isUserTurn);

        void DisplayScore(bool isUserBust, int currentScore);

        
        void DisplayHand(List<Card> currentHand);

        public void DisplayCardsDrawn(List<Card> cards);

        public void DisplayWhoDraws(bool isUserTurn);
        

        void DisplayUserWins();

        void DisplayDealerWins();

        void DisplayTie(); 


    }
}