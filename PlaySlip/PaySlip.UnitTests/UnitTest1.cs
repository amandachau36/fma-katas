using System;
using NUnit.Framework;
using PlaySlip;

namespace PaySlip.UnitTests
{
  
    public class EmployeeTests  // rename this
                                //  difference files for tests from different classes
                                // do I need to test properties? 
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GenerateFullName_FirstAndLastName_ReturnsBothNames()
        {
            //Arrange
            var firstName = "John";
            var surName = "Doe";
            var annualSalary = 60050;
            var superRate = 9;
            var employee = new Employee(firstName, surName, annualSalary, superRate);
            
            //Act
            var result = employee.GenerateFullName();
                
            //Assert
            Assert.AreEqual("John Doe", result);

        }
        
    }
    
    public class PaySlipTests  
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SetPaymentStartDate_ValidDateString_ReturnsDateTime()
        {
            //Arrange
            var startDate = "Mar 1, 2017";
            var endDate = "Mar 31, 2017";
            var consolePaySlipDisplay = new ConsolePlaySlipDisplay();
            var createPaySlip = new CreatePaySlip(startDate, endDate, consolePaySlipDisplay);
            
            //Act
            var result = createPaySlip.PaymentStartDate; 
            
                
            //Assert
            var date = new DateTime(2017, 3, 1);
            
            Assert.AreEqual(date, result);

        }
        
        
        
        [Test]
        public void CalculatePayPeriod_ValidStartAndEndDate_ReturnsCorrectPayPeriod()
        {
            //Arrange
            var startDate = "Mar 1, 2017";
            var endDate = "Mar 31, 2017";
            var consolePaySlipDisplay = new ConsolePlaySlipDisplay();
            var createPaySlip = new CreatePaySlip(startDate, endDate, consolePaySlipDisplay);
            
            //Act
            var result = createPaySlip.PayPeriod; 
            
                
            //Assert
            var payPeriod = TimeSpan.FromDays(31);
            Assert.AreEqual(payPeriod, result);

        }
        
        // Need test for if startDate < EndDate or if either dates are not valid


        [Test]
        public void CalculateGrossIncome_ValidAnnualSalary_ReturnsCorrectGrossIncome()
        {
            //Arrange 
            var startDate = "Mar 1, 2017";
            var endDate = "Mar 31, 2017";
            var consolePaySlipDisplay = new ConsolePlaySlipDisplay();
            var createPaySlip = new CreatePaySlip(startDate, endDate, consolePaySlipDisplay);
        
            //Act
            decimal annualSalary = 60050m;  //is writing m necessary when I already have d
            createPaySlip.CalculateGrossIncome(annualSalary);
            var result = createPaySlip.GrossIncome; 
            
            // Assert
            decimal grossIncome = 31m * (60050m / 365m);
            Assert.AreEqual(grossIncome, result);
            
        }

        
        [Test]
        public void CalculateIncomeTax_ValidAnnualSalary_ReturnsCorrectIncomeTax()
        {
            //Arrange 
            var startDate = "Mar 1, 2017";
            var endDate = "Mar 31, 2017";
            var consolePaySlipDisplay = new ConsolePlaySlipDisplay();
            var createPaySlip = new CreatePaySlip(startDate, endDate, consolePaySlipDisplay);
        
            //Act
            
            var annualSalary = 60050m;
            createPaySlip.CalculateIncomeTax(annualSalary);
            
          
            var result = createPaySlip.IncomeTax; 
            
            // Assert
            decimal incomeTax = (3572m + (60050m - 37000m) * 0.325m) * (31m/ 365m);
            Assert.AreEqual(incomeTax, result);
            
        }

        
       
                
        [Test]
        public void CalculateNetIncome_ReturnsCorrectNetIncome() // not sure what the situation is here 
        {
            //Arrange 
            var startDate = "Mar 1, 2017";
            var endDate = "Mar 31, 2017";
            var consolePaySlipDisplay = new ConsolePlaySlipDisplay();
            var createPaySlip = new CreatePaySlip(startDate, endDate, consolePaySlipDisplay);
        
            //Act
            decimal annualSalary = 60050m;
            createPaySlip.CalculateGrossIncome(annualSalary);  
            createPaySlip.CalculateIncomeTax(annualSalary);
            createPaySlip.CalculateNetIncome();
            
            var result = createPaySlip.NetIncome;
            
        
            // Assert
            decimal netIncome = (annualSalary - (3572m + (60050m - 37000m) * 0.325m)) * (31m/365m);
            Assert.AreEqual(CreatePaySlip.RoundToDollar(netIncome), CreatePaySlip.RoundToDollar(result) );
            
        }

        
                        
        [Test]
        public void CalculateSuper_ValidSuperRate_ReturnsCorrectSuper() // not sure what the situation is here 
        {
            //Arrange 
            var startDate = "Mar 1, 2017";
            var endDate = "Mar 31, 2017";
            var consolePaySlipDisplay = new ConsolePlaySlipDisplay();
            var createPaySlip = new CreatePaySlip(startDate, endDate, consolePaySlipDisplay);
        
            //Act
            
            var annualSalary = 60050m;
            var superRate = 9m;
            
            createPaySlip.CalculateGrossIncome(annualSalary);
            createPaySlip.CalculateSuper(superRate);
            
            var result = createPaySlip.Super;
            
        
            // Assert
            decimal super = 31m * (60050m / 365m) * superRate / 100m;
            Assert.AreEqual(CreatePaySlip.RoundToDollar(super), CreatePaySlip.RoundToDollar(result) );
            
        }
        
        






    }
    
    

}



