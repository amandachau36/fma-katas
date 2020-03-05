using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringCalculator = new StringCalculator();

            // var result = stringCalculator.Add("1,\n");
            // Console.WriteLine(result);
            
            //"1,\n" ????
            //"1,2\n3"
            // var numbers = "-1,2\n3".Split(',', '\n');
            //
            // foreach (var n in numbers)
            // {
            //     Console.WriteLine("N" + n);
            // }
            //
            // var regex = new Regex(@"^//\[(.*)\]\n");
            //
            // var match = regex.Match("//[***]\n1***2***3");
            // {
            //     Console.WriteLine("Match value: " + match.Groups[1]);
            // }

            var a = stringCalculator.Add("1,2");
            //var c = stringCalculator.Add("//[***]\n1***2***3");

            // var newString = "//;\n1;2".Remove(0, 4);
            //
            // Console.WriteLine(newString);


            //var negativeNumbers = calculatorInput.StringNumbers.Split(',', '\n')Where(num => Convert.ToInt32(num) < 0).ToArray();
            // var filter = numbers.Where(num => Convert.ToInt32(num) < 0);
            // foreach (var f in filter)
            // {
            //     Console.WriteLine("F" + f);
            // }
            //
            // if (filter.Count > 0)
            // {
            //     throw new NegativesNotAllowedException(new CalculatorInput());
            // }
            //

            // var result = stringCalculator.Add("-1,2,-3");




        }
    }
}