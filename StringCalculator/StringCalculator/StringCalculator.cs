using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class StringCalculator
    {
       
        public int Add(string stringNumbers )
        {
    
            
            //var regex1 = new Regex(@"^//(.)\n");
            
            //var regex2 = new Regex(@"^//\[(.*)\]\n");
            
           
            var calculatorInput = InputProcessor1(stringNumbers);


            var numbers = calculatorInput.StringNumbers.Split(calculatorInput.Separators, StringSplitOptions.None);
            
                
            var totalSum = 0;
        
            for (int i = 0; i < numbers.Count(); i++)
            {
                var currentNumber = Convert.ToInt32(numbers[i]);

                if (currentNumber < 0)
                {
                    throw new NegativesNotAllowedException(calculatorInput);
                }

                if (currentNumber < 1000)
                {
                    totalSum += currentNumber;
                }

            }

            return totalSum;

            
        }
        
        private CalculatorInput InputProcessor1(string stringNumbers)
        {
            var regex1 = new Regex(@"^//(.*)\n");
            
            var match1 = regex1.Match(stringNumbers);
            
            var separators = new string[] {"\n", ","}; // default
            
            if (match1.Success)   // check to see if there 
            {
                var stringMatch1 = match1.Groups[1].Value;
                
                var regex2 = new Regex(@"\[(.*)\]");

                var match2 = regex2.Match(stringMatch1);
                
                if (match2.Success)
                {
                    separators = new string[] {match2.Groups[1].Value}; // single delimiter
                    
                    stringNumbers = stringNumbers.Remove(0, 6 + separators[0].Length-1);
                
                }
                else   //deals with different but single characters delimiters 
                {
                    separators = new string[] {stringMatch1};  
                    stringNumbers = stringNumbers.Remove(0, 4);
                }
                
                
            } 
            
            // if match1 is not a success then use default separators  

            return new CalculatorInput(separators, stringNumbers);
        }
        
        
        // private CalculatorInput InputProcessor2(string stringNumbers)
        // {
        //     var regex = new Regex(@"^//\[(.*)\]\n");
        //     
        //     var match = regex.Match(stringNumbers);
        //
        //     var separators = new string[] {"\n", ","};
        //     
        //     if (match.Success)
        //     {
        //         separators = new string[] {match.Groups[1].Value};
        //         stringNumbers = stringNumbers.Remove(0, 6 + separators[0].Length-1);
        //         
        //     }
        //     
        //     return new CalculatorInput(separators, stringNumbers);
        //     
        // }
        
        private CalculatorInput InputProcessorDefault(string stringNumbers)
        {
            
            var separators = new string[] {"\n", ","};

            return new CalculatorInput(separators, stringNumbers);
            
        }
        
        
        
        // private bool IsNumberNegative() 
        
        
    }
}
