using System;
using System.Collections.Generic;

namespace AddingArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var newArray = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            Console.WriteLine(string.Join(", ", newArray));

            var result = new HashSet<int>(newArray);
            
            Console.WriteLine(string.Join(", ", result));

            var newArray2 = Add.Arr(newArray, newArray);
            
            Console.WriteLine(string.Join(", ", newArray2));
            

        }
    }
}