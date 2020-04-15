using System;

namespace Generics
{
    public sealed class Display
    {
        public static void WriteToDisplay<T>(string message, T value) // can only handle .net values not custom 
        {
            Console.Write($"{message} {value}");
        }
    }
}