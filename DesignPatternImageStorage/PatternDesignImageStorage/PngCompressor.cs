using System;

namespace PatternDesignImageStorage
{
    public class PngCompressor : ICompressor
    {
        public void Compress(string fileName)
        {
            Console.WriteLine($"Compressing {fileName}.png");
        }
    }
}