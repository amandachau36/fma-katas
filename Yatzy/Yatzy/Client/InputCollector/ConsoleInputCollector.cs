using System;

namespace Yatzy.Client.InputCollector
{
    public class ConsoleInputCollector : IInputCollector
    {
        public string CollectInput()
        {
            return Console.ReadLine();
        }
    }
}