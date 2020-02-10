using NUnit.Framework;

namespace Exercise1.UnitTests
{
    public class FizzTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FizzBuzz_NumberIs3_ReturnsFizz()
        {
            //Arrange
            var fizz = new Fizz();
            
            //Act
            var result = fizz.FizzBuzz(3);

            //Assert
            Assert.AreEqual("Fizz", result);
        }
        
        [Test]
        public void FizzBuzz_NumberIs5_ReturnsBuzz()
        {
            //Arrange
            var fizz = new Fizz();
            
            //Act
            var result = fizz.FizzBuzz(5);

            //Assert
            Assert.AreEqual("Buzz", result);
        }
        
        [Test]
        public void FizzBuzz_NumberIs15_ReturnsFizzBuzz()
        {
            //Arrange
            var fizz = new Fizz();
            
            //Act
            var result = fizz.FizzBuzz(15);

            //Assert
            Assert.AreEqual("FizzBuzz", result);
        }

        [Test]
        public void FizzBuzz_NumberIs1_Returns1()
        {
            //Arrange
            var fizz = new Fizz();
            
            //Act
            var result = fizz.FizzBuzz(1);
            
            //Assert 
            Assert.AreEqual("1", result);
        }
    }
}

//Fizz Buzz Kata
//Write a program that prints the numbers from 1 to 100. But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. For numbers which are multiples of both three and five print “FizzBuzz”."

//Example Output
//1
//2
//Fizz
//4
//Buzz
//Fizz
//7
//etc.

// go back to throw error if input is not a number