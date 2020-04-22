using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ConferenceTrack.Client.InputValidator;
using Xunit;

namespace ConferenceTrack.UnitTests.Client
{
    public class PathValidatorUnitTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void It_Should_ValidatePath(string path, bool expectedIsValid)
        {
            //arrange
            var pathValidator = new PathValidator();

            //act
            var isValid = pathValidator.IsValid(path);

            //assert
            Assert.Equal(expectedIsValid, isValid);
        }
        
      

        public static IEnumerable<object[]> Data => new List<object[]>()
        {
            new object[] //TODO: why can it only see the last two? 
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "DoesNotExist.txt"),
                //"/Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/bin/Debug/netcoreapp3.1/Input/DoesNotExist.txt",
                //Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Input/DoesNotExist.txt"),
                false
            },
            
            new object[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "In", "OriginalTestInput.txt"),
                //"/Users/amanda.chau/fma/fma-cats/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/bin/Debug/netcoreapp3.1/Input/OriginalTestInput.txt",
                //Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"In/OriginalTestInput.txt"),
                false
            },
            
            new object[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test.pdf"),
                //Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Input/test.pdf"),
                //"/Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/Input/test.pdf",
                false
            },

            new object[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "OriginalTestInput.txt"),
               
                //"/Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/bin/Debug/netcoreapp3.1/Input/OriginalTestInput.txt",
                //Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Input/OriginalTestInput.txt"),
                true
            },

        };
    }
}
