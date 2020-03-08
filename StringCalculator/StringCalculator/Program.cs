using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var stringCalculator = new StringCalculator();
            
                var result = stringCalculator.Add("//[**1]\n1**12*3");
                
                Console.WriteLine(result);

            }
            catch (Exception e)
            {
                Console.WriteLine("Catch in main :" + e.Message);
                
            }
           
            
            
           
            
        }
    }
}


//TODO:  look for patterns in InputProcessor
//TODO: think about interfaces 

