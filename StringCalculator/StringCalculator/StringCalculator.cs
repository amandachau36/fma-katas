using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class StringCalculator
    {
       
        public int Add(string stringNumbers )
        {
            
            var calculatorInput = InputProcessor(stringNumbers);

            var numbers = calculatorInput.ProcessedNumbers;

            var totalSum = 0;
        
            for (int i = 0; i < numbers.Count(); i++)
            {
                if (numbers[i] < 0)
                {
                    throw new NegativesNotAllowedException(calculatorInput);
                }

                if (numbers[i] < 1000)
                {
                    totalSum += numbers[i];
                }

            }

            return totalSum;
            
        }
        
        private CalculatorInput InputProcessor(string stringNumbers)
        {
            var regex1 = new Regex(@"^//(.*)\n");
            
            var match1 = regex1.Match(stringNumbers);

            var separators = new string[] {"\n", ","}; // default
            
            if (match1.Success)   // check for custom Delimiters 
            {
                var stringMatch1 = match1.Groups[1].Value;
                
                var regex2 = new Regex(@"\[(.*?)\]"); // ? required to make it non-greedy

                var match2 = regex2.Matches(stringMatch1);
                
                if (match2.Count > 0)
                {
                    var numberOfDelimiters = match2.Count;

                    separators = new string[numberOfDelimiters];

                    for (var i = 0; i < numberOfDelimiters; i++)
                    {
                        var currentSeparator = match2[i].Groups[1].Value;

                        if (Regex.IsMatch(currentSeparator, @"^\d+") || Regex.IsMatch(currentSeparator, @"\d+$"))
                        {
                            Console.WriteLine("Delimiter has a number on the edge, need to throw error");
                        }
                        
                        separators[i] = currentSeparator;
                    }
                }
                else   //deals with different but single characters delimiters 
                {
                    separators = new string[] {stringMatch1}; 
                    
                }
                
                stringNumbers = regex1.Replace(stringNumbers, "");  //if there are delimiters remove from the numbers
               
            } 
            
            var processedNumbers = stringNumbers.Split(separators, StringSplitOptions.None).Select(Int32.Parse).ToArray();
            
            // if match1 is not a success then use default separators  
            return new CalculatorInput(separators, stringNumbers, processedNumbers);
        }

    }
}
