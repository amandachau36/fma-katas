using System;


namespace Calculator
{
    public class DelimiterCannotHaveNumberOnTheEdgeException : Exception
    {
        public DelimiterCannotHaveNumberOnTheEdgeException(CalculatorInput calculatorInput) : base(FormatMessage(calculatorInput))
        {
        }

        private static string FormatMessage(CalculatorInput calculatorInput)
        {
            return "Delimiter cannot have a number on the edge: " + string.Join(", ", calculatorInput.InvalidSeparators);
        }
    }
    
      
}