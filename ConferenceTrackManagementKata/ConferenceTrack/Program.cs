using System;
using System.Collections.Generic;
using ConferenceTrack.Business.SessionAllocator;
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
            var morningSessionAllocator =  new MorningSessionAllocator(new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0) );
            var afternoonSessionAllocator = new AfternoonSessionAllocator(new TimeSpan(13, 0, 0), new TimeSpan(16, 0,0), new TimeSpan(17, 0, 0)  );
            
            var trackGenerator = new TrackGenerator(2, new List<ISessionAllocator>{morningSessionAllocator, afternoonSessionAllocator} );
            
            var talkValidator = new TalkValidator();
            
            var pathValidator = new PathValidator();

            var conferenceTrackManager = new ConferenceTrackManager(new ConsoleDisplay(), new ConsoleInputCollector(), new TextFileInputProvider(pathValidator), new TextFileInputProcessor(talkValidator), trackGenerator );
            
            conferenceTrackManager.ManageTracks();
            
            //
            
           // /Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/Input/OriginalTestInput.txt
            
            ///Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/Input/InvalidTestInput.txt
            
            
            //
            // TimeSpan timespan = new TimeSpan(15,00,00);
            // DateTime time = DateTime.Today.Add(timespan);
            // string displayTime = time.ToString("hh:mm tt");
            //
            // Console.WriteLine(displayTime);



        }
    }
}
