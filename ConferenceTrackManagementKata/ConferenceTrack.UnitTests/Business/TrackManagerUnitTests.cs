using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceTrack.Business.Blocks;
using ConferenceTrack.Business.Config;
using ConferenceTrack.Business.Sessions;
using ConferenceTrack.Business.Tracks;
using ConferenceTrack.Business.Validators;
using ConferenceTrack.Client;
using Xunit;

namespace ConferenceTrack.UnitTests.Business
{
    public class TrackManagerUnitTests
    {
        [Theory]
        [MemberData(nameof(Data1))]
        public void It_Should_Return_AListOfTalksThatFitIntoTheMorningSessions_Given_AListOfTalks(List<Block> talks,
            List<List<string>> expectedMorningSessions)
        {
            //arrange
            var morningSession = new SessionAllocator(ConfigurationLoader.LoadSessionConfiguration("morningSession.json"), new TalkDurationValidator()); 
            var afternoonSession = new SessionAllocator(ConfigurationLoader.LoadSessionConfiguration("afternoonSession.json"), new TalkDurationValidator());
            var trackGenerator = new TrackGenerator(2, new List<SessionAllocator> {morningSession, afternoonSession});
        
            //act
            trackGenerator.GenerateTracks(talks);
        
            //assert
            var morningSessions = trackGenerator.SessionAllocators[0].Sessions
                .Select(s => s.Select(t => t.BlockName).ToList()).ToList();
        
            Assert.Equal(expectedMorningSessions, morningSessions);
        }
        
        public static IEnumerable<object[]> Data1 => new List<object[]>
        {
            new object[]
            {
                new List<Block>
                {
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
                new List<List<string>>
                {
                    new List<string>
                    {
                        "Writing Fast Tests Against Enterprise Rails 60min",
                        "Communicating Over Distance 60min",
                        "Rails Magic 60min",
                        "Lunch"
                    },
                    new List<string>
                    {
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
        public void It_Should_Return_AListOfTalksThatFitIntoTheAfternoonSession_Given_AListOfTalks(List<Block> talks,
            List<List<string>> expectedAfternoonSessions)
        {
            //arrange
            var morningSession = new SessionAllocator(ConfigurationLoader.LoadSessionConfiguration("morningSession.json"), new TalkDurationValidator()); 
            var afternoonSession = new SessionAllocator(ConfigurationLoader.LoadSessionConfiguration("afternoonSession.json"), new TalkDurationValidator());
            var trackGenerator = new TrackGenerator(2, new List<SessionAllocator> {morningSession, afternoonSession});

            //act
            trackGenerator.GenerateTracks(talks);

            //assert
            var afternoonSessions = trackGenerator.SessionAllocators[1].Sessions
                .Select(s => s.Select(t => t.BlockName).ToList()).ToList();

            Assert.Equal(expectedAfternoonSessions, afternoonSessions);
        }

        public static IEnumerable<object[]> Data2 => new List<object[]>
        {
            new object[]
            {
                new List<Block>
                {
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
                new List<List<string>>
                {
                    new List<string>
                    {
                        "Ruby Errors from Mismatched Gem Versions 45min",
                        "Common Ruby Errors 45min",
                        "Accounting-Driven Development 45min",
                        "Pair Programming vs Noise 45min",
                        "Clojure Ate Scala (on my project) 45min",
                        "Networking Event"
                    },
                    new List<string>
                    {
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


        [Theory]
        [MemberData(nameof(Data3))]
        public void It_Should_Return_ValidTracks_Given_AListOfTalks(List<Block> talks, List<string> expectedFirstTrack)
        {
            //arrange
            var morningSession = new SessionAllocator(ConfigurationLoader.LoadSessionConfiguration("morningSession.json"), new TalkDurationValidator()); 
            var afternoonSession = new SessionAllocator(ConfigurationLoader.LoadSessionConfiguration("afternoonSession.json"), new TalkDurationValidator());
            var trackGenerator = new TrackGenerator(2, new List<SessionAllocator> {morningSession, afternoonSession});

            //act
            var tracks = trackGenerator.GenerateTracks(talks);

            //assert
            var actualFirstTrack = tracks[0].Blocks.Select(t => t.BlockName).ToList();

            Assert.Equal(expectedFirstTrack, actualFirstTrack);
        }


        public static IEnumerable<object[]> Data3 => new List<object[]>
        {
            new object[]
            {
                new List<Block>
                {
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
                new List<string>
                {
                    "Writing Fast Tests Against Enterprise Rails 60min",
                    "Communicating Over Distance 60min",
                    "Rails Magic 60min",
                    "Lunch",
                    "Ruby Errors from Mismatched Gem Versions 45min",
                    "Common Ruby Errors 45min",
                    "Accounting-Driven Development 45min",
                    "Pair Programming vs Noise 45min",
                    "Clojure Ate Scala (on my project) 45min",
                    "Networking Event"
                }
            }
        };
        
        [Theory]
        [MemberData(nameof(Data4))] //TODO: only use Theory when necessary
        public void It_Should_Allocate_All_Talks_Given_AListOfTalks(List<Block> talks)
        {
            //arrange
            var morningSession = new SessionAllocator(ConfigurationLoader.LoadSessionConfiguration("morningSession.json"), new TalkDurationValidator()); 
            var afternoonSession = new SessionAllocator(ConfigurationLoader.LoadSessionConfiguration("afternoonSession.json"), new TalkDurationValidator());
            var trackGenerator = new TrackGenerator(2, new List<SessionAllocator> {morningSession, afternoonSession});

            //act
            var tracks = trackGenerator.GenerateTracks(talks);

            //assert

            foreach (var block in tracks.SelectMany(track => track.Blocks))
            {
                Assert.True(block.IsAllocated);
            }
            
        }


        public static IEnumerable<object[]> Data4 => new List<object[]>
        {
            new object[]
            {
                new List<Block>
                {
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
                }
            }

        };
    }
}

//Can use a mix of theory and fact