// # Payslip Kata
//
// At MYOB we rock at payroll, the most important part of payroll is getting your payslip!
//
// In this code kata, we have several levels of difficulty.
//
// ## The payslip rules
//
// * Pay period = per calendar month   
// * Gross income = annual salary / 12 months   
// * Income tax = based on the tax table provided below    
// * Net income = gross income - income tax    
// * Super = gross income x super rate    
// * All calculation results should be rounded to the whole dollar. If >= 50 cents round up to the next dollar increment, otherwise round down.   
//
// ------------------------------------------------------------------------------------------------------------
//
// ## Basic Payslip Kata
//
// When supplied employee details: first name, last name, annual salary (positive integer) and super rate (0% - 50% inclusive), payment start date, generate pay slip information with name, pay period,
// gross income, income tax, net income and super.
//
// The following rates for 2017-18 apply from 1 July 2017:
//
// | Taxable Income     | Tax on this Income                         |
// |--------------------|--------------------------------------------|
// | $0 - $18,200       | Nil                                        |
// | $18,201 - $37,000  | 19c for each $1 over $18,200               |
// | $37,001 - $87,000  | $3,572 plus 32.5c for each $1 over $37,000 |
// | $87,001 - $180,000 | $19,822 plus 37c for each $1 over $87,000  |
// | $180,001 and over  | $54,232 plus 45c for each $1 over $180,000 |
//
// For example, the payment in March for an employee with an annual salary of $60,050 and a super rate of 9% is:
//
// * pay period = Month of March (01 March to 31 March)  
// * gross income = 60,050 / 12 = 5,004.16666667 (round down) = 5,004  
// * income tax = (3,572 + (60,050 - 37,000) x 0.325) / 12 = 921.9375 (round up) = 922  
// * net income = 5,004 - 922 = 4,082  
// * super = 5,004 x 9% = 450.36 (round down) = 450  
//
// ### Your Task
//
// Generate a basic payslip application. You should be able to enter a single employee details, the application will generate a basic payslip.
//
// Everything will be done via the console.
//
// An example run through of of how this console would be...
//
// ~~~
// Welcome to the payslip generator!
//
// Please input your name: John  
// Please input your surname: Doe  
// Please enter your annual salary: 60050
// Please enter your super rate: 9
// Please enter your payment start date: 1 March
// Please enter your payment end date: 31 March
//
// Your payslip has been generated:
//
// Name: John Doe  
// Pay Period: 01 March – 31 March  
// Gross Income: 5004  
// Income Tax: 922 
// Net Income:4082 
// Super: 450  
//
// Thank you for using MYOB!
// ~~~
//
// ------------------------------------------------------------------------------------------------------------
//
// ## Taking it to the next level...variations
//
// There are a number of possible customizations that can be added as well.
//
// ------------------------------------------------------------------------------------------------------------
//
// ### Loading from CSV File  
//
// Adjust your payslip generator to load csv files.
//
// It should be able to process the following csv input and generate the expected output. 
//
// Example File Formats:  
//
// * [Sample Input File](sample_input.csv)  
// * [Sample Output File](sample_output.csv)  
//
// ------------------------------------------------------------------------------------------------------------
//
// ### Adding a Front End
//
// Put a web front end on the application. Users should be able to select a CSV file to upload and evaluate.  