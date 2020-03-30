using System;
using System.Collections.Concurrent;

namespace SingletonPattern
{
    public sealed class Logger  //cannot inherit 
    {

        private static Logger instance = null; 
        //private constructor
        //generally used in classes that contain static members only
        //this prevents automatic generation of a default constructor
        private Logger()
        {
            Console.WriteLine("instance created");
        }

        //public static property
        public static Logger GetInstance
        {
            get
            {
                if(instance == null)
                    instance = new Logger();
                return instance;
            }
        }

        public void LogMyDetails(string message)
        {
            Console.WriteLine("logging = " + message);
        }
        
    }
}



// 4 conditions are required to create the class in Singleton way.
// 1. private constructor (no parameter)
// 2. sealed (should not be inherited) -> multiple threads
// 3. private static variable to hold instance created
// 4. public static property for the client to request to create the instance