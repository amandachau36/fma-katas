using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business;
using ConferenceTrack.Client;
using Xunit;

namespace ConferenceTrack.UnitTests.Business
{
    public class TrackManagerUnitTests
    {
        [Theory]
        [MemberData(nameof(Data1))]
        public void It_Should_Return_AListOfTalksThatFitIntoTheMorningSessions_Given_AListOfTalks(List<Talk> talks, List<List<string>> expectedMorningSessions)
        {
            //arrange
             var morningSession = new MorningSessionAllocator(new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0)); 
             var afternoonSession = new AfternoonSessionAllocator(new TimeSpan(1, 0, 0), new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0)); 
             var trackManager = new TrackManager(2, talks, new List<ISessionAllocator>{morningSession, afternoonSession});
             
             //act
             trackManager.GenerateAllSessions();
            
             //assert
             var morningSessions  = trackManager.SessionAllocators[0].Sessions.Select(s => s.Select(t => t.TalkTitle).ToList()).ToList();

             Assert.Equal( expectedMorningSessions, morningSessions);
        }
        
        public static IEnumerable<object[]> Data1 => new List<object[]>
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
                new List<List<string>> {
                    new List<string> {
                        "Writing Fast Tests Against Enterprise Rails 60min",
                        "Communicating Over Distance 60min",
                        "Rails Magic 60min",
                        "Lunch"
                    },
                    new List<string> {
                        "Ruby on Rails: Why We Should Move On 60min",
                        "Ruby on Rails Legacy App Maintenance 60min",
                        "Overdoing it in Python 45min",
                        "Rails for Python Developers lightning",
                        "Lunch"
                    },
                }
            }
        };
        
        [Theory]
        [MemberData(nameof(Data2))]
        public void It_Should_Return_AListOfTalksThatFitIntoTheAfternoonSession_Given_AListOfTalks(List<Talk> talks, List<List<string>> expectedAfternoonSessions)
        {
            //arrange
            var morningSession = new MorningSessionAllocator(new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0)); 
            var afternoonSession = new AfternoonSessionAllocator(new TimeSpan(1, 0, 0), new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0)); 
            var trackManager = new TrackManager(2, talks, new List<ISessionAllocator>{morningSession, afternoonSession});
             
            //act
            trackManager.GenerateAllSessions();
            
            //assert
            var afternoonSessions  = trackManager.SessionAllocators[1].Sessions.Select(s => s.Select(t => t.TalkTitle).ToList()).ToList();
            
            Assert.Equal( expectedAfternoonSessions, afternoonSessions);
        }
        
  
        
        public static IEnumerable<object[]> Data2 => new List<object[]>
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
                new List<List<string>> {
                    new List<string> {
                        "Ruby Errors from Mismatched Gem Versions 45min",
                        "Common Ruby Errors 45min",
                        "Accounting-Driven Development 45min",
                        "Pair Programming vs Noise 45min",
                        "Clojure Ate Scala (on my project) 45min",
                        "Networking Event"
                    },
                    new List<string> {
                        "Lua for the Masses 30min",
                        "Woah 30min",
                        "Sit Down and Write 30min",
                        "Programming in the Boondocks of Seattle 30min",
                        "Ruby vs. Clojure for Back-End Development 30min",
                        "A World Without HackerNews 30min",
                        "User Interface CSS in Rails Apps 30min",
                        "Networking Event"
                    },
                }
            },
        };
        
    
    }
}