using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Yatzy.Application
{
    public static class Constants
    {
        public const int MaximumNumberOfDice = 5;

        public const int MaximumNumberOfRolls = 3;
        
        public const int MinimumDiceValue = 1;
            
        public const int MaximumDiceValue = 6;
        
        public static readonly IList<int> SmallStraightValues = new ReadOnlyCollection<int>(  // this is an appropriate way to make a list a constant/immutatable 
            new List<int>
            {
                1, 2, 3, 4, 5
            });  
        
        public static readonly IList<int> LargeStraightValues = new ReadOnlyCollection<int>(
            new List<int>
            {
                2, 3, 4, 5, 6
             });
    }
}

// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-define-constants
// use static class with const fields. Sealed class is an alternative