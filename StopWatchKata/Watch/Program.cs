using System;

namespace Watch
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch(new RealDateTimeProvider());

            Console.WriteLine("start");
            stopWatch.Start();
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(stopWatch.Stop());
            
            
            Console.WriteLine("start2");
            stopWatch.Start();
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine(stopWatch.Stop());
        }
    }
}