using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business.Blocks;
using ConferenceTrack.Business.Config;
using ConferenceTrack.Business.Sessions;
using ConferenceTrack.Business.Validators;
using ConferenceTrack.Client;

using Xunit;

namespace ConferenceTrack.UnitTests.Business
{
    public class MorningSessionUnitTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        
        public void It_Should_Return_AListOfTalksThatFitIntoTheMorningSession_Given_AListOfTalks(List<Block> availableTalks, List<string> expectedAllocatedTalks)
        {
            //arrange
            var morningSession = new SessionAllocator(ConfigurationLoader.LoadSessionConfiguration("morningSession.json")); 
            
            //act
            morningSession.AllocateTalksToSession(availableTalks);
            
            //assert
            Assert.Equal(expectedAllocatedTalks, morningSession.Sessions[0].Select(x => x.BlockName));
            
        }
        
        public static IEnumerable<object[]> Data => new List<object[]>()
        {
            new object[]
            {
                new List<Block> {
                    new Block("Writing Fast Tests Against Enterprise Rails 60min", 60),
                    new Block("Communicating Over Distance 60min", 60),
                    new Block("Rails Magic 60min", 60),
                    new Block("Ruby on Rails: Why We Should Move On 60min", 60),
                    new Block("Ruby on Rails Legacy App Maintenance 60min", 60),
                    new Block("Overdoing it in Python 45min", 45),
                    new Block("Ruby Errors from Mismatched Gem Versions 45min", 45),
                    new Block("Common Ruby Errors 45min", 45),
                    new Block("Accounting-Driven Development 45min", 45),
                    new Block("Pair Programming vs Noise 45min", 45),
                    new Block("Clojure Ate Scala (on my project) 45min", 45),
                    new Block("Lua for the Masses 30min", 30),
                    new Block("Woah 30min", 30),
                    new Block("Sit Down and Write 30min", 30),
                    new Block("Programming in the Boondocks of Seattle 30min", 30),
                    new Block("Ruby vs. Clojure for Back-End Development 30min", 30),
                    new Block("A World Without HackerNews 30min", 30),
                    new Block("User Interface CSS in Rails Apps 30min", 30),
                    new Block("Rails for Python Developers lightning", 5)
                },
                new List<string> {
                    "Writing Fast Tests Against Enterprise Rails 60min",
                    "Communicating Over Distance 60min",
                    "Rails Magic 60min",
                    "Lunch"
                }
            },
            
            new object[]
            {
                new List<Block>
                {
                    new Block("Ruby on Rails: Why We Should Move On 60min", 60),
                    new Block("Ruby on Rails Legacy App Maintenance 60min", 60),
                    new Block("Overdoing it in Python 45min", 45),
                    new Block("Ruby Errors from Mismatched Gem Versions 45min", 45),
                    new Block("Common Ruby Errors 45min", 45),
                    new Block("Accounting-Driven Development 45min", 45),
                    new Block("Pair Programming vs Noise 45min", 45),
                    new Block("Clojure Ate Scala (on my project) 45min", 45),
                    new Block("Lua for the Masses 30min", 30),
                    new Block("Woah 30min", 30),
                    new Block("Sit Down and Write 30min", 30),
                    new Block("Programming in the Boondocks of Seattle 30min", 30),
                    new Block("Ruby vs. Clojure for Back-End Development 30min", 30),
                    new Block("A World Without HackerNews 30min", 30),
                    new Block("User Interface CSS in Rails Apps 30min", 30),
                    new Block("Rails for Python Developers lightning", 5)
                },
                new List<string>
                {
                    "Ruby on Rails: Why We Should Move On 60min",
                    "Ruby on Rails Legacy App Maintenance 60min",
                    "Overdoing it in Python 45min",
                    "Rails for Python Developers lightning",
                    "Lunch"
                }
            }
        };
        
        [Fact]
        public void It_Should_Update_IsAllocated_ToTrue_AfterAllocatingATalk()
        {
            //arrange
            var talks = new List<Block>
            {
                new Block("Ruby on Rails: Why We Should Move On 60min", 60),
                new Block("Rails for Python Developers lightning", 5)
            };
            
            var morningSession = new SessionAllocator(ConfigurationLoader.LoadSessionConfiguration("morningSession.json"));  
            
            //act
            morningSession.AllocateTalksToSession(talks);
            
            //assert
            foreach (var talk in morningSession.Sessions[0])
            {
                Assert.True(talk.IsAllocated);
            }
            
        }
        
        [Fact]
        public void It_Should_Return_CorrectTimesForTalks_When_Given_AListOfTalks()
        {
            //arrange
            var talks = new List<Block>
            {
                new Block("Ruby on Rails: Why We Should Move On 60min", 60),
                new Block("Ruby on Rails Legacy App Maintenance 60min", 60),
                new Block("Overdoing it in Python 45min", 45),
                new Block("Ruby Errors from Mismatched Gem Versions 45min", 45),
                new Block("Rails for Python Developers lightning", 5)
            };
            
            var morningSession = new SessionAllocator(ConfigurationLoader.LoadSessionConfiguration("morningSession.json"));  
            
            //act
            morningSession.AllocateTalksToSession(talks);
            
            //assert
            var expectedTalkTimes = new List<TimeSpan>
            {
                new TimeSpan(9, 0, 0),
                new TimeSpan(10, 0, 0),
                new TimeSpan(11, 0, 0),
                new TimeSpan(11, 45, 0),
                new TimeSpan(12, 0, 0),
                
            };

            var actualTalkTimes = morningSession.Sessions[0].Select(x => x.TimeSlot);
            
            Assert.True(actualTalkTimes.SequenceEqual(expectedTalkTimes));
            
        }
    }
}