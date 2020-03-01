using System;
using NUnit.Framework;


namespace PaySlip.UnitTests
{
  
    public class PaySlipTests  
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculatePayPeriod_ValidStartAndEndDate_ReturnsCorrectPayPeriod()
        {
            //Arrange
            var startDate = new DateTime(2017, 3, 1);
            
            var endDate = new DateTime(2017, 3, 31);
            
            var paySlip = new PlaySlip.Application.PaySlip(startDate, endDate);
            
            //Act
            var result = paySlip.PayPeriod; 
            
                
            //Assert
            var payPeriod = TimeSpan.FromDays(31);
            
            Assert.AreEqual(payPeriod, result);
        }
        
        
        [Test]
        public void CalculateGrossIncome_ValidAnnualSalary_ReturnsCorrectGrossIncome()
        {
            //Arrange 
            var startDate = new DateTime(2017, 3, 1);
            
            var endDate = new DateTime(2017, 3, 31);
            
            var paySlip = new PlaySlip.Application.PaySlip(startDate, endDate);
        
            //Act
            decimal annualSalary = 60050m;  //is writing m necessary when I already have d
            
            paySlip.CalculateGrossIncome(annualSalary);
            
            var result = paySlip.GrossIncome; 
            
            // Assert
            decimal grossIncome = 31m * (60050m / 365m);
            
            Assert.AreEqual(grossIncome, result);
        }

        
        [Test]
        public void CalculateIncomeTax_ValidAnnualSalary_ReturnsCorrectIncomeTax()
        {
            //Arrange 
            var startDate = new DateTime(2017, 3, 1);
           
            var endDate = new DateTime(2017, 3, 31);
         
            var paySlip = new PlaySlip.Application.PaySlip(startDate, endDate);
        
            //Act
            var annualSalary = 60050m;
            
            paySlip.CalculateIncomeTax(annualSalary);
            
            var result = paySlip.IncomeTax; 
            
            // Assert
            decimal incomeTax = (3572m + (60050m - 37000m) * 0.325m) * (31m/ 365m);
            
            Assert.AreEqual(incomeTax, result);
        }

        
       
                
        [Test]
        public void CalculateNetIncome_ReturnsCorrectNetIncome() // not sure what the situation is here 
        {
            //Arrange 
            var startDate = new DateTime(2017, 3, 1);
            
            var endDate = new DateTime(2017, 3, 31);
         
            var paySlip = new PlaySlip.Application.PaySlip(startDate, endDate);
        
            //Act
            decimal annualSalary = 60050m;
            
            paySlip.CalculateGrossIncome(annualSalary);
            
            paySlip.CalculateIncomeTax(annualSalary);
           
            paySlip.CalculateNetIncome();
            
            var result = paySlip.NetIncome;
            
            // Assert
            var netIncome = (annualSalary - (3572m + (60050m - 37000m) * 0.325m)) * (31m/365m);
            
            Assert.AreEqual(Decimal.Round(netIncome), Decimal.Round(result) );
        }

        
                        
        [Test]
        public void CalculateSuper_ValidSuperRate_ReturnsCorrectSuper()  
        {
            //Arrange 
            var startDate = new DateTime(2017, 3, 1);
            
            var endDate = new DateTime(2017, 3, 31);
         
            var paySlip = new PlaySlip.Application.PaySlip(startDate, endDate);
        
            //Act
            var annualSalary = 60050m;
            
            var superRate = 9m;
            
            paySlip.CalculateGrossIncome(annualSalary);
            
            paySlip.CalculateSuper(superRate);
            
            var result = paySlip.Super;
            
            // Assert
            var super = 31m * (60050m / 365m) * superRate / 100m;
            
            Assert.AreEqual(Decimal.Round(super), Decimal.Round(result) );
        }
        
        
    }
}

