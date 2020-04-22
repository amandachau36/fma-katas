using System.Collections.Generic;
using ConferenceTrack.Business;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.Exceptions;
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
        
        private bool _getTalksIsComplete;
        
        private List<Talk> _processedTalks = new List<Talk>();
        
        

        public ConferenceTrackManager(IDisplay display, IInputCollector inputCollector, IInputProcessor inputProcessor, TrackGenerator trackGenerator)
        {
            _display = display;
            _inputCollector = inputCollector;
            _inputProcessor = inputProcessor;
            _trackGenerator = trackGenerator;
        }
        
        public void ManageTracks()  
        { 
            _display.Display(Constants.Welcome);

            GetTalks();

            _trackGenerator.GenerateTracks(_processedTalks); // TODO: return tracks instead of field 

           _display.Display(_trackGenerator.Tracks);  //TODO: Moq to mock the Display
           
        }

        private void GetTalks()
        {
            while (!_getTalksIsComplete)
            {
                TryToGetTalks();
            }
        }

        private void TryToGetTalks()
        {
            try
            {
                _display.Display(Constants.FilePathPrompt);
            
                var talks = _inputCollector.Collect(); //TODO: mock this 
            
                _processedTalks  = _inputProcessor.Process(talks); //Can put this line and the line below it 

                _getTalksIsComplete = true;

            }
            catch (InvalidPathOrFileException e)
            {
                _display.DisplayError(e.Message);
            }
            catch (InvalidTalkException e)
            {
                _display.DisplayError(e.Message);
            }
        }
        
        
        
    }
}