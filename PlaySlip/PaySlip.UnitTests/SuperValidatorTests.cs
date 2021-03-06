using System.Collections.Generic;
using NUnit.Framework;
using PlaySlip.Application;

namespace PaySlip.UnitTests
{
    
    public class SuperValidatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsValid_SuperGreaterThanValidRange_ReturnsFalse()
        {
            var superValidator = new SuperValidator();

            var superRate = new List<string>() {"88"};

            var result = superValidator.IsValid(superRate);
            
            Assert.AreEqual( false, result);
        }
        
        [Test]
        public void IsValid_SuperLessThanValidRange_ReturnsFalse()
        {
            var superValidator = new SuperValidator();

            var superRate = new List<string>() {"-4"};

            var result = superValidator.IsValid(superRate);
            
            Assert.AreEqual( false, result);
        }
        
        [Test]
        public void IsValid_SuperWithinValidRange_ReturnsTrue()
        {
            var superValidator = new SuperValidator();

            var superRate = new List<string>() {"9"};

            var result = superValidator.IsValid(superRate);
            
            Assert.AreEqual( true, result);
        }
        
        [Test]
        public void IsValid_InvalidSuper_ReturnsFalse()
        {
            var superValidator = new SuperValidator();

            var superRate = new List<string>() {"cat"};

            var result = superValidator.IsValid(superRate);
            
            Assert.AreEqual( false, result);
        }
        

        
        
        
    

    }
}