using System;
using System.Collections.Generic;
using System.Linq;



namespace Blackjack
{
    public class Game
    {
        
        private bool IsUsersTurn { get; set; }   // should this be underscored? 
        
        private bool IsGameOver { get; set; }
        
        private int UserScore { get; set; }
        private int DealerScore { get; set; }

        private bool IsUserBust { get; set; }
        private bool IsTied { get; set; }
        
        private bool IsDealerWinner { get; set; }

        private bool IsUserWinner { get; set; }

        private const int WinningScore = 21;

        public enum NextMove
        {
               Stay = 0,
               Hit = 1
        }
        
        public Dictionary<Rank, int> ConvertPoints = new Dictionary<Rank, int>
        {
            {Rank.Ace, 11},
            {Rank.Two, 2},
            {Rank.Three, 3},
            {Rank.Four, 4},
            {Rank.Five, 5},
            {Rank.Six, 6},
            {Rank.Seven, 7},
            {Rank.Eight, 8},
            {Rank.Nine, 9},
            {Rank.Ten, 10},
            {Rank.Jack, 10},
            {Rank.Queen, 10},
            {Rank.King, 10}
            
        };


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
        
        
        public List<Card> GenerateDeck() 
        {
    
            var deck = new List<Card>();

            var suits = Enum.GetValues(typeof(Suit));
            var ranks = Enum.GetValues(typeof(Rank));


            foreach (Suit suit in suits) // cannot use var here because it defaults to an object
            {
                foreach (Rank rank in ranks)
                {
                    deck.Add(new Card(rank, suit));
                }
                
            }
            
            return deck;
        
        }

        public List<Card> Shuffle(List<Card>  deck)
        {
            
            var shuffledDeck = new List<Card>(); // consider NOT creating a new list and returning original deck BUT shuffled 
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

        public List<Card> Deal(int numOfCards, List<Card>  shuffledDeck)
        {
            var cardsDealt = new List<Card>();

            for (int i = 0; i < numOfCards; i++)
            {
                cardsDealt.Add(shuffledDeck[shuffledDeck.Count-1]);
                shuffledDeck.RemoveAt(shuffledDeck.Count - 1);

            }

            return cardsDealt;
            
        }
        
        // consider makingCardsInHand a property 


        public void AddCardToHand(List<Card> cardsDealt,
            List<Card> cardsInHand)
        {
            cardsInHand.AddRange(cardsDealt);

        }

        public int CalculateScore(List<Card> currentHand)
        {
            var score = 0;
            foreach (var card in currentHand)
            {
                score += ConvertPoints[card.rank];
                
            }
            
            foreach (var card in currentHand)
            {
                if (score > WinningScore && card.rank == Rank.Ace) // change value of ACE from 11 to 1 
                     score -= 10;
                 
                if (score <= WinningScore)  // ignore all subsequent aces and exit function
                     return score;   
            }

            return score;

        }
        public NextMove DealersNextMove(int score)
        {
            return (score < 17) ? NextMove.Hit : NextMove.Stay;
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
            if (UserScore > WinningScore)
            {
                IsGameOver = true;
                IsUserBust = true;
                return;
            }

            if (DealerScore > WinningScore && UserScore <= WinningScore )
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
        
                var hitOrStay = IsUsersTurn ? (NextMove)Int32.Parse(Console.ReadLine()) : DealersNextMove(currentScore);
        
                if(!IsUsersTurn)
                    Console.WriteLine((int)hitOrStay);
                
        
                if (hitOrStay == NextMove.Stay)
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


// var handContainsAce = currentHand.Any(card => card.Item1 == "ACE"); // what about if it contains 2 ACEs? 
//
// if (score > 21 && handContainsAce)
//     score -= 10;
//
// return score;


// private string IsDealerGoingToHit(int score)
// {
//     if (score >= 17)
//         return "0";
//
//     return "1";
//
// }