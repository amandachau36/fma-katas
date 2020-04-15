using System;
using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Exceptions;

namespace Yatzy.Application.Score.Models
{
    public class Turn
    {
        //variables/constructors/properties
        public int RollCount { get; private set; }

        public Turn(List<Die> dice)
        {
            Dice = dice; 
        }
        
        public List<Die> Dice { get; }

        public void RollDice()
        {
            if(RollCount >= Constants.MaximumNumberOfRolls)
                throw new MaxNumberOfRollsExceededException("Maximum number of rolls exceeded. You can only roll three times."); 
            
            RollDiceThatAreNotHeld();
            
            RollCount++;
            
            HoldAllDiceOnLastRoll();
        }

        private void RollDiceThatAreNotHeld()
        {
            foreach (var die in Dice.Where(die => !die.IsHeld))
            {
                die.Roll();
            }
        }

        public void HoldDice(List<int> valuesToHold)  
        {
            ResetDiceToNotHeld();

            foreach (var die in Dice.Where(die => valuesToHold.Contains(die.Value)))
            {
                die.UpdateIsHeld(true);
                valuesToHold.Remove(die.Value);
            }
            
            if(valuesToHold.Count > 0)
                throw new InvalidDiceValueException(valuesToHold); 
                    //is this okay to throw the exception at the end of the method? Yes it's okay as long as it's uniformed
            
            
        }

        public void ResetTurn()
        {
            ResetRollCountToZero();
            ResetDiceToNotHeld();
        }

        private void HoldAllDiceOnLastRoll()
        {
            if (RollCount < Constants.MaximumNumberOfRolls) return;

            Dice.ForEach(die => die.UpdateIsHeld(true));

        }
        
        private void ResetRollCountToZero()
        {
            RollCount = 0;  
        }

        private void ResetDiceToNotHeld()
        {
            Dice.ForEach(die => die.UpdateIsHeld(false));
        }
        
    }
}