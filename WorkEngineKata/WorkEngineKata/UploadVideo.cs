using System;

namespace WorkEngineKata
{
    public class UploadVideo : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Upload a video to a cloud storage");
        }
    }
}


