using System;

namespace Generics
{
    public sealed class Display
    {
        public static void WriteToDisplay<T>(string message, T value) // can only handle .net values not custom 
        {
            Console.Write($"{message} {value}");
        }

        
        // Justin: I think it could - anything that supports .ToString() (which your custom types can override), or what can you do with the built-in types?
        //https://docs.microsoft.com/en-us/dotnet/api/system.iformattable?view=netframework-4.8

    }
}