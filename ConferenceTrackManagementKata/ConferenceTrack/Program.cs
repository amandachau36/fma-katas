﻿using System;
using System.Collections.Generic;
using ConferenceTrack.Business;
using ConferenceTrack.Client;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.InputCollector;
using ConferenceTrack.Client.InputProcessor;

namespace ConferenceTrack
{
    class Program
    {
        static void Main(string[] args)
        {
            var morningSessionAllocator =  new MorningSessionAllocator(new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0) );
            var afternoonSessionAllocator = new AfternoonSessionAllocator(new TimeSpan(1, 0, 0), new TimeSpan(4, 0,0), new TimeSpan(5, 0, 0)  );
            
            var trackGenerator = new TrackGenerator(2, new List<ISessionAllocator>{morningSessionAllocator, afternoonSessionAllocator} );
            
            var conferenceTrackManager = new ConferenceTrackManager(new ConsoleDisplay(), new TextFileInputCollector(), new TextFileInputProcessor(), trackGenerator );
            
            conferenceTrackManager.ManageTracks("/Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/bin/Debug/netcoreapp3.1/Input/OriginalTestInput.txt");

        }
    }
}
