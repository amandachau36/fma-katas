using System;
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
using ConferenceTrack.Client.Output;

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

                var outputDisplayType = GetOutputDisplayType();

                DisplayTracks(outputDisplayType,tracks);
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
            return input != null && input.ToLower() == Constants.Quit;
        }
        
        private OutputDisplayType GetOutputDisplayType()
        {
            OutputDisplayType outputDisplayType;
            
            while (true)
            {
                _display.Display(Constants.DisplayTypePrompt);
                
                var input = _inputCollector.Collect();
                
                var processedInput = int.Parse(input) - 1; //TODO:  refactor using  InputProcessor/providerCollector ete

                if (!Enum.IsDefined(typeof(OutputDisplayType), processedInput)) continue;

                outputDisplayType = (OutputDisplayType)processedInput;

                break;
            }

            return outputDisplayType;

        }
        


        private void DisplayTracks(OutputDisplayType outputDisplayType, List<Track> tracks)
        {
            var outputDisplay = OutputDisplayFactory.CreateOutputDisplay(outputDisplayType);
            
            var preparedTracks = outputDisplay.PrepareDisplay(tracks); 
            
            outputDisplay.WriteDisplay(preparedTracks);
            
            _quit = true;
        }
        
    }
}