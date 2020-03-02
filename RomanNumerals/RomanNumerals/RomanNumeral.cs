

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace RomanNumerals
{
    public class RomanNumeral
    {
        private enum RomanSymbol
        { 
          I,
          Iv,
          V,
          Ix,
          X,
          Xl,
          L,
          Xc,
          C,
          Cd,
          D,
          Cm,
          M, 
        }

        private Dictionary<RomanSymbol, int> convertDictionary = new Dictionary<RomanSymbol, int>
        {
            {RomanSymbol.I, 1},
            {RomanSymbol.Iv, 4},
            {RomanSymbol.V, 5},
            {RomanSymbol.Ix, 9},
            {RomanSymbol.X, 10},
            {RomanSymbol.Xl, 40},
            {RomanSymbol.L, 50},
            {RomanSymbol.Xc, 90},
            {RomanSymbol.C, 100},
            {RomanSymbol.Cd, 400},
            {RomanSymbol.D, 500},
            {RomanSymbol.Cm, 900},
            {RomanSymbol.M, 1000}
        };

        public string ToRomanNumeral(int number)
        {
            var romanNumeral = new StringBuilder();
            
            var currentNumber = number;

            //is this the best way to do things? 
            var dictionaryByDescendingOrder = convertDictionary.OrderByDescending(x => x.Value);
            
            foreach (KeyValuePair<RomanSymbol, int> entry in dictionaryByDescendingOrder)  
            {
                while (currentNumber >=  entry.Value)
                {
                    romanNumeral.Append(entry.Key);
                    currentNumber -= entry.Value;
                }
            }
            
            return romanNumeral.ToString().ToUpper();
        }

    }
}


//| Symbol        | Value         |
// | ------------- |:-------------:|
// | I             | 1             |
// | V             | 5             |
// | X             | 10            |
// | L             | 50            |
// | C             | 100           |
// | D             | 500           |
// | M             | 1000          |