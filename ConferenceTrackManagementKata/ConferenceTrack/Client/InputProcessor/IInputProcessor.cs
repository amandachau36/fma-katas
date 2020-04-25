using System.Collections.Generic;

namespace ConferenceTrack.Client.InputProcessor
{
    public interface IInputProcessor
    {
        List<Block> Process(string[] talks);
    }
}