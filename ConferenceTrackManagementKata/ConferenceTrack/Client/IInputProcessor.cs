using System.Collections.Generic;

namespace ConferenceTrack.Client
{
    public interface IInputProcessor
    {
        List<Talk> Process(string[] talks);
    }
}