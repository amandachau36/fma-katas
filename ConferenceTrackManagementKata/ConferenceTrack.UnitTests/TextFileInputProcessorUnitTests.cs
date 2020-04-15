using ConferenceTrack.Client;
using Newtonsoft.Json;
using Xunit;

namespace ConferenceTrack.UnitTests
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
            
            var processedTalkStr = JsonConvert.SerializeObject(processedTalk);
            var expectedTalkStr = JsonConvert.SerializeObject(expectedTalk);

        }
        
        // [Fact]
        // public void It_Should_Return_ConferenceTalksGroupedByDuration_When_Given_AnArrayOfConferenceTalks()
        // {
        //     //arrange
        //     var textFileInputCollector = new TextFileInputCollector(); //TODO: relative path?
        //     var talks = textFileInputCollector.Collect(@"/Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/Input/OriginalTestInput.txt");
        //     var textFileInputProcessor = new TextFileInputProcessorUnitTests();
        //
        //     //act
        //     textFileInputProcessor.Process(talks);
        //
        //     //assert
        //     var testNumberOfTalksByDuration = new Dictionary<int, int>
        //     {
        //         {60,  } 
        //     }
        //     foreach (var (key, value) in testConferenceTalksGroupedByDuration)
        //     {
        //         
        //     }
        //   
        // }
    }
}

// "Writing Fast Tests Against Enterprise Rails 60min",
// "Communicating Over Distance 60min",
// "Rails Magic 60min",
// "Ruby on Rails: Why We Should Move On 60min",
// "Ruby on Rails Legacy App Maintenance 60min",
//
// "Overdoing it in Python 45min",
// "Ruby Errors from Mismatched Gem Versions 45min",
// "Common Ruby Errors 45min",
// "Accounting-Driven Development 45min",
// "Pair Programming vs Noise 45min",
// "Pair Programming vs Noise 45min",
// "Clojure Ate Scala (on my project) 45min",
//
// "Lua for the Masses 30min",
// "Woah 30min",
// "Sit Down and Write 30min",
// "Programming in the Boondocks of Seattle 30min",
// "Ruby vs. Clojure for Back-End Development 30min",
// "A World Without HackerNews 30min",
// "User Interface CSS in Rails Apps 30min"
//
// "Rails for Python Developers lightning",







