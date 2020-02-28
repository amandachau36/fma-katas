using System;

namespace PlaySlip.Application
{
    public class AnnualSalaryValidator : IValidator
    {
        public bool IsValid(string input)
        {
            decimal annualSalary;
            
            if (!Decimal.TryParse(input, out annualSalary)) return false;

            if (annualSalary > 0)
            {
                return true;
            }
            
            return false;
            
        }
    }
}