using System;

namespace PatternDesignImageStorage
{
    public class BlackAndWhiteFilter : IFilter
    {
        public void Apply(string fileName)
        {
            Console.WriteLine($"Applying black and white filter to {fileName}");
        }
    }
}