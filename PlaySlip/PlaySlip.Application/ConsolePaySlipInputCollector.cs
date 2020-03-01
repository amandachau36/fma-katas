using System;

namespace PlaySlip.Application
{
    public class ConsolePaySlipInputCollector : IInputCollector
    {
        public string CollectInput()
        {
            return Console.ReadLine();
        }
    }
}