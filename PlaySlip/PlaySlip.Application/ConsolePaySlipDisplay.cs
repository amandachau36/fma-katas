using System;
using System.Collections.Generic;

namespace PlaySlip.Application
{
    public class ConsolePlaySlipDisplay : IDisplay
    {
        public void Display(string message)
        {
            Console.Write(message);
        }

        public void Display(List<string> messages)
        {
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
        }
        
    }
}


// other methods are private