using System;

namespace PlaySlip.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var consolePaySlipDisplay = new ConsolePlaySlipDisplay();

            var printPaySlip = new PaySlipManager(consolePaySlipDisplay);

            printPaySlip.Process();
            
        }
    }
}



