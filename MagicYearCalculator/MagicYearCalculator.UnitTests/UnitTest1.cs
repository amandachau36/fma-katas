using NUnit.Framework;

namespace MagicYearCalculator.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

   
      
        [Test]
        public void MagicYear_StartYearIs1980_Returns2045()
        {
            
            //Arrange 
            var magicCalculator = new MagicCalculator(); 
            
            //act
            var result = magicCalculator.MagicYear(1980);
            
            
            //Assert
            Assert.AreEqual(2045, result);
            
            
        }

        [Test]
        // is this the right way to write this --- feels too specific
        public void MonthlySalary_AnnualSalaryIs60050_Returns5004()
        {
            //Arrange
            var magicCalculator = new MagicCalculator(); 
            
            //Act
            // should I be making 60050 as a variable
            var monthlySalary = magicCalculator.MonthlySalary(60050);
            var result = magicCalculator.RoundedMonthlySalary(monthlySalary);
            
            
            //Assert 
            Assert.AreEqual( 5004, result);
        }
        
        [Test]
       
        public void MonthlySalary_AnnualSalaryIs60055_Returns5005()
        {
            //Arrange
            var magicCalculator = new MagicCalculator(); 
            
            //Act
            
            var monthlySalary = magicCalculator.MonthlySalary(60055);
            var result = magicCalculator.RoundedMonthlySalary(monthlySalary);
            
            //Assert 
            Assert.AreEqual( 5005, result);
        }
        
        
        [Test]
       
        public void FullName_FirstNameIsJohnLastNameIsDoe_ReturnsJohnDoe()
        {
            //Arrange
            var magicCalculator = new MagicCalculator(); 
            
            //Act
            
            var result = magicCalculator.FullName("John", "Doe");
            
            
            //Assert 
            Assert.AreEqual( "John Doe", result);
        }
        
      
        
        
    }
}


// We have the following rules:

// Magic Year = work start year + 65
// Monthly salary = annual salary / 12 (rounded up)
// All calculation results should be rounded to the whole dollar. If >= 50 cents round up to the next dollar increment, otherwise round down.
// For example, the following calculations would result with an annual salary of $60,050 starting work in the year 1980:

// Monthly salary = 60,050 / 12 = 5,004.16666667 (round down) = 5,004
// Magic year = 1980 + 65 = 2045
// Your Task
// Generate a magic year calculator. You should be able to enter a single persons details, the application will generate a result. Everything will be done via the console.

// An example run through of of how this console would be...

// think about input via different formats 