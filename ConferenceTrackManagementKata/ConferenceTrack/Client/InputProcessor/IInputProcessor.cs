using System.Collections.Generic;
using ConferenceTrack.Business.Blocks;

namespace ConferenceTrack.Client.InputProcessor
{
    public interface IInputProcessor
    {
        List<Block> Process(string[] talks);
    }
}