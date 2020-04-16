namespace Yatzy.Application.Dice.Models
{
    public interface IDie
    {
        int Value { get; }

        bool IsHeld { get; }

        void Roll();

        public void UpdateIsHeld(bool isHeld);

    }
}