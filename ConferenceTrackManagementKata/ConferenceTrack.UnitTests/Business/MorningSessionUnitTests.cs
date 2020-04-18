using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ConferenceTrack.Business;
using ConferenceTrack.Client;
using ConferenceTrack.Client.InputCollector;
using ConferenceTrack.Client.InputProcessor;
using Newtonsoft.Json;
using Xunit;

namespace ConferenceTrack.UnitTests.Business
{
    public class MorningSessionUnitTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        
        public void It_Should_Return_AListOfTalksThatFitIntoTheMorningSession_Given_AListOfTalks(List<Talk> availableTalks, List<string> expectedAllocatedTalks)
        {
            //arrange
            var morningSession = new MorningSessionAllocator(new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0)); 
            
            //act
            var talksAllocatedToAMorningSession = morningSession.AllocateTalks(availableTalks);
            
            //assert
            Assert.Equal(expectedAllocatedTalks, talksAllocatedToAMorningSession.Select(x => x.TalkTitle));
        }
        
        public static IEnumerable<object[]> Data => new List<object[]>()
        {
            new object[]
            {
                new List<Talk> {
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
                },
                new List<string> {
                    "Writing Fast Tests Against Enterprise Rails 60min",
                    "Communicating Over Distance 60min",
                    "Rails Magic 60min",
                }
            },
            
            new object[]
            {
                new List<Talk>
                {
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
                },
                new List<string>
                {
                    "Ruby on Rails: Why We Should Move On 60min",
                    "Ruby on Rails Legacy App Maintenance 60min",
                    "Overdoing it in Python 45min",
                    "Rails for Python Developers lightning"
                }
            }
        };
        
        [Fact]
        public void It_Should_Update_IsAllocated_ToTrue_AfterAllocatingATalk()
        {
            //arrange
            var talks = new List<Talk>
            {
                new Talk("Ruby on Rails: Why We Should Move On 60min", 60),
                new Talk("Rails for Python Developers lightning", 5)
            };
            
            var morningSession = new MorningSessionAllocator(new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0)); 
            
            //act
            var talksAllocatedToAMorningSession = morningSession.AllocateTalks(talks);
            
            //assert
            foreach (var talk in talksAllocatedToAMorningSession)
            {
                Assert.True(talk.IsAllocated);
            }
            
        }
    }
}