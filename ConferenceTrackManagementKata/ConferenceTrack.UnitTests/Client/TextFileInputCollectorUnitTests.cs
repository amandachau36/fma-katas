using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using ConferenceTrack.Client.Display;
using ConferenceTrack.Client.Exceptions;
using ConferenceTrack.Client.InputCollector;
using ConferenceTrack.Client.InputValidator;
using Moq;
using Xunit;

namespace ConferenceTrack.UnitTests.Client
{
    public class TextFileInputCollectorUnitTests
    {
        // [Fact]
        // public void It_Should_Return_AnArrayOfConferenceTalks_When_Given_TalksSeparatedByANewLine() //TODO: this isn't necessary to test
        // {
        //     //arrange
        //     var pathValidator = new PathValidator();
        //     
        //     var textFileInputCollector = new TextFileInputCollector(pathValidator);
        //
        //     var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"./Input/OriginalTestInput.txt");
        //    
        //     //act
        //     var talks = textFileInputCollector.Collect();
        //   
        //
        //     //assert
        //     var expectedTalks = new[]
        //     {
        //         "Writing Fast Tests Against Enterprise Rails 60min",
        //         "Overdoing it in Python 45min",
        //         "Lua for the Masses 30min",
        //         "Ruby Errors from Mismatched Gem Versions 45min",
        //         "Common Ruby Errors 45min",
        //         "Rails for Python Developers lightning",
        //         "Communicating Over Distance 60min",
        //         "Accounting-Driven Development 45min",
        //         "Woah 30min",
        //         "Sit Down and Write 30min",
        //         "Pair Programming vs Noise 45min",
        //         "Rails Magic 60min",
        //         "Ruby on Rails: Why We Should Move On 60min",
        //         "Clojure Ate Scala (on my project) 45min",
        //         "Programming in the Boondocks of Seattle 30min",
        //         "Ruby vs. Clojure for Back-End Development 30min",
        //         "Ruby on Rails Legacy App Maintenance 60min",
        //         "A World Without HackerNews 30min",
        //         "User Interface CSS in Rails Apps 30min"
        //
        //     };
        //     Assert.True(talks.SequenceEqual(expectedTalks));
        // }
        
        
        [Theory]
        [MemberData(nameof(Data))]
        public void It_Should_Throw_InvalidPathOrFileException_When_Given_AnInvalidPath(string relativePath, string exceptionMessage)
        {
            //arrange
            var mockDisplay = new Mock<IDisplay>();
            mockDisplay.Setup(x => x.ReadDisplay()).Returns(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath));

            var textFileInputCollector = new TextFileInputCollector(new PathValidator(), mockDisplay.Object);

            //act
            Action actual = () => textFileInputCollector.Collect();
            
            //assert
            var exception = Assert.Throws<InvalidPathOrFileException>(actual);
            Assert.Equal( exceptionMessage, exception.Message);
        }
        
        public static IEnumerable<object[]> Data => new List<object[]>()
        {
            new object[]
            {
                @"./Input/DoesNotExist.txt",
                $"Not a valid path or file: {Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"/Input/DoesNotExist.txt")}. \nOnly .txt files are valid"
            },

            new object[]
            {
                @"./In/OriginalTestInput.txt",
                $"Not a valid path or file: {Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"/In/OriginalTestInput.txt")}. \nOnly .txt files are valid"
            },
            
            new object[]
            {
                @"./Input/test.pdf",
                $"Not a valid path or file: {Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"/Input/test.pdf")}. \nOnly .txt files are valid"
            }
            
        };

    }
}