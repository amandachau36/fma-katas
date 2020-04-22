using System.Collections.Generic;
using System.Linq;
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

        public ConferenceTrackManager(IDisplay display, IInputCollector inputCollector, IInputProcessor inputProcessor, TrackGenerator trackGenerator)
        {
            _display = display;
            _inputCollector = inputCollector;
            _inputProcessor = inputProcessor;
            _trackGenerator = trackGenerator;
        }
        
        
        public void ManageTracks(List<Talk> processedTalks)  
        {
            _trackGenerator.GenerateTracks(processedTalks); // TODO: return tracks instead of field 

           _display.Display(_trackGenerator.Tracks);  //TODO: Moq to mock the Display
           
        }

        public List<Talk> GetTalks()
        {
            _display.Display(Constants.Welcome);
            
            var processedTalks = new List<Talk>();
            
            while (!processedTalks.Any())
            {
                processedTalks = TryToGetTalks().ToList();
            }

            return processedTalks;
        }

        private IEnumerable<Talk> TryToGetTalks()
        {
            try
            {
                _display.Display(Constants.FilePathPrompt);
            
                var talks = _inputCollector.Collect(); //TODO: mock this 

                var processedTalks = _inputProcessor.Process(talks); //Can put this line and the line below it 
                
                return processedTalks;

            }
            catch (InvalidPathOrFileException e)
            {
                _display.DisplayError(e.Message);
                
                return Enumerable.Empty<Talk>();
            }
            catch (InvalidTalkException e)
            {
                _display.DisplayError(e.Message);
                
                return Enumerable.Empty<Talk>();
            }
        }
        
        
        
    }
}