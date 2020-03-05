using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //var stringCalculator = new StringCalculator();


            // var stringNumbers = "//[*][%]\n1*2%3";
            //
            // var regex1 = new Regex(@"^//(.*)\n");
            //
            // var match1 = regex1.Match(stringNumbers);
            //
            // var stringMatch1 = match1.Groups[1].Value;
            //
            // Console.WriteLine(stringMatch1);
            
            // var a = stringCalculator.Add(stringNumbers);
            //
            // var regex1 = new Regex(@"^//(.*)\n");
            //
            // stringNumbers = regex1.Replace(stringNumbers, "");
            //
            // Console.WriteLine(stringNumbers);

            // var a = "[*][%]";
            //
            // var regex2 = new Regex(@"\[(.*?)\]");
            //
            // var matches = regex2.Matches(a);
            //
            //
            // foreach (Match match in matches)
            // {
            //     Console.WriteLine(match.Groups[1].Value);
            // }
            //
            // Console.WriteLine(matches.Count);
            
            
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("//[***]\n1***2***3");








        }
    }
}


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
