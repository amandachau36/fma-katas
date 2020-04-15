using System;
using System.Collections.Generic;
using System.Linq;
using Yatzy.Application;
using Yatzy.Application.Exceptions;
using Yatzy.Client.Display;
using Yatzy.Client.Exceptions;
using Yatzy.Client.InputCollector;
using Yatzy.Client.InputProcessor;
using Yatzy.Client.InputValidators;

namespace Yatzy.Client
{
    public class Game
    {
        private readonly IDisplay _display;
        
        private readonly IInputCollector _inputCollector;
        
        private readonly IInputProcessor _inputProcessor;

        private readonly Player _player;
        
        private readonly Dictionary<Validators, IInputValidator> _inputValidators;  //TODO: does this make sense?
        
        private bool _scoreCalculationIsComplete;

        private bool _holdingDiceIsComplete;

        public Game(Player player, IDisplay display, IInputCollector inputCollector, IInputProcessor inputProcessor, Dictionary<Validators, IInputValidator> inputValidators)
        {
            _inputValidators = inputValidators;
            _inputProcessor = inputProcessor;
            _display = display;
            _inputCollector = inputCollector;
            _player = player;
        }

        public void Play() //TODO: testing for this??  //TODO: multiple players??
        {
            _display.Display(Constants.WelcomeMessage);

            var rounds = 0;
            
            while (rounds < Constants.MaximumNumberOfRounds)
            {
                RollDiceForTurn();
                
                PreviewScoreCardForTurn();
                    
                UpdateScoreForTurn(); 
                
                ResetTurn();

                rounds++;
                
            }

        } 
        

        private void RollDiceForTurn()
        {
            RollDice();
            
            while (!AllDiceHeld())  
            {
                while (!_holdingDiceIsComplete)
                {
                    TryToHoldDice();
                }
                
                RollDice();
                
                _holdingDiceIsComplete = false;
            }
       
        }
        
        private void RollDice()
        {
            _player.Turn.RollDice();

            _display.Display(AllDiceHeld()
                ? Constants.FinalDiceValuesMessage
                : Constants.PlayerRolledMessage);

            _display.Display(_player.Turn.Dice);

        }
        
        private void TryToHoldDice()
        {
            try
            {
                UpdateDiceToHoldBasedOnUserInput();
            }
            catch (InvalidValuesToHoldException e)
            {
                _display.DisplayError(e.Message);
            }
            catch (InvalidDiceValueException e)
            {
                _display.DisplayError(e.Message);
            }
            
            //It's better to specify specific exceptions rather than catch all exceptions (Exception e)
            //because some exceptions you don't want to be handled by just consolewriteline the error
        
        }
        
        private void UpdateDiceToHoldBasedOnUserInput()
        {
            
            _display.Display(Constants.ReRollPrompt);

            var diceToHold = _inputCollector.CollectInput(); //TODO: Validate here? do validators need to be an interface? masterlist of validators and loop through (some will opt in or out)

            var processedDiceToHold = _inputProcessor.ConvertToDiceValues(diceToHold, _inputValidators[Validators.DiceValues] );
            
            _player.Turn.HoldDice(processedDiceToHold);

            _holdingDiceIsComplete = true;
        }

        private bool AllDiceHeld()
        {
            return _player.Turn.Dice.All(die => die.IsHeld);
        }

        private void PreviewScoreCardForTurn()
        {
            _player.ScoreCard.PreviewScoreCard(_player.Turn.Dice);
            _display.Display(_player.ScoreCard.ScoreCategories);
        }

        private void UpdateScoreForTurn()
        {
            while (!_scoreCalculationIsComplete)
            {
                TryToUpdateScore();
            }
 
        }

        private void TryToUpdateScore()
        {
            try
            {
                UpdateScoreBasedOnUserInput();
            }
            catch (InvalidScoreCategoryException e)
            {
                _display.DisplayError(e.Message);
            }
            catch (ScoreCategoryAlreadyTakenException e)
            {
                _display.DisplayError(e.Message);
            }
            
        }

        private void UpdateScoreBasedOnUserInput()
        {
            _display.Display(Constants.ScoreCategoryPrompt);

            var inputCategory = _inputCollector.CollectInput();

            var processedCategory = _inputProcessor.ConvertToScoreCategory(inputCategory, _inputValidators[Validators.ScoreCategory]);

            _player.ScoreCard.UpdateScoreCard(processedCategory, _player.Turn.Dice);

            _display.Display(_player.ScoreCard.ScoreCategories);

            _display.Display(_player.ScoreCard.Total);

            _scoreCalculationIsComplete = true;
        }
        
        private void ResetTurn()
        {
            _player.Turn.ResetTurn();

            _scoreCalculationIsComplete = false;
        }

    }
}


//TODO: Turn does not have to be a part of player, just game  or  each player can have the same instance of turn

