using System;

namespace InversionOfControl
{
    public class MyLogger : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging now . . . ." + message);
        }
    }

    public interface IMyLogger
    {
        void Log(string message);
    }
}