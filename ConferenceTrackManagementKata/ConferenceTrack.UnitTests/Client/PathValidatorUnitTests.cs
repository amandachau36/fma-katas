using System.Collections.Generic;
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
            new object[]
            {
                "/Users/amanda.chau/Desktop/payslip_01April2020.pdf",
                false
            },

            new object[] //TODO: make paths relative
            {
                "/Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/bin/Debug/netcoreapp3.1/Input/OriginalTestInput.txt",
                true
            },

            new object[]
            {
                "/Users/amanda.chau/fma/fma-katas/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/bin/Debug/netcoreapp3.1/Input/DoesNotExist.txt",
                false
            },

            new object[]
            {
                "/Users/amanda.chau/fma/fma-cats/ConferenceTrackManagementKata/ConferenceTrack.UnitTests/bin/Debug/netcoreapp3.1/Input/OriginalTestInput.txt",
                false
            }

        };
    }
}
