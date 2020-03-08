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

            var result = stringCalculator.Add("//[**1][%]\n1*1*2%3");

            Console.WriteLine(result);
            
        }
    }
}


//TODO: refactor so that stringNumber does not need to be processed multiple times, calculatorInput should probably return this 
//TODO:  look for patterns in InputProcessor
//TODO: think about interfaces 
//TODO: another throw exception 
