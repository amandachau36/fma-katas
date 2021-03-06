using System;
using Xunit;

namespace Calculator.Tests
{
    public class StringCalculatorTests
    {
        
        
        [Fact]
        public void Add_Should_ReturnSameNumber_When_InputIsASingleNumber() //one naming convention - but possible code smell  
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("1");
            
            Assert.Equal(1, result);
        }

        [Fact]
        public void Should_ReturnSumOfNumbers_When_TwoNumbersAreSeparatedByAComma() //Sometimes you don't care what the method is 
        {
            var stringCalculator = new StringCalculator();
            
            var result = stringCalculator.Add("1,2");
            
            Assert.Equal(3, result);
        }

        [Fact]
        public void Should_ReturnSumOfNumbers_When_MultipleNumbersAreSeparatedByCommas()
        {
            
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("3,5,3,9");
            
            Assert.Equal(20, result);
        }
        
        [Fact]
        public void Should_ReturnSumOfNumbers_When_NumbersAreSeparatedByNewLineBreaksOrCommas()
        {
            
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("1,2\n3");
            
            Assert.Equal(6, result);
        }


        [Fact]
        public void Should_ReturnSumOfNumbers_When_DifferentDelimitersAreUsed()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("//;\n1;2");
            
            Assert.Equal(3, result);
        }
        
  

        [Fact]
        public void Should_ThrowExceptionNegativesNotAllowed_When_NumberIsNegative()
        {
            var stringCalculator = new StringCalculator();

            var exception = Assert.Throws<NegativesNotAllowedException>(() => stringCalculator.Add("-1,2,-3"));
            
            Assert.Equal("Negatives not allowed: -1, -3", exception.Message);
            
        }

        [Fact]
        public void Should_ReturnSumThatIgnoresNumber_When_NumberIsGreaterOrEqualTo1000()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("1000,1001,2");
            
            Assert.Equal(2, result);
        }


        [Fact]
        public void Should_ReturnSumOfNumbers_When_DelimitersAreOfAnyLength()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("//[***]\n1***2***3");
            
            Assert.Equal(6, result);
        }

        [Fact]
        public void Should_ReturnSumOfNumbers_When_MultipleDelimitersAreUsed()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("//[*][%]\n1*2%3");
            
            Assert.Equal(6, result);
        }


        [Fact]
        public void Should_ReturnSumOfNumbers_When_MultipleDelimitersOfDifferentLengthsAreUsed()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("//[***][#][%]\n1***2#3%4");
            
            Assert.Equal(10, result);
        }

        [Fact] public void Should_ReturnSumOfNumbers_When_DelimitersIncludeNumbersButNotAtEdges()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("//[*1*][%]\n1*1*2%3");
            
            Assert.Equal(6, result);
        }

        [Fact]
        public void Should_Throw_DelimiterCannotHaveNumberOnTheEdgeException_When_NumberIsOnEdge()
        {
            var stringCalculator = new StringCalculator();

            var exception = Assert.Throws<DelimiterCannotHaveNumberOnTheEdgeException>(() => stringCalculator.Add("//[**1]\n1**12*3"));
            
            Assert.Equal("Delimiter cannot have a number on the edge: **1", exception.Message);
            
        }
    }
}


