using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business;
using ConferenceTrack.Client;
using Newtonsoft.Json;
using Xunit;

namespace ConferenceTrack.UnitTests.Business
{
    public class AfternoonSessionUnitTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        
        public void It_Should_Return_AListOfTalksThatFitIntoTheAfternoonSession_Given_AListOfTalks(List<Talk> availableTalks, List<string> expectedAllocatedTalks)
        {
            //arrange
            var afternoonSession = new AfternoonSessionAllocator(new TimeSpan(1, 0, 0), new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0)); 
            
        
            
            //act
           afternoonSession.AllocateTalksToSession(availableTalks);
            
            //assert
            Assert.Equal(expectedAllocatedTalks, afternoonSession.Sessions[0].Select(x => x.TalkTitle));
        }
        
        public static IEnumerable<object[]> Data => new List<object[]>()
        {
            new object[]
            {
                new List<Talk> {
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
                },
                new List<string> {
                    "Ruby Errors from Mismatched Gem Versions 45min",
                    "Common Ruby Errors 45min",
                    "Accounting-Driven Development 45min",
                    "Pair Programming vs Noise 45min",
                    "Clojure Ate Scala (on my project) 45min",
                    "Networking Event"
                }
            },
            
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
            
            var afternoonSession = new AfternoonSessionAllocator(new TimeSpan(1, 0, 0), new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0));
            
            //act
           afternoonSession.AllocateTalksToSession(talks);
            
            //assert
            foreach (var talk in afternoonSession.Sessions[0])
            {
                Assert.True(talk.IsAllocated);
            }
            
        }
        
        [Fact]
        public void It_Should_Return_CorrectTimesForTalks_When_Given_AListOfTalks()
        {
            //arrange
            var talks = new List<Talk>
            {
                new Talk("Ruby on Rails: Why We Should Move On 60min", 60),
                new Talk("Ruby on Rails Legacy App Maintenance 60min", 60),
                new Talk("Overdoing it in Python 45min", 45),
                new Talk("Ruby Errors from Mismatched Gem Versions 45min", 45),
            };
            
            var afternoonSession = new AfternoonSessionAllocator(new TimeSpan(1, 0, 0), new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0));
            
            //act
            afternoonSession.AllocateTalksToSession(talks);
            
            //assert
            var expectedTalkTimes = new List<TimeSpan>
            {
                new TimeSpan(1, 0, 0),
                new TimeSpan(2, 0, 0),
                new TimeSpan(3, 0, 0),
                new TimeSpan(3, 45, 0),
                new TimeSpan(5, 0, 0)
            };

            var actualTalkTimes = afternoonSession.Sessions[0].Select(x => x.TalkTime);

            Assert.True(actualTalkTimes.SequenceEqual(expectedTalkTimes));

        }
    }
}