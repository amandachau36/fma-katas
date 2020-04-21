using System.Collections.Generic;
using ConferenceTrack.Client.InputValidator;
using Xunit;

namespace ConferenceTrack.UnitTests.Client
{
    public class TalkValidatorUnitTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void It_Should_ValidateTalks(string talk, bool expectedIsValid)
        {
            //arrange
            var talkValidator = new TalkValidator();

            //act
            var isValid = talkValidator.IsValid(talk);
            
            //assert
            Assert.Equal(isValid, expectedIsValid);
        }
        
        public static IEnumerable<object[]> Data => new List<object[]>()
        {
            new object[]
            {
                "Writing Fast Tests Against Enterprise Rails",
                false
            },
            
            new object[]
            {
                "Writing Fast Tests Against Enterprise Rails 60min",
                true
            },
            
            new object[]
            {
                "Rails for Python Developers lightning",
                true
            },
            
            new object[]
            {
                "",
                false
            },
            
        };
        
   
    }
}