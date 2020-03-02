using System;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            var romanNumeral = new RomanNumeral();

            Console.WriteLine(romanNumeral.ToRomanNumeral(3 ));
            
        }
    }
}