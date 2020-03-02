using System;
using System.Collections.Generic;

namespace PlaySlip.Application
{
    public class AnnualSalaryValidator : IValidator
    {
        public bool IsValid(List<string> input)
        {
            decimal annualSalary;

            if (!Decimal.TryParse(input[0], out annualSalary)) return false;

            if (annualSalary > 0)
            {
                return true;
            }

            return false;
        }
    }
}