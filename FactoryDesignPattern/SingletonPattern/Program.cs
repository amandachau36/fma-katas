using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = Logger.GetInstance;
            logger.LogMyDetails("james on Logger");
            
            var logger2 = Logger.GetInstance;
            logger2.LogMyDetails("james on Logger2");
        }
    }
}