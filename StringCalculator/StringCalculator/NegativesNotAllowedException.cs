using System;
using System.Linq;


namespace Calculator
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(CalculatorInput calculatorInput) : base(FormatMessage(calculatorInput))
        {
        }

        private static string FormatMessage(CalculatorInput calculatorInput)
        {
            return "Negatives not allowed: " + string.Join(", ", calculatorInput.NegativeNumbers);
        }
    }
}