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
        
      //

      public static IEnumerable<object[]> Data()
      {
          yield return new object[] //run dotnet test  
          {
              Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "DoesNotExist.txt"),
              false
          };

          yield return new object[]
          {
              Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "In", "OriginalTestInput.txt"),
              false
          };

          yield return new object[]
          {
              Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test.pdf"),
              false
          };

          yield return new object[]
          {
              Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "OriginalTestInput.txt"),
              true
          };
          
      }

    }
}
