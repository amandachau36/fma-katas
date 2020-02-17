namespace Blackjack
{
    
    public enum Suit // this is automatically public even without the public modifer 
    {
        CLUB,
        DIAMOND,
        HEARTS,
        SPADE
    }


    public enum Rank
    {
        ACE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,  
        QUEEN,
        KING 
    }

    
    public class Card
    {
        public Rank rank;
        public Suit suit;


        public Card(Rank _rank, Suit _suit)
        {
            rank = _rank;  //does this need to be underscored
            suit = _suit;
        }
        

    }
}