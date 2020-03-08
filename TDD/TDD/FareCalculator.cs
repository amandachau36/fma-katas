namespace TDD
{
    public class FareCalculator
    {
        public decimal CalculateFare(Tap tapOn) // overloading
        {
            return CalculateFare();
        }

        private decimal CalculateFare()
        {
            return 3;
        }
    }
}