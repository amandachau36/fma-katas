using System;
using System.Collections.Generic;
using System.IO;
using ConferenceTrack.Business;
using ConferenceTrack.Client;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.InputCollector;
using ConferenceTrack.Client.InputProcessor;
using ConferenceTrack.Client.InputValidator;
using Xunit;

namespace ConferenceTrack.UnitTests.ComponentTests
{
    public class ComponentTest1
    {
        [Fact]
        public void It_Should_Test_Most_Of_This_Kata()
        {
            //Arrange
            // TODO: time as config
            var trackGenerator = new TrackGenerator(2,new List<ISessionAllocator>{new MorningSessionAllocator(new TimeSpan(9, 0, 0), new TimeSpan(12, 0,0 ) ), new AfternoonSessionAllocator(new TimeSpan(1, 0, 0), new TimeSpan(4, 0, 0), new TimeSpan(5, 0,0 )  )});
             
            var pathValidator = new PathValidator();
             
            var talkValidator = new TalkValidator();
             
            var consoleDisplay = new ConsoleDisplayStub();
             
             
            var conferenceTrackManager = new ConferenceTrackManager(consoleDisplay, new TextFileInputCollector(pathValidator, consoleDisplay), new TextFileInputProcessor(talkValidator), trackGenerator );
            //Act
             
            conferenceTrackManager.ManageTracks();
             
            //Assert
            Assert.Empty(consoleDisplay.Messages); 
             
            //acceptance tests
        }
        
        public class ConsoleDisplayStub : IDisplay  //Can also do with moq 
        {
            public List<string> Messages = new List<string>();
            public void Display(string message)
            {
                Messages.Add(message);
            }

            public List<Track> PrepareDisplay(List<Track> tracks)
            {
                throw new NotImplementedException();
            }

            public void WriteDisplay(List<Track> tracks)
            {
                throw new NotImplementedException();
            }

            public void Display(List<Track> tracks)
            {
                foreach (var track in tracks)
                {
                    
                }
            }

            public void DisplayError(string error)
            {
                throw new NotImplementedException();
            }

            public string ReadDisplay()
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "OriginalTestInput.txt");
            }
        }
    }
    
}