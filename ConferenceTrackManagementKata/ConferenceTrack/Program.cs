using System;
using System.Collections.Generic;
using ConferenceTrack.Business;
using ConferenceTrack.Client;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.InputCollector;
using ConferenceTrack.Client.InputProcessor;
using ConferenceTrack.Client.InputValidator;

namespace ConferenceTrack
{
    class Program
    {
        static void Main(string[] args)
        {
            var morningSessionAllocator =  new MorningSessionAllocator(new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0) );
            var afternoonSessionAllocator = new AfternoonSessionAllocator(new TimeSpan(1, 0, 0), new TimeSpan(4, 0,0), new TimeSpan(5, 0, 0)  );
            
            var trackGenerator = new TrackGenerator(2, new List<ISessionAllocator>{morningSessionAllocator, afternoonSessionAllocator} );
            
            var talkValidator = new TalkValidator();
            
            var pathValidator = new PathValidator();
            
            var consoleDisplay = new ConsoleDisplay(); //TODO: this feeels wrong
            
            var conferenceTrackManager = new ConferenceTrackManager(consoleDisplay, new TextFileInputCollector(pathValidator, consoleDisplay), new TextFileInputProcessor(talkValidator), trackGenerator );
            
            
            // TODO: another method for collecting the talks.  ManageTracks should take an array of tracks
            conferenceTrackManager.ManageTracks();
            
            ////Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/Input/OriginalTestInput.txt
            
            ///Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/Input/InvalidTestInput.txt

            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);


        }
    }
}
