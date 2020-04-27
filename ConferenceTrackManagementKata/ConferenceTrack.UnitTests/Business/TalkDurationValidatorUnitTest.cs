using System.Collections.Generic;
using ConferenceTrack.Business.Blocks;
using ConferenceTrack.Business.Validators;
using ConferenceTrack.Client.InputValidator;
using Xunit;

namespace ConferenceTrack.UnitTests.Client
{
    public class TalkDurationValidatorUnitTest 
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void It_Should_ValidateTalkDuration(Block talk, bool expectedIsValid)
        {
            //arrange
            var talkDurationValidator = new TalkDurationValidator();
        
            //act
            var isValid = talkDurationValidator.IsValid(talk, 180);
        
            //assert
            Assert.Equal(expectedIsValid, isValid) ;
        }
        
        public static IEnumerable<object[]> Data => new List<object[]>()
        {
            new object[]
            {
                new Block("Writing Fast Tests Against Enterprise Rails 60min", 60), 
                true
            },
        
            new object[]
            {
                new Block("Writing Fast Tests Against Enterprise Rails 200min", 200),
                false
            },
            
        
        };
    }
}