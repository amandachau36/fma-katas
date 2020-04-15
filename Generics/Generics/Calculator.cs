

namespace Generics
{
    
    public class Calculator<T> //where T : IProperty //T is any symbol //constraint to IProperty
    { //strongly typed class that can handle different things
        public bool AreEqual(T object1, T object2)
        {
            return object1.Equals(object2);  
        }

        // public decimal Calculate()
        // {
        //     
        //     return 1m;
        // }
        //
        // private T data; //declare a variable of unknown type
        //
        // public T Value  // long notation of prop
        // {
        //     get
        //     {
        //         return this.data;
        //     }
        //     set
        //     {
        //         this.data = value; //value is a special keyword
        //     }
        // }
        //
        //private int dataInt;
        // public int Value2 
        // {
        //     get
        //     {
        //         return this.dataInt;
        //     }
        //     set
        //     {
        //         this.dataInt = value; 
        //     }
        // }
        //
        // public int Value3 { get; set; } //same as Value2
    }
}