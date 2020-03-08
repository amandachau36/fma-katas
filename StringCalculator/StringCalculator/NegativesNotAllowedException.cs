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
            var negativeNumbers = calculatorInput.ProcessedNumbers.Where(num => num < 0).ToArray();
            return "Negatives not allowed: " + string.Join(", ", negativeNumbers);
        }
    }
}