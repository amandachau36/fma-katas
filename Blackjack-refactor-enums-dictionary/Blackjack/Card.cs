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
        public Rank rank;
        public Suit suit;


        public Card(Rank rank, Suit suit) // constructor 
        {
            this.rank = rank;  //does this need to be underscored
            this.suit = suit;
        }
        
        public override string ToString()
        {
            return $"{rank} of {suit}";
        }
        
        
        

    }
}