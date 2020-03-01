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
        
            var name = "";
        
            var result = nameValidator.IsValid(name);
            
            Assert.AreEqual( false, result);
        }
        
        [Test] 
        public void IsValid_ValidName_ReturnsTrue()
        {
            var nameValidator = new NameValidator();
        
            var name = "John";
        
            var result = nameValidator.IsValid(name);
            
            Assert.AreEqual( true, result);
        }

    }
}