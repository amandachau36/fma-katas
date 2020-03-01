using System;

namespace PlaySlip.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var consolePaySlipDisplay = new ConsolePlaySlipDisplay();
            
            var consolePaySlipInputCollector = new ConsolePaySlipInputCollector();

            var printPaySlip = new PaySlipManager(consolePaySlipDisplay, consolePaySlipInputCollector);

            printPaySlip.Process();
            
        }
    }
}



