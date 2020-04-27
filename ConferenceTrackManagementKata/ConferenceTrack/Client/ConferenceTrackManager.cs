using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business.Blocks;
using ConferenceTrack.Business.Tracks;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.Exceptions;
using ConferenceTrack.Client.InputCollector;
using ConferenceTrack.Client.InputProcessor;
using ConferenceTrack.Client.InputProvider;

namespace ConferenceTrack.Client
{
    public class ConferenceTrackManager
    {
        private readonly IDisplay _display;
        
        private readonly IInputCollector _inputCollector;
        
        private readonly IInputProvider _inputProvider;

        private readonly IInputProcessor _inputProcessor;
        
        private readonly TrackGenerator _trackGenerator;

        public ConferenceTrackManager(IDisplay display, IInputCollector inputCollector, IInputProvider inputProvider, IInputProcessor inputProcessor, TrackGenerator trackGenerator)
        {
            _display = display;
            _inputCollector = inputCollector;
            _inputProvider = inputProvider;
            _inputProcessor = inputProcessor;
            _trackGenerator = trackGenerator;
        }

        public void ManageTracks()
        {
            var talks = GetTalks();
            
            var tracks = GenerateTracks(talks); 
            
            DisplayTracks(tracks);  //it's possible to mock the display using Moq 
        }

        private void DisplayTracks(List<Track> tracks)
        {
            var preparedTracks = _display.PrepareDisplay(tracks); 
            
            _display.WriteDisplay(preparedTracks);
        }

        private List<Track> GenerateTracks(List<Block> processedTalks)  
        {
          return _trackGenerator.GenerateTracks(processedTalks); 
        }
        
        private List<Block> GetTalks()
        {
            _display.Display(Constants.Welcome);
            
            var processedTalks = new List<Block>();
            
            while (!processedTalks.Any())
            {
                processedTalks = TryToGetTalks().ToList();
            }

            return processedTalks;
        }

        private IEnumerable<Block> TryToGetTalks()
        {
            try
            {
                _display.Display(Constants.FilePathPrompt);
            
                var input = _inputCollector.Collect();

                var talks = _inputProvider.ProvideInput(input);

                var processedTalks = _inputProcessor.Process(talks); 
                
                return processedTalks;

            }
            catch (InvalidPathOrFileException e)
            {
                _display.DisplayError(e.Message);
                
                return Enumerable.Empty<Block>();
            }
            catch (InvalidTalkException e)
            {
                _display.DisplayError(e.Message);
                
                return Enumerable.Empty<Block>();
            }
        }
        
    }
}