using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConferenceTrack.Business;
using ConferenceTrack.Client;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.InputCollector;
using ConferenceTrack.Client.InputProcessor;
using ConferenceTrack.Client.InputValidator;
using Xunit;

namespace ConferenceTrack.UnitTests.ComponentTests
{
    public class ComponentTest2
    {
        //[Fact]
        // public void It_Should_DisplayAnError_When_Given_AnInvalidPath()
        // {
        //     //Arrange
        //     // TODO: time as config
        //     var trackGenerator = new TrackGenerator(2,new List<ISessionAllocator>{new MorningSessionAllocator(new TimeSpan(9, 0, 0), new TimeSpan(12, 0,0 ) ), new AfternoonSessionAllocator(new TimeSpan(1, 0, 0), new TimeSpan(4, 0, 0), new TimeSpan(5, 0,0 )  )});
        //      
        //     var pathValidator = new PathValidator();
        //      
        //     var talkValidator = new TalkValidator();
        //      
        //     var consoleDisplay = new ConsoleDisplayStub();
        //      
        //      
        //     var conferenceTrackManager = new ConferenceTrackManager(consoleDisplay, new TextFileInputCollector(pathValidator, consoleDisplay), new TextFileInputProcessor(talkValidator), trackGenerator );
        //     //Act
        //      
        //     conferenceTrackManager.ManageTracks();
        //      
        //     //Assert
        //     var expectedMessages = new List<string>
        //     {
        //         Constants.Welcome,
        //         Constants.FilePathPrompt,
        //         
        //     };
        //   
        //     Assert.True(consoleDisplay.Messages.SequenceEqual(expectedMessages)); 
        //     
        // }
        //
        //
        //
        // public class ConsoleDisplayStub : IDisplay  //Can also do with moq 
        // {
        //     public List<string> Messages = new List<string>();
        //     
        //     
        //     public void Display(string message)
        //     {
        //         Messages.Add(message);
        //     }
        //
        //     public List<Track> PrepareDisplay(List<Track> tracks)
        //     {
        //         foreach (var talk in tracks.SelectMany(t => t.Talks))
        //         {
        //             talk.SetScheduledTalk($"{talk.TalkTime.ToString(Constants.FormatTime)}  {talk.TalkTitle}");
        //         }
        //
        //         return tracks;
        //     }
        //
        //     public void WriteDisplay(List<Track> tracks)
        //     {
        //         foreach (var t in tracks)
        //         {
        //             Messages.Add(t.TrackTitle);
        //         
        //             foreach (var talk in t.Talks)
        //             {
        //                 Messages.Add(talk.ScheduledTalk); 
        //             }
        //         }
        //     }
        //
        //     public void DisplayError(string error)
        //     {
        //         Messages.Add(error + "\nPlease try again");
        //         //Environment.Exit(0); //File not present
        //     }
        //
        //     public string ReadDisplay() //TODO: quit 
        //     {
        //         return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "In", "OriginalTestInput.txt");
        //     }
        //     
        //
        // }
    }
    
}