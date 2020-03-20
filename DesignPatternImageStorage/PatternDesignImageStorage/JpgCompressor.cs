using System;

namespace PatternDesignImageStorage
{
    public class JpgCompressor : ICompressor
    {
        public void Compress(string fileName)
        {
            Console.WriteLine($"Compressing {fileName}.jpg");
        }
    }
}