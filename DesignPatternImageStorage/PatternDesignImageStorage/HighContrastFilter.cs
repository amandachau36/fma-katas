using System;

namespace PatternDesignImageStorage
{
    public class HighContrastFilter : IFilter
    {
        public void Apply(string fileName)
        {
            Console.WriteLine($"Applying high contrast filter to {fileName}");
        }
    }
}