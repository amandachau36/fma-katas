using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class CalculatorInput
    {
        public string[] Separators { get; }
        public string StringNumbers { get; }
        public int[] ProcessedNumbers { get; }
        
        public int[] NegativeNumbers {
            get { return ProcessedNumbers.Where(num => num < 0).ToArray(); }
        }

        public string[] InvalidSeparators
        {
            get
            {
                return Separators.Where(separator =>
                    Regex.IsMatch(separator, @"^\d+") || Regex.IsMatch(separator, @"\d+$")).ToArray();
            }
        }

        public CalculatorInput(string[] separators, string stringNumbers, int[] processedNumbers)
        {
            Separators = separators;
            
            StringNumbers = stringNumbers;

            ProcessedNumbers = processedNumbers;
        }
        
    }
}