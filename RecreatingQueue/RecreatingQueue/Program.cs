using System;

namespace RecreatingQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var monthQueue = new QueueList();
            Console.WriteLine(monthQueue.Count());
            
            monthQueue.Enqueue("Jan");
            monthQueue.Enqueue("Feb");
            monthQueue.Enqueue("Mar");
            monthQueue.Enqueue("Apr");
            
            
            monthQueue.PrintQueue();
            Console.WriteLine(monthQueue.Count());
            

            Console.WriteLine(monthQueue.Peek());

            Console.WriteLine("+++++++++++++");
            //monthQueue.Dequeue();
            //monthQueue.PrintQueue();
            Console.WriteLine(monthQueue.Dequeue());
            Console.WriteLine(monthQueue.Dequeue());
            Console.WriteLine(monthQueue.Dequeue());
            Console.WriteLine(monthQueue.Dequeue());
            Console.WriteLine(monthQueue.Count());
            
            
            
        }
    }
}