using System;
using System.ComponentModel.DataAnnotations;
using Xunit;


namespace TDD.tests
{
    public class CardTests
    {
        [Fact]
        public void When_ToppingUpTheCard_Expect_TopUpValue()
        {
            //arrange
            var card = new Card();

            //act
            card.TopUp(10);
            
            //assert
            Assert.Equal(10, card.Total);
        }

        [Fact]
        public void When_TappingOn_Expect_CardToHaveMachineId()
        {
            //arrange
            var card = new Card();
            var machineId = Guid.Parse("c17479ba-7c57-4e73-a65c-461e230cde9d");
            var tapOnTime = new DateTime(2020, 01, 04);
            var tapOn = new Tap(machineId, tapOnTime );
            
            //act
            card.TapOn(tapOn);
            
            //assert
            Assert.Equal(machineId,card._TapOn.MachineId);
            
        }

        [Fact]
        public void When_TappingOn_Expect_CardToHaveTapOnTime()
        {
            //arrange
            var card = new Card();
            var machineId = Guid.Parse("c17479ba-7c57-4e73-a65c-461e230cde9d");
            var tapOnTime = new DateTime(2020, 2, 20);
            var tapOn = new Tap(machineId, tapOnTime);
            
            //act
            card.TapOn(tapOn);
            
            //assert
            Assert.Equal( tapOnTime, card._TapOn.Time );
        }

        [Fact]
        public void When_TappingOff_Expect_CardToHaveMachineId()
        {
            //arrange
            var card = new Card();
            var machineId = Guid.Parse("be2f9946-3bc3-47fc-ae3c-ab3bf261bbdf");
            var tapOffTime = new DateTime(2020, 2, 20,2,2,2);
            var tapOff = new Tap(machineId, tapOffTime);
 
            //act
            card.TapOff(tapOff);
            
            //assert
            Assert.Equal(Guid.Parse("be2f9946-3bc3-47fc-ae3c-ab3bf261bbdf"), card._TapOff.MachineId);
        }

        [Fact]
        public void When_TappingOff_Expect_CardToHaveTapOffTime()
        {
            //arrange
            var card = new Card();
            var machineId = Guid.Parse("be2f9946-3bc3-47fc-ae3c-ab3bf261bbdf");
            var tapOffTime = new DateTime(2020, 2, 20,2,2,2);
            var tapOff = new Tap(machineId, tapOffTime);
            
            
            //act
            card.TapOff(tapOff);
            
            //assert
            Assert.Equal(tapOffTime, card._TapOff.Time);
        }

        [Fact]
        public void When_TappingOff_Expect_CardToDeductFare()
        {
            //arrange 
            var card = new Card();
            var machineId = Guid.Parse("be2f9946-3bc3-47fc-ae3c-ab3bf261bbdf");
            var tapOffTime = new DateTime(2020, 2, 20,2,2,2);
            var tapOff = new Tap(machineId, tapOffTime);
            
            
            //act
            card.TapOff(tapOff);

            //assert
            Assert.Equal(7, card.Total);
            
        }




    }
    
}