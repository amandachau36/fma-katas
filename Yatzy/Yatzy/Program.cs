using System;
using System.Collections.Generic;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Roller;
using Yatzy.Application.Score;
using Yatzy.Application.Score.Models;
using Yatzy.Application;
using Yatzy.Client;
using Yatzy.Client.Display;
using Yatzy.Client.InputCollector;
using Yatzy.Client.InputProcessor;
using Yatzy.Client.InputValidators;
using Constants = Yatzy.Client.Constants;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
        
            var randomRoller = new RandomRoller();

            var fiveDice = new List<Die>
            {
                new Die(randomRoller),
                new Die(randomRoller),
                new Die(randomRoller),
                new Die(randomRoller),
                new Die(randomRoller)
            };
        
            var turn = new Turn(fiveDice);
            var player = new Player(turn, new ScoreCard());

            var inputValidators = new Dictionary<Validators, IInputValidator>
            {
                {Validators.DiceValues, new DiceValuesToHoldValidator()},
                {Validators.ScoreCategory, new ScoreCategoryInputValidator()}

            };
            
            var game = new Game( player, new ConsoleDisplay(), new ConsoleInputCollector(), new ConsoleInputProcessor(), inputValidators);
            
            game.Play();
            
        }
    } 
}






