using System;
using System.Collections.Generic;
using System.Linq;



namespace Blackjack
{
    public class Game
    {
        
        private bool IsUsersTurn { get; set; }
        
        private bool IsGameOver { get; set; }
        
        private int UserScore { get; set; }
        private int DealerScore { get; set; }

        private bool IsUserBust { get; set; }
        private bool IsTied { get; set; }
        
        private bool IsDealerWinner { get; set; }

        private bool IsUserWinner { get; set; } 
        

        public Game()   // is the constructor always public ? 
        {
            IsUsersTurn = true;
            IsGameOver = false;  // do I need to set these or default values
            UserScore = 0;
            DealerScore = 0;
            IsTied = false;
            IsDealerWinner = false;
            IsUserWinner = false;
            
        }

        private List<Tuple<string, string>> GenerateDeck() //
        {
            var numbers = new List<string>
                {"ACE", "2", "3", "4", "5", "6", "7", "8", "9", "10", "JACK", "QUEEN", "KING"};
            var suits = new List<string> {"CLUB", "DIAMOND", "HEARTS", "SPADE"};

            var deck = new List<Tuple<string, string>>();
            for (int i = 0; i < suits.Count; i++)
            {
                for (var j = 0; j < numbers.Count; j++)
                {
                    deck.Add(new Tuple<string, string>(numbers[j], suits[i]));
                }
            }
            return deck;

        }

        private List<Tuple<string, string>> Shuffle(List<Tuple<string, string>>  deck)
        {
            
            var shuffledDeck = new List<Tuple<string, string>>();
            var rand = new Random();
            int randomIndex; 
            
            while (deck.Count > 0)
            {
                randomIndex = rand.Next(0, deck.Count); // generate random index
                shuffledDeck.Add(deck[randomIndex]); 
                deck.RemoveAt(randomIndex); 
            }
            return shuffledDeck;
        }

        private List<Tuple<string, string>> Deal(int numOfCards, List<Tuple<string, string>>  shuffledDeck)
        {
            var cardsDealt = new List<Tuple<string, string>>();

            for (int i = 0; i < numOfCards; i++)
            {
                cardsDealt.Add(shuffledDeck[shuffledDeck.Count-1]);
                shuffledDeck.RemoveAt(shuffledDeck.Count - 1);

            }

            return cardsDealt;
            
        }


        private void AddCardToHand(List<Tuple<string, string>> cardsDealt,
            List<Tuple<string, string>> cardsInHand)
        {
            cardsInHand.AddRange(cardsDealt);

        }

        public int CalculateScore(List<Tuple<string, string>> currentHand)
        {
            var score = 0;
            foreach (var card in currentHand)
            {
                int num;
                var isNum = Int32.TryParse(card.Item1, out num);
                if (isNum)
                {
                    score += num;
                    continue; // skips code below
                }
                
                if (card.Item1 == "ACE")
                    score += 11;
                else 
                    score += 10; //jack, queen, king
                  
            }

            foreach (var card in currentHand)
            {
                if (score > 21 && card.Item1 == "ACE") // change value of ACE from 11 to 1 
                    score -= 10;
                
                if (score <= 21)  // ignore all subsequent aces and exit function
                    return score;
                
            }

            return score;

            // var handContainsAce = currentHand.Any(card => card.Item1 == "ACE"); // what about if it contains 2 ACEs? 
            //
            // if (score > 21 && handContainsAce)
            //     score -= 10;
            //
            // return score;
        }
        
        private string IsDealerGoingToHit(int score)
        {
            if (score >= 17)
                return "0";

            return "1";

        }
        
        private void UpdateScore(int currentScore)
        {
            if (IsUsersTurn)
                UserScore = currentScore;
            else
                DealerScore = currentScore;
        }
        
       
        private void GameStatus ()
        {
            if (UserScore > 21)
            {
                IsGameOver = true;
                IsUserBust = true;
                return;
            }

            if (DealerScore > 21 && UserScore <= 21 )
            {
                IsGameOver = true;
                IsUserWinner = true;
                return;
            }

            if (UserScore == DealerScore && UserScore != 0)
            {
                IsTied = true;
                IsGameOver = true;
                return;
            }


            if (IsGameOver && UserScore > DealerScore)
            {
                IsGameOver = true;
                IsUserWinner = true;
                
            }
            else if (IsGameOver && UserScore < DealerScore)
            {
                IsGameOver = true;
                IsDealerWinner = true;
            }
            
        }
        
        

        public void PlayBlackJack()
        {

            if (IsGameOver)
                return;
            
            var deck = Shuffle(GenerateDeck());
            var currentHand = Deal(2, deck);
            
            
            while (true)
            {

                var currentScore = CalculateScore(currentHand);
                
                UpdateScore(currentScore);
                
                GameStatus();

                if (IsDealerWinner || IsUserWinner || IsTied )
                    break;

                var displayScore = IsUserBust ? "Bust!" : currentScore.ToString();

                var displayTurn = IsUsersTurn ? "You are at currently" : "Dealer is";
                
                Console.WriteLine("\n" + displayTurn + " at " + displayScore);

                Console.WriteLine("with the hand [" + string.Join(", ", currentHand) + "]");

                if (IsUserBust)
                {
                    break;
                }
                
                
                Console.Write("\nHit or stay? (Hit = 1, Stay = 0): ");

                var hitOrStay = IsUsersTurn ? Console.ReadLine() : IsDealerGoingToHit(currentScore);

                if(!IsUsersTurn)
                    Console.WriteLine(hitOrStay);
                

                if (hitOrStay == "0")
                {


                    if (!IsUsersTurn)
                    {
                        IsGameOver = true;
                        GameStatus();
                    }
                        
                    
                    IsUsersTurn = false;
                    break;
                }
                    

                var dealAgain = Deal(1, deck);
                
                
                AddCardToHand(dealAgain, currentHand);

                
                

                displayTurn = IsUsersTurn ? "You draw" : "Dealer draws";
                
                Console.WriteLine(displayTurn + " " + String.Join(' ',dealAgain));
                
            }
            
            
            if(IsUserWinner)
                Console.WriteLine("You beat the dealer");
            else if (IsDealerWinner)
                Console.WriteLine("Dealer Wins");
            
            if(IsTied)
                Console.WriteLine("It's a tie!");
            

        }
    }
}





// public class TupleList<T1, T2> : List<Tuple<T1, T2>>
// {
//     public void Add( T1 item, T2 item2 )
//     {
//         Add( new Tuple<T1, T2>( item, item2 ) );
//     }
// }
    
// var tupleList = new TupleList<string, string>
// {
//     {"Ace", "Heart"},
//     {"1", "Spade"},
//     {"10", "CLUB"}
// };
//
// return tupleList;
