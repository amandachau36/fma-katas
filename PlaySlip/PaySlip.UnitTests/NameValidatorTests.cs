using System.Collections.Generic;
using NUnit.Framework;
using PlaySlip.Application;

namespace PaySlip.UnitTests
{
  
    public class NameValidatorTests
    {
        [Test] 
        public void IsValid_InvalidName_ReturnsFalse()
        {
            var nameValidator = new NameValidator();
        
            var name = new List<string>() {""};
        
            var result = nameValidator.IsValid(name);
            
            Assert.AreEqual( false, result);
        }
        
        [Test] 
        public void IsValid_ValidName_ReturnsTrue()
        {
            var nameValidator = new NameValidator();

            var name = new List<string>() {"John"};
        
            var result = nameValidator.IsValid(name);
            
            Assert.AreEqual( true, result);
        }

    }
}