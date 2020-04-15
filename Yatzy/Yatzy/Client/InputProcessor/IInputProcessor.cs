using System.Collections.Generic;
using Yatzy.Application.Score;
using Yatzy.Application;
using Yatzy.Client.InputValidators;

namespace Yatzy.Client.InputProcessor
{
    public interface IInputProcessor
    {
        List<int> ConvertToDiceValues(string diceToHold, IInputValidator inputValidator );
        ScoreCategory ConvertToScoreCategory(string scoreCategory, IInputValidator inputValidator);
        
    }
} 