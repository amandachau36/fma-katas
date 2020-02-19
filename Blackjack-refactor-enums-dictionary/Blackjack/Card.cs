using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Blackjack
{
    
    public enum Suit // this is automatically public even without the public modifer 
    {
        Club,
        Diamond,
        Heart,
        Spade
    }


    public enum Rank
    {
        Ace,  //  this is the convention for C#
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,  
        Queen,
        King 
    }

    
    public class Card
    {
        //private Rank _rank  is a backing field and scope is limited to block 

        public Rank Rank { get; private set; } // private set not necessary for the constructor but required if you create another method
        public Suit Suit { get;  }   // w/o getter and setter it's a field instead of a property and not accessible by 
        
        

        public Card(Rank rank, Suit suit) // constructor 
        {
            Rank = rank;  //does this need to be underscored
            Suit = suit;
        }

        // public Rank Something // properties   
        // {
        //     get { return _rank;  }
        //     set
        //     {
        //         if (value == Rank.Joker)
        //             _suit = Suit.Power;
        //         _rank = value;
        //     }  // value is a special parameter - visual basic .net syntax 
        //     
        // }
        
        
        public string ToOtherString()    // member method
        {
            return $"{this.Rank} of {this.Suit}";
        }
        
        
        public static List<string> ToListOfStrings(List<Card> cards)
        {
            var list = new List<string>();
            foreach (var card in cards)
            {
                // list.Add(Blahblah.ToFormattedString(card));
                list.Add(card.ToOtherString());
            }

            return list;
        }
        

    }
    
    
 
    
    
}


// public override string ToString()
// {
//     return $"{rank} of {suit}";
// }
//


// public class Blahblah
// {
//         
//     public static string ToFormattedString(Card card)
//     {
//             
//         return $"{card.Rank} of {card.Suit}";   
//     }
// }