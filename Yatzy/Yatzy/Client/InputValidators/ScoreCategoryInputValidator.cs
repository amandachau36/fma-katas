using System;
using Yatzy.Application.Score;
using Yatzy.Application;

namespace Yatzy.Client.InputValidators
{
    public class ScoreCategoryInputValidator : IInputValidator
    {
        public bool IsValid(string input)
        {
            return Enum.IsDefined(typeof(ScoreCategory), input);
        }
    }
}