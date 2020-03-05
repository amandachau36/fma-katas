using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class StringCalculator
    {
       
        public int Add(string stringNumbers )
        {
            var calculatorInput = InputProcessor(stringNumbers);

            var numbers = calculatorInput.StringNumbers.Split(calculatorInput.Separators, StringSplitOptions.None);
            
   
            var totalSum = 0;
        
            for (int i = 0; i < numbers.Count(); i++)
            {
                var currentNumber = Convert.ToInt32(numbers[i]);

                if (currentNumber < 0)
                {
                    throw new NegativesNotAllowedException(calculatorInput);
                }
                
                totalSum += currentNumber;
            }

            return totalSum;

            
        }

        private CalculatorInput InputProcessor(string stringNumbers)
        {
            var regex = new Regex(@"^//(.)\n");
            
            var match = regex.Match(stringNumbers);

            var separators = new string[] {"\n", ","};
            
            if (match.Success)
            {
                separators = new string[] {match.Groups[1].Value};
                stringNumbers = stringNumbers.Remove(0, 4);
                
            }
            
            return new CalculatorInput(separators, stringNumbers);
            
        }
        
        // private bool IsNumberNegative() 
        
        
    }
}
