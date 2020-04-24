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
            var trackGenerator = new TrackGenerator(2,new List<ISessionAllocator>{new MorningSessionAllocator(new TimeSpan(9, 0, 0), new TimeSpan(12, 0,0 ) ), new AfternoonSessionAllocator(new TimeSpan(1, 0, 0), new TimeSpan(4, 0, 0), new TimeSpan(5, 0,0 )  )});
             
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
                "09:00  Writing Fast Tests Against Enterprise Rails 60min",
                "10:00  Communicating Over Distance 60min",
                "11:00  Rails Magic 60min",
                "12:00  Lunch",
                "01:00  Ruby Errors from Mismatched Gem Versions 45min",
                "01:45  Common Ruby Errors 45min",
                "02:30  Accounting-Driven Development 45min",
                "03:15  Pair Programming vs Noise 45min",
                "04:00  Clojure Ate Scala (on my project) 45min",
                "05:00  Networking Event",
                "Track 2",
                "09:00  Ruby on Rails: Why We Should Move On 60min",
                "10:00  Ruby on Rails Legacy App Maintenance 60min",
                "11:00  Overdoing it in Python 45min",
                "11:45  Rails for Python Developers lightning",
                "12:00  Lunch",
                "01:00  Lua for the Masses 30min",
                "01:30  Woah 30min",
                "02:00  Sit Down and Write 30min",
                "02:30  Programming in the Boondocks of Seattle 30min",
                "03:00  Ruby vs. Clojure for Back-End Development 30min",
                "03:30  A World Without HackerNews 30min",
                "04:00  User Interface CSS in Rails Apps 30min",
                "05:00  Networking Event"
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
                    talk.SetScheduledTalk($"{talk.TalkTime.ToString(Constants.FormatTime)}  {talk.TalkTitle}");
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
                        Messages.Add(talk.FormattedTitleAndTime); 
                    }
                }
            }

            public void DisplayError(string error)
            {
                Messages.Add(error);
            }
            
        }
    }
    
}