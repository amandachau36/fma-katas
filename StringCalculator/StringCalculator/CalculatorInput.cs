namespace Calculator
{
    public class CalculatorInput
    {
        public string[] Separators { get; }
        public string StringNumbers { get; }

        public CalculatorInput(string[] separators, string stringNumbers)
        {
            Separators = separators;
            StringNumbers = stringNumbers;
        }
        
    }
}