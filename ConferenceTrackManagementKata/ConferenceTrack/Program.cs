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

            var morningSessionAllocator = new SessionAllocator(
                ConfigurationLoader.LoadSessionConfiguration("morningSession.json"));
            
            var afternoonSessionAllocator = new SessionAllocator(
                ConfigurationLoader.LoadSessionConfiguration("afternoonSession.json"));

            var trackGenerator = new TrackGenerator(
                2, 
                new List<SessionAllocator> 
                {
                    morningSessionAllocator, 
                    afternoonSessionAllocator
                } );
            
            var talkValidator = new TalkValidator();
            
            var pathValidator = new PathValidator();

            var conferenceTrackManager = new ConferenceTrackManager(
                new ConsoleDisplay(), 
                new ConsoleInputCollector(), 
                new TextFileInputProvider(pathValidator), 
                new TextFileInputProcessor(talkValidator), 
                trackGenerator );
            
            conferenceTrackManager.ManageTracks();
            
            
           // /Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/Input/OriginalTestInput.txt
            
            ///Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/Input/InvalidTestInput.txt
     
            
        }
    }
}
