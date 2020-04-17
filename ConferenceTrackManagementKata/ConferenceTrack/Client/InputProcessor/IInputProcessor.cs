using System.Collections.Generic;

namespace ConferenceTrack.Client.InputProcessor
{
    public interface IInputProcessor
    {
        List<Talk> Process(string[] talks);
    }
}