using System;

namespace WorkEngineKata
{
    public class NotifyWebService : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Call a web service provided by a third-party video encoding service to tell them you have a video ready for encoding");
        }
    }
}


