using System;
using Xunit;

namespace Calculator.Tests
{
    public class StringCalculatorTests
    {
        // where do I put the add method? 
        
        // this one fails when I write second test
        // [Fact]   
        // public void Should_ReturnANumber_When_InputIsAString()
        // {
        //     var stringCalculator = new StringCalculator();
        //
        //     var result = stringCalculator.Add("");
        //     
        //     Assert.Equal(0, result);  
        // }
        
        
        [Fact]
        public void Should_ReturnSameNumber_When_InputIsASingleNumber()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("1");
            
            Assert.Equal(1, result);
        }

        [Fact]
        public void Should_ReturnSumOfTheNumbers_When_InputIsTwoNumbers()
        {
            var stringCalculator = new StringCalculator();
            
            var result = stringCalculator.Add("1,2");
            
            Assert.Equal(3, result);
        }

        [Fact]
        public void Should_ReturnSumOfTheNumbers_When_InputIsMultipleNumbers()
        {
            
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("3,5,3,9");
            
            Assert.Equal(20, result);
        }
        
        
        
        
        
    }
}
