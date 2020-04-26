using System;
using System.Collections.Generic;
using ConferenceTrack.Business.Config;
using ConferenceTrack.Business.Sessions;
using ConferenceTrack.Business.Tracks;
using ConferenceTrack.Client;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.InputCollector;
using ConferenceTrack.Client.InputProcessor;
using ConferenceTrack.Client.InputProvider;
using ConferenceTrack.Client.InputValidator;

namespace ConferenceTrack
{
    class Program
    {
        static void Main(string[] args)
        {
            var morningSessionConfig = ConfigurationLoader.LoadSessionConfiguration("morningSession.json");

            var afternoonSessionConfig = ConfigurationLoader.LoadSessionConfiguration("afternoonSession.json");
            
            var morningSessionAllocator = new SessionAllocator(morningSessionConfig);
            
            var afternoonSessionAllocator = new SessionAllocator(afternoonSessionConfig);

            var trackGenerator = new TrackGenerator(2, new List<SessionAllocator>{morningSessionAllocator, afternoonSessionAllocator} );
            
            var talkValidator = new TalkValidator();
            
            var pathValidator = new PathValidator();

            var conferenceTrackManager = new ConferenceTrackManager(new ConsoleDisplay(), new ConsoleInputCollector(), new TextFileInputProvider(pathValidator), new TextFileInputProcessor(talkValidator), trackGenerator );
            
            conferenceTrackManager.ManageTracks();
            
            
           // /Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/Input/OriginalTestInput.txt
            
            ///Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/Input/InvalidTestInput.txt
            ///
            
        }
    }
}
