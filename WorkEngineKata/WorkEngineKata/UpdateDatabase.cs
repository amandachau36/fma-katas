using System;

namespace WorkEngineKata
{
    public class UpdateDatabase : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Change the status of the video record in the database to “Processing");
        }
    }
}