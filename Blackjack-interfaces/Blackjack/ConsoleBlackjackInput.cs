using System;

namespace Blackjack
{
    public class ConsoleBlackjackInput : IInput
    {
       

        public Game.NextMove GetPlayerMove()
        {
            var input = Console.ReadLine();
            if (input == "1")
                return Game.NextMove.Hit;
            if (input == "0")
                return Game.NextMove.Stay;

            return Game.NextMove.None;
        }
    }
}