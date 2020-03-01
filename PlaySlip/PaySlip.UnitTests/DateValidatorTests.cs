using System;
using NUnit.Framework;
using PlaySlip.Application;

namespace PaySlip.UnitTests
{
    
    public class DateValidatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test] 
        public void IsValid_InvalidStartDate_ReturnsFalse()
        {
            var dateValidator = new DateValidator();
        
            var startDate = "Aug 50, 2017";
        
            var result = dateValidator.IsValid(startDate, null);
            
            Assert.AreEqual( false, result);
        }
        
        
        [Test] 
        public void IsValid_ValidStartDate_ReturnsTrue()
        {
            var dateValidator = new DateValidator();

            var startDate = "Aug 1, 2017";

            var result = dateValidator.IsValid(startDate, null);
            
            Assert.AreEqual( true, result);
        }
        
        [Test] 
        public void IsValid_StartDateIsAfterEndDate_ReturnsFalse()
        {
            var dateValidator = new DateValidator();

            var startDate = "Aug 1, 2017";

            var endDate = "Jul 1, 2017";

            var result = dateValidator.IsValid(endDate, startDate);
            
            Assert.AreEqual( false, result);
        }
        
        [Test] 
        public void IsValid_ValidStartAndEndDates_ReturnsTrue()
        {
            var dateValidator = new DateValidator();

            var startDate = "Aug 1, 2017";

            var endDate = "Aug 31, 2017";

            var result = dateValidator.IsValid(endDate, startDate);
            
            Assert.AreEqual( true, result);
        }
        
    }
}