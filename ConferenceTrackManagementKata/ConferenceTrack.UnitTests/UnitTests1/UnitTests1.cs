// using System;
// using System.Collections.Generic;
// using ConferenceTrack.Business;
// using ConferenceTrack.Client;
// using ConferenceTrack.Client.Display;
// using ConferenceTrack.Client.InputCollector;
// using ConferenceTrack.Client.InputProcessor;
// using ConferenceTrack.Client.InputValidator;
// using Xunit;
// namespace ConferenceTrack.UnitTests.UnitTests1
// {
//     public class UnitTests1
//     {
//         [Fact]
//         public void Test1() //Component tests - can read from test file. Put as many dependencies in as possible. 
//         //integration test - two systems talking to each other
//         // the more you can keep in memory the better
//         {
//             //Arrange
//             // TODO: time as config
//             var trackGenerator = new TrackGenerator(2,new List<ISessionAllocator>{new MorningSessionAllocator(new TimeSpan(9, 0, 0), new TimeSpan(12, 0,0 ) ), new AfternoonSessionAllocator(new TimeSpan(1, 0, 0), new TimeSpan(4, 0, 0), new TimeSpan(5, 0,0 )  )});
//             
//             var pathValidator = new PathValidator();
//             
//             var talkValidator = new TalkValidator();
//             
//             var consoleDisplay = new ConsoleDipslayStub();
//             
//             
//             var conferenceTrackManager = new ConferenceTrackManager(consoleDisplay, new TextFileInputCollector(pathValidator, consoleDisplay), new TextFileInputProcessor(talkValidator), trackGenerator );
//             //Act
//             
//             conferenceTrackManager.ManageTracks();
//             
//             //Assert
//             //Assert.Empty(consoleDisplay.Messages); 
//             
//             //acceptance tests
//             
//         }
//     }
//
//     public class ConsoleDipslayStub : IDisplay  //Can also do with moq 
//     {
//         public List<string> Messages = new List<string>();
//         public void Display(string message)
//         {
//             Messages.Add(message);
//         }
//
//         public void Display(List<Track> tracks)
//         {
//             throw new NotImplementedException();
//         }
//
//         public void DisplayError(string error)
//         {
//             throw new NotImplementedException();
//         }
//
//         public string ReadDisplay()
//         {
//             throw new NotImplementedException();
//         }
//     }
// }