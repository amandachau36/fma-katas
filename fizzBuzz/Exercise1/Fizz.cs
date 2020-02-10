
using System;
using System.Text;

namespace Exercise1
{
    public class Fizz
    {
        public string FizzBuzz(int number)
        {
            if (number % 5 == 0 && number % 3 == 0) // refactored for readability (removed stringbuilder)
                return "FizzBuzz";
            
            if (number % 3 == 0)
                return "Fizz";

            if (number % 5 == 0)
                return "Buzz";

            return number.ToString();
    
        }

        public void PrintFizzBuzz()
        {
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(FizzBuzz(i));  // A side effect - should test but it's difficult
            }
        }
    }
}