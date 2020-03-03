namespace PlaySlip.Application
{
    public sealed class CurrencyHelper
    {
        public static decimal ToRoundedDollar(decimal amount)
        {
            return decimal.Round(amount); 
        }
    }
}