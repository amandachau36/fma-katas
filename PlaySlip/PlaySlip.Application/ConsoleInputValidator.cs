using System;

namespace PlaySlip.Application
{
    public class ConsoleInputValidator : IInputValidator
    {
        // private readonly IDisplay _display;

        // public ConsoleInputValidator()
        // {
        //     _display = display;
        // }
        public bool isValid(InputTypes inputType, string input1)  
        {
            switch (inputType)
            {
                case InputTypes.Super:
                    return IsSuperValid(input1);
                case InputTypes.Name:
                    return IsNameValid(input1);
                case InputTypes.Date:
                    return IsDateValid(input1);
                case InputTypes.AnnualSalary:
                    return IsAnnualSalaryValid(input1);
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }

        private bool IsSuperValid(string input)
        {
                decimal superRate;
                var maxSuper = 50;
                var minSuper = 0;

                if (!Decimal.TryParse(input, out superRate)) return false;
                
                if (superRate > minSuper && superRate < maxSuper)
                    return true;
                return false; 
                
        }

        private bool IsNameValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        private bool IsDateValid(string input)
        {
            DateTime temp;
            return (DateTime.TryParse(input, out temp));

        }

        private bool IsAnnualSalaryValid(string input)
        {
            decimal annualSalary;
            if (!Decimal.TryParse(input, out annualSalary)) return false;

            if (annualSalary > 0)
                return true;
            return false;
            
        }
        
    }
}