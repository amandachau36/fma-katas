namespace Blackjack
{
    public interface IInput
    {
        Game.NextMove GetPlayerMove(); // this isn't good . . . what if input is not a string 

    }
}