namespace Yatzy.Application.Score
{
    public class ScoreRecordForEachCategory
    {
        
        public int Score { get; private set; }

        public bool IsAvailable  { get; private set; }

        public ScoreRecordForEachCategory()
        {
            Score = 0;
            IsAvailable = true;
        }

        public void UpdateCategory(int score, bool isAvailable)
        {
            Score = score;
            IsAvailable = isAvailable;
        }
    }
}