namespace TestDoubles
{
    public interface ILiveRate
    {
        string Name { get; set; }

        decimal GetRate();
    }
}