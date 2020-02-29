using System;

namespace PlaySlip.Application
{
    public class SuperValidator : IValidator
    {
        
        public bool IsValid(params string[] input)
        {
            decimal superRate;
            var maxSuper = 50;
            var minSuper = 0;

            if (!Decimal.TryParse(input[0], out superRate)) return false;

            if (superRate > minSuper && superRate < maxSuper) return true;
            
            return false;
        }
    }
}