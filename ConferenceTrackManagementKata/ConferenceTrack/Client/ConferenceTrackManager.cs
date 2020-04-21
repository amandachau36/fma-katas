using System;
using System.Linq;
using ConferenceTrack.Business;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.InputCollector;
using ConferenceTrack.Client.InputProcessor;

namespace ConferenceTrack.Client
{
    public class ConferenceTrackManager
    {
        private readonly IDisplay _display;
        
        private readonly IInputCollector _inputCollector;
        
        private readonly IInputProcessor _inputProcessor;
        
        private readonly TrackGenerator _trackGenerator;

        public ConferenceTrackManager(IDisplay display, IInputCollector inputCollector, IInputProcessor inputProcessor, TrackGenerator trackGenerator)
        {
            _display = display;
            _inputCollector = inputCollector;
            _inputProcessor = inputProcessor;
            _trackGenerator = trackGenerator;
        }
        
        public void ManageTracks(string path)
        {
           var talks = _inputCollector.Collect(path);

           var processedTalks = _inputProcessor.Process(talks);

           _trackGenerator.GenerateTracks(processedTalks);
           
           _display.Display(_trackGenerator.Tracks);
           
        }
        
        
    }
}