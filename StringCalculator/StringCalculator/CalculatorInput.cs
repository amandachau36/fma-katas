namespace Calculator
{
    public class CalculatorInput
    {
        public string[] Separators { get; }
        public string StringNumbers { get; }
        
        public int[] ProcessedNumbers { get; }

        public CalculatorInput(string[] separators, string stringNumbers, int[] processedNumbers)
        {
            Separators = separators;
            
            StringNumbers = stringNumbers;

            ProcessedNumbers = processedNumbers;
        }
        
    }
}