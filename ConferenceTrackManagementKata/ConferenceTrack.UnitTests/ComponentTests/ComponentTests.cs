using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConferenceTrack.Business;
using ConferenceTrack.Business.SessionAllocator;
using ConferenceTrack.Business.Tracks;
using ConferenceTrack.Client;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.InputCollector;
using ConferenceTrack.Client.InputProcessor;
using ConferenceTrack.Client.InputProvider;
using ConferenceTrack.Client.InputValidator;
using Moq;
using Xunit;

namespace ConferenceTrack.UnitTests.ComponentTests
{
    public class ComponentTest1
    {
        [Fact]
        public void It_Should_DisplayErrorsAndTracks_WhenGivenInValidFilesThenAValidOne()
        {
            //Arrange
            // TODO: time as config
            var trackGenerator = new TrackGenerator(
                2,
                new List<ISessionAllocator>
                {
                    new MorningSessionAllocator(
                        new TimeSpan(9, 0, 0),  //TODO: Abstract smallest parts or can create variables with the TimeSpan 
                        new TimeSpan(12, 0,0 ) ), //TODO: Enum
                    new AfternoonSessionAllocator(
                        new TimeSpan(13, 0, 0), 
                        new TimeSpan(16, 0, 0), 
                        new TimeSpan(17, 0,0 )  )
                });
             
            var pathValidator = new PathValidator();
             
            var talkValidator = new TalkValidator();
             
            var consoleDisplay = new ConsoleDisplayStub();
            
            var consoleCollector = new Mock<IInputCollector>();
            consoleCollector.SetupSequence(x => x.Collect())
                .Returns(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "In", "OriginalTestInput.txt"))
                .Returns(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "InvalidTestInput.txt"))
                .Returns(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "OriginalTestInput.txt"));

            var conferenceTrackManager = new ConferenceTrackManager(consoleDisplay, consoleCollector.Object, new TextFileInputProvider(pathValidator),  new TextFileInputProcessor(talkValidator), trackGenerator);
            
            //Act
             
            conferenceTrackManager.ManageTracks();
             
            //Assert
            var expectedMessages = new List<string>
            {
                Constants.Welcome,
                Constants.FilePathPrompt,
                $"Not a valid path or file: {Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "In", "OriginalTestInput.txt")}. \nOnly .txt files are valid",
                Constants.FilePathPrompt,
                "Not a valid talk: A World Without HackerNews. \nMust contain duration in minutes or be a lightning talk.",
                Constants.FilePathPrompt,
                "Track 1",
                "09:00 AM  Writing Fast Tests Against Enterprise Rails 60min",
                "10:00 AM  Communicating Over Distance 60min",
                "11:00 AM  Rails Magic 60min",
                "12:00 PM  Lunch",
                "01:00 PM  Ruby Errors from Mismatched Gem Versions 45min",
                "01:45 PM  Common Ruby Errors 45min",
                "02:30 PM  Accounting-Driven Development 45min",
                "03:15 PM  Pair Programming vs Noise 45min",
                "04:00 PM  Clojure Ate Scala (on my project) 45min",
                "05:00 PM  Networking Event",
                "Track 2",
                "09:00 AM  Ruby on Rails: Why We Should Move On 60min",
                "10:00 AM  Ruby on Rails Legacy App Maintenance 60min",
                "11:00 AM  Overdoing it in Python 45min",
                "11:45 AM  Rails for Python Developers lightning",
                "12:00 PM  Lunch",
                "01:00 PM  Lua for the Masses 30min",
                "01:30 PM  Woah 30min",
                "02:00 PM  Sit Down and Write 30min",
                "02:30 PM  Programming in the Boondocks of Seattle 30min",
                "03:00 PM  Ruby vs. Clojure for Back-End Development 30min",
                "03:30 PM  A World Without HackerNews 30min",
                "04:00 PM  User Interface CSS in Rails Apps 30min",
                "05:00 PM  Networking Event"
            };

            for (var i = 0; i < consoleDisplay.Messages.Count; i++)
            {
                Assert.Equal(expectedMessages[i], consoleDisplay.Messages[i]);
            }
            //Assert.True(consoleDisplay.Messages.SequenceEqual(expectedMessages)); 
            
            
            
        }
        
        
        private class ConsoleDisplayStub : IDisplay  //Can also do with moq 
        {
            public List<string> Messages = new List<string>();
            public void Display(string message)
            {
                Messages.Add(message);
            }

            public List<Track> PrepareDisplay(List<Track> tracks)
            {
                foreach (var talk in tracks.SelectMany(t => t.Talks))
                {
                    talk.SetFormattedBlockNameAndTimeSlot($"{FormatTime(talk.TimeSlot)}  {talk.BlockName}");
                }

                return tracks;
            }

            public void WriteDisplay(List<Track> tracks)
            {
                foreach (var t in tracks)
                {
                    Messages.Add(t.TrackTitle);
                
                    foreach (var talk in t.Talks)
                    {
                        Messages.Add(talk.FormattedBlockNameAndTimeSlot); 
                    }
                }
            }

            public void DisplayError(string error)
            {
                Messages.Add(error);
            }
            
            private string FormatTime(TimeSpan time)
            {
                var dateTime = DateTime.Today.Add(time);
            
                return dateTime.ToString("hh:mm tt");
            }
            
        }
    }
    
}