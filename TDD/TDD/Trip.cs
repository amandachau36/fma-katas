namespace TDD
{
    public class Trip
    {
        public Tap TapOn { get; }
        public Tap TapOff { get; }
        public decimal Fare { get; }

        public Trip(Tap tapOn, Tap tapOff, decimal fare)
        {
            TapOn = tapOn;
            TapOff = tapOff;
            Fare = fare;
        }
    }
}