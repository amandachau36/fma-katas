using System;
using System.Collections.Generic;

namespace PatternDesignImageStorage
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var imageStorage = new ImageStorage(new PngCompressor());
            
                imageStorage.AddFilters(new HighContrastFilter());
                imageStorage.AddFilters(new BlackAndWhiteFilter());
            
                imageStorage.Store("myPhoto");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
              
            }
            
            
        }
    }
}


