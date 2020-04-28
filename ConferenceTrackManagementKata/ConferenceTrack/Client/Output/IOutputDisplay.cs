using System.Collections.Generic;
using ConferenceTrack.Business.Tracks;

namespace ConferenceTrack.Client.Output
{
    public interface IOutputDisplay
    {
        List<Track> PrepareDisplay(List<Track> tracks);

        void WriteDisplay(List<Track> tracks);
    }
}