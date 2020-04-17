using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ConferenceTrack.Client;
using ConferenceTrack.Client.InputCollector;
using ConferenceTrack.Client.InputProcessor;
using Newtonsoft.Json;
using Xunit;

namespace ConferenceTrack.UnitTests.Client
{
    public class TextFileInputProcessorUnitTests 
    {

        [Fact]
        public void It_Should_Return_ATalkObject_Given_AValidTalk()
        {
            //arrange
            var textFileInputProcessor = new TextFileInputProcessor();
            var talk = new string[] {"Writing Fast Tests Against Enterprise Rails 60min"};
            
            //act
            var processedTalk = textFileInputProcessor.Process(talk);
            
            //assert
            var expectedTalk = new Talk("Writing Fast Tests Against Enterprise Rails 60min", 60);
            
            var processedTalkStr = JsonConvert.SerializeObject(processedTalk[0]);
            var expectedTalkStr = JsonConvert.SerializeObject(expectedTalk);
            
            Assert.Equal( expectedTalkStr, processedTalkStr);
        
        }
        
        
        [Fact]
        public void It_Should_Return_ATalkObjectWithADurationOf5Min_Given_ALighteningTalk()
        {
            //arrange
            var textFileInputProcessor = new TextFileInputProcessor();
            var talk = new string[] {"Rails for Python Developers lightning"};
            
            //act
            var processedTalk = textFileInputProcessor.Process(talk);
            
            //assert
            var expectedTalk = new Talk("Rails for Python Developers lightning", 5);
            
            var processedTalkStr = JsonConvert.SerializeObject(processedTalk[0]);
            var expectedTalkStr = JsonConvert.SerializeObject(expectedTalk);
            
            Assert.Equal( expectedTalkStr, processedTalkStr);
        }
        
        
        [Fact]
        public void It_Should_Return_AListTalksOrderedByTalkDuration_Given_AListOfTalks()
        {
            //arrange
            var textFileInputCollector = new TextFileInputCollector();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"./Input/OriginalTestInput.txt");
            var talks = textFileInputCollector.Collect(path);
            
            var textFileInputProcessor = new TextFileInputProcessor();
            
            //act
            var processedTalks = textFileInputProcessor.Process(talks);
            
            //assert
            var expectedTalksOrderedByDuration = new List<Talk>
            {
                new Talk("Writing Fast Tests Against Enterprise Rails 60min", 60),
                new Talk("Communicating Over Distance 60min", 60),
                new Talk("Rails Magic 60min", 60),
                new Talk("Ruby on Rails: Why We Should Move On 60min", 60),
                new Talk("Ruby on Rails Legacy App Maintenance 60min", 60),
                new Talk("Overdoing it in Python 45min", 45),
                new Talk("Ruby Errors from Mismatched Gem Versions 45min", 45),
                new Talk("Common Ruby Errors 45min", 45),
                new Talk("Accounting-Driven Development 45min", 45),
                new Talk("Pair Programming vs Noise 45min", 45),
                new Talk("Clojure Ate Scala (on my project) 45min", 45),
                new Talk("Lua for the Masses 30min", 30),
                new Talk("Woah 30min", 30),
                new Talk("Sit Down and Write 30min", 30),
                new Talk("Programming in the Boondocks of Seattle 30min", 30),
                new Talk("Ruby vs. Clojure for Back-End Development 30min", 30),
                new Talk("A World Without HackerNews 30min", 30),
                new Talk("User Interface CSS in Rails Apps 30min", 30),
                new Talk("Rails for Python Developers lightning", 5)
            };
            
            var processedTalkStr = JsonConvert.SerializeObject(processedTalks);
            var expectedTalkStr = JsonConvert.SerializeObject(expectedTalksOrderedByDuration);
            Assert.Equal( expectedTalkStr, processedTalkStr);
        
        }

    }
}







