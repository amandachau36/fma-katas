
using System;
using System.Text;

namespace Exercise1
{
    public class Fizz
    {
        public string FizzBuzz(int number)
        {   
            var stringBuilder = new StringBuilder(); // should I not start with stringbuilder based on tests? 
            

            if (number % 3 == 0)
                stringBuilder.Append("Fizz");

            if (number % 5 == 0)
                stringBuilder.Append("Buzz");

            if (stringBuilder.Length == 0)
                stringBuilder.Append(number);
            
            return stringBuilder.ToString();
        }

        public void PrintFizzBuzz()
        {
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(FizzBuzz(i));  // do I need to test this? // How?
            }
        }
    }
}