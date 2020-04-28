using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business.Blocks;
using ConferenceTrack.Business.Exceptions;
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

        private bool _quit;
        

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
            _display.Display(Constants.Welcome);
            
            while (!_quit)
            {
                TryToManageTracks();
            }

        }

        private void TryToManageTracks()
        {
            try
            {
                var talks = GetTalks();

                if (_quit) return;

                var tracks = _trackGenerator.GenerateTracks(talks);

                DisplayTracks(tracks);
            }
            catch (InvalidPathOrFileException e)
            {
                _display.DisplayError(e.Message);
            }
            catch (InvalidTalkException e)
            {
                _display.DisplayError(e.Message);
            }
            catch (InvalidTalkDurationException e)
            {
                _display.DisplayError(e.Message);
            }

        }
        
        private List<Block> GetTalks() 
        {
            var processedTalks = new List<Block>();
            
            while (!processedTalks.Any())
            {
                _display.Display(Constants.FilePathPrompt);
            
                var input = _inputCollector.Collect();

                if (UserIsQuittingApplication(input))
                {
                    _quit = true;  // TODO: Command Query separation?
                    break;
                }
            
                var talks = _inputProvider.ProvideInput(input);
                
                processedTalks = _inputProcessor.Process(talks); 
            }

            return processedTalks;
        }

        private bool UserIsQuittingApplication(string input)
        {
            return input != null && input.ToLower() == "q";
        }


        private void DisplayTracks(List<Track> tracks)
        {
            var preparedTracks = _display.PrepareDisplay(tracks); 
            
            _display.WriteDisplay(preparedTracks);
            
            _quit = true;
        }
        
    }
}