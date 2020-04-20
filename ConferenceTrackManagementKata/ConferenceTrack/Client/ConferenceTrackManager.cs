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

           _trackGenerator.GenerateAllSessions(processedTalks);
           
           _trackGenerator.GenerateTracks();

           foreach (var track in _trackGenerator.Tracks)
           {
               foreach (var talk in track)
               {
                   Console.WriteLine( talk.TalkTime.ToString("hh':'mm") +  " " + talk.TalkTitle);
               }
           
           }
           
           // foreach (var talk in _trackGenerator.SessionAllocators[0].Sessions.SelectMany(session => session))
           // {
           //     Console.WriteLine( talk.TalkTime.ToString("hh':'mm") +  " " + talk.TalkTitle);
           // }
           //
           // foreach (var talk in _trackGenerator.SessionAllocators[1].Sessions.SelectMany(session => session))
           // {
           //     Console.WriteLine( talk.TalkTime.ToString("hh':'mm") +  " " + talk.TalkTitle);
           // }
           //
           

            
         
           

        }
        
        
    }
}