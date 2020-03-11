using System;
using System.Threading;

namespace Watch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    var stopWatch = new Stopwatch(new RealDateTimeProvider());

                    Console.WriteLine("start" + i );
                    stopWatch.Start();
                    stopWatch.Start();
                    Thread.Sleep(2000);
                    Console.WriteLine(stopWatch.Stop());
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
          
        }
    }
}