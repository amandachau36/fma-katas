namespace TestDoubles
{
    public class GoogleLiveRate : ILiveRate
    {
        public string Name { get; set; }

        public decimal GetRate()
        {
            return 5.3m; //this goes out to an external system and fetches the live rate from google 
        }
    }
}