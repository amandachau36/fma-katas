using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class StringCalculator
    {
        public int Add(string stringNumbers )
        {
            var regex = new Regex(@"^//(.)\n");
            
            var match = regex.Match(stringNumbers);

            var separator = new string[] {"\n", ","};
            
            if (match.Success)
            {
                separator = new string[] {match.Groups[1].Value};
                stringNumbers = stringNumbers.Remove(0, 4);
            }
            
            var numbers = stringNumbers.Split(separator, StringSplitOptions.None);

            var totalSum = 0;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                totalSum += Convert.ToInt32(numbers[i]);
            }

            return totalSum;

            //return Convert.ToInt32(stringNumber);
            //return 0;
        }
    }
}
