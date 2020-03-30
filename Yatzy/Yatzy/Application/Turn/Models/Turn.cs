using System;
using System.Collections.Generic;
using System.Linq;
using Yatzy.Application.Dice.Models;
using Yatzy.Application.Exceptions;

namespace Yatzy.Application.Turn.Models
{
    public class Turn
    {
        //variables/constructors/properties
        private int _rollCount;

        public Turn(List<Die> diceToRoll)
        {
            if(diceToRoll.Count != Constants.MaximumNumberOfDice) 
                throw new ArgumentOutOfRangeException("diceToRoll");
            
            DiceToRoll = diceToRoll; 
        }
        
        public List<Die> DiceToRoll { get; }
        public List<Die> DiceHeld { get; } = new List<Die>();
        
        public void Roll()
        {
            if(_rollCount >= Constants.MaximumNumberOfRolls)
                throw new MaxNumberOfRollsExceededException("Maximum number of rolls exceeded. You can only roll three times.");
            
            foreach (var die in DiceToRoll)
            {
                die.Roll();
            }
            
            _rollCount++;
        }

        public void Hold(List<int> indexesToHold)
        {
         
            AddDiceToDiceHeld(indexesToHold);

            RemoveDiceFromDiceToRoll(indexesToHold);

        }

        private void AddDiceToDiceHeld(List<int> indexesToHold)
        {
            foreach (var index in indexesToHold)
            {
                if(index < 0 || index > Constants.MaximumNumberOfDice - 1 )
                    throw new InvalidDiceIndexException(index); 
                
                DiceHeld.Add(DiceToRoll[index]);
            }
        }

        private void RemoveDiceFromDiceToRoll(List<int> indexesToHold)
        {
            //sort by descending order otherwise the wrong index will be removes
            foreach (var index in indexesToHold.OrderByDescending(x => x))
            {
                DiceToRoll.RemoveAt(index);
            }   
        }
        
    }
}