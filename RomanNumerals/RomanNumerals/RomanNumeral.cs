using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumerals
{
    public class RomanNumeral
    {
        public enum RomanSymbol
        { 
          I = 1,
          Iv = 4,
          V = 5,
          Ix = 9,
          X = 10,
          Xl = 40,
          L = 50,
          Xc = 90,
          C = 100,
          Cd = 400,
          D = 500,
          Cm = 900,
          M = 1000, 
        }

        private readonly List<RomanSymbol> _romanDictionary = new List<RomanSymbol>
        {
            RomanSymbol.M,
            RomanSymbol.Cm,
            RomanSymbol.D,
            RomanSymbol.Cd,
            RomanSymbol.C,
            RomanSymbol.Xc,
            RomanSymbol.L,
            RomanSymbol.Xl,
            RomanSymbol.X,
            RomanSymbol.Ix,
            RomanSymbol.V,
            RomanSymbol.Iv,
            RomanSymbol.I
        };
        
        
        
        public string ToRomanNumeral(int number)
        {
            var romanNumeral = new StringBuilder();
            
            var currentNumber = number;

            foreach (var romanSymbol in _romanDictionary)
            {
                while (currentNumber >=  (int) romanSymbol)
                {
                    romanNumeral.Append(romanSymbol);
                    currentNumber -= (int) romanSymbol;
                }
            }
            
            return romanNumeral.ToString().ToUpper();
        }

    }
}



//is this the best way to do things? List of Tuples or list of key/value pairs or no key/value pairs just use enums
//var dictionaryByDescendingOrder = _romanDictionary.OrderByDescending(x => x.Value);


// private Dictionary<RomanSymbol, int> _romanDictionary = new Dictionary<RomanSymbol, int>
// {
// {RomanSymbol.I, 1},
// {RomanSymbol.Iv, 4},
// {RomanSymbol.V, 5},
// {RomanSymbol.Ix, 9},
// {RomanSymbol.X, 10},
// {RomanSymbol.Xl, 40},
// {RomanSymbol.L, 50},
// {RomanSymbol.Xc, 90},
// {RomanSymbol.C, 100},
// {RomanSymbol.Cd, 400},
// {RomanSymbol.D, 500},
// {RomanSymbol.Cm, 900},
// {RomanSymbol.M, 1000}
// };


//| Symbol        | Value         |
// | ------------- |:-------------:|
// | I             | 1             |
// | V             | 5             |
// | X             | 10            |
// | L             | 50            |
// | C             | 100           |
// | D             | 500           |
// | M             | 1000          |