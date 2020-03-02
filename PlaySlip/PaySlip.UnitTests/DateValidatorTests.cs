using System;
using System.Collections.Generic;
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

            var dates = new List<string>() {"Aug 10, 2017", "Aug 50, 2017"};
            
            var result = dateValidator.IsValid(dates);
            
            Assert.AreEqual( false, result);
        }
        
        
        [Test] 
        public void IsValid_StartDateIsAfterEndDate_ReturnsFalse()
        {
            var dateValidator = new DateValidator();

            var startDate = "Aug 1, 2017";

            var endDate = "Jul 1, 2017";
       
            var dates = new List<string>() { startDate, endDate};

            var result = dateValidator.IsValid(dates);
            
            Assert.AreEqual( false, result);
        }
        
        [Test] 
        public void IsValid_ValidStartAndEndDates_ReturnsTrue()
        {
            var dateValidator = new DateValidator();

            var startDate = "Aug 1, 2017";

            var endDate = "Aug 31, 2017";
            
            var dates = new List<string>() { startDate, endDate};

            var result = dateValidator.IsValid(dates);
            
            Assert.AreEqual( true, result);
        }
        
    }
}