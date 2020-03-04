using System;
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
            var numbers = "1,2\n3".Split(',', '\n');

            foreach (var n in numbers)
            {
                Console.WriteLine("N" + n);
            }
            
            var regex = new Regex(@"^//(.)\n");
            
            var match = regex.Match("//;\n1;2");

            if (match.Success)
            {
                Console.WriteLine("Match value: " + match.Groups[1]);
            }




            var newString = "//;\n1;2".Remove(0, 4);
            Console.WriteLine(newString);


        }
    }
}