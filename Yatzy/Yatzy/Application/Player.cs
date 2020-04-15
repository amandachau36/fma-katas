using Yatzy.Application.Score;
using Yatzy.Application.Score.Models;

namespace Yatzy.Application
{
    public class Player
    {
        
        public Turn Turn { get;  }

        public ScoreCard ScoreCard { get; }

        public Player(Turn turn, ScoreCard scoreCard)
        {
            Turn = turn;
            ScoreCard = scoreCard;
        }
        
    }
}