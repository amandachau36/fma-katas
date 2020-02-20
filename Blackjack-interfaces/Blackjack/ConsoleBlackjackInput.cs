using System;

namespace Blackjack
{
    public class ConsoleBlackjackInput : IInput
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}