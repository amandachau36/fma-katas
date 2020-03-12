using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class StringCalculator
    {
        private CalculatorInput _calculatorInput;
        
        public int Add(string stringNumbers )  //// option: return an object like Calculation result regardless of whether it's successful or not
        {
            InputProcessor(stringNumbers);

            var numbers = _calculatorInput.ProcessedNumbers;

            var totalSum = 0;
    
            for (int i = 0; i < numbers.Count(); i++)
            {
                if (numbers[i] < 1000)
                {
                    totalSum += numbers[i];
                }
            }

            return totalSum;
                                                    //TODO: throw is required otherwise, it complains that not all paths return a value
                                                    //However this is throwing it to main and crashes the system
                                                    //or should I make VOID and totalSum a property? ordd V throw another try block into Main
    }
        
        private void InputProcessor(string stringNumbers)
        {
            var regex1 = new Regex(@"^//(.*)\n");
            
            var match1 = regex1.Match(stringNumbers);  

            var separators = new string[] {"\n", ","};         // default
            
            if (match1.Success)                                // look for custom Delimiters 
            {
                
                stringNumbers = regex1.Replace(stringNumbers, "");  //if there are delimiters remove from the numbers
                
                var stringMatch1 = match1.Groups[1].Value;
                
                var regex2 = new Regex(@"\[(.*?)\]");   // ? is required to make it non-greedy

                var match2 = regex2.Matches(match1.Groups[1].Value);
                
                if (match2.Count > 0)                          //look to see if delimiters are in [] format 
                {
                    var numberOfDelimiters = match2.Count;

                    separators = new string[numberOfDelimiters];

                    for (var i = 0; i < numberOfDelimiters; i++)
                    {

                        separators[i] = match2[i].Groups[1].Value;
                    }
                }
                else                                           //deals with different but single characters delimiters 
                {
                    separators = new string[] {stringMatch1}; 
                    
                }

            }
            
            _calculatorInput = new CalculatorInput(separators, stringNumbers);  
            
            // validate separators before splitting 
            if(_calculatorInput.InvalidSeparators.Length > 0)
                throw new DelimiterCannotHaveNumberOnTheEdgeException(_calculatorInput);
            
            
            // if match1 is not a success then use default separators  
            var processedNumbers = stringNumbers.Split(separators, StringSplitOptions.None).Select(Int32.Parse).ToArray();
            
            _calculatorInput.SetProcessedNumbers(processedNumbers);
            
            if(_calculatorInput.NegativeNumbers.Length > 0)
                throw new NegativesNotAllowedException(_calculatorInput);
                
        }
        
    }
    
}

