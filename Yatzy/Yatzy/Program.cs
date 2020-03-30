using System;
using System.Collections.Generic;
using System.Linq;
using Yatzy.Application;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Roller;
using Yatzy.Application.Turn.Models;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
        

            try
            {
                var randomRoller = new RandomRoller();
                var fiveMockDice = new List<Die>
                {
                    new Die(randomRoller),
                    new Die(randomRoller),
                    new Die(randomRoller),
                    new Die(randomRoller),
                    new Die(randomRoller),
                };
                
                var turn = new Turn(fiveMockDice);
                
                turn.Roll();
                
                turn.Hold(new List<int>{0, 1, 2, 3, 4});

                foreach (var dice in turn.DiceHeld)
                {
                    Console.WriteLine(dice.Value);
                }

              


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
             
            }
            
        }
    }
}



//var dice = new Dice(new RandomRoller());
// Console.WriteLine(dice.Roll());
// Console.WriteLine(dice.Roll());
            
//
// var turn = new Turn(dice);
// turn.Roll();
//
// foreach (var value in turn.CurrentRolledValues)
// {
//     Console.WriteLine(value);
// }