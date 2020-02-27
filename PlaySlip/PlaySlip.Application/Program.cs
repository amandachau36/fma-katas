using System;

namespace PlaySlip.Application
{
    class Program
    {
        static void Main(string[] args)
        { 
     
            var consolePaySlipDisplay = new ConsolePlaySlipDisplay();
            var consoleInputValidator = new ConsoleInputValidator();
            var printPaySlip = new PrintPaySlip(consolePaySlipDisplay, consoleInputValidator);

            printPaySlip.Print();






        }
    }
}


// var startDate = "Mar 1, 2017";
// var endDate = "Mar 31, 2017";
// var consolePaySlipDisplay = new ConsolePlaySlipDisplay();
// var createPaySlip = new CreatePaySlip(startDate, endDate, consolePaySlipDisplay);
//             
//             
// createPaySlip.GeneratePaySlip(); 



// var employeeJohn = new Employee("John", "Doe", 60050);
//
// var createPayslip = new CreatePaySlip();
// var startDate = "Mar 1, 2017";
// var endDate = "Mar 31, 2017";
// createPayslip.SetPaymentStartDate(startDate);
// createPayslip.SetPaymentEndDate(endDate);
// createPayslip.CalculatePayPeriod();
// createPayslip.CalculateGrossIncome(employeeJohn.AnnualSalary);
// Console.WriteLine("gross salary: " + createPayslip.GrossIncome);
//
// var x = 100.23m;
// Console.WriteLine(CreatePaySlip.RoundToDollar(x));
// var y = 100.56m;
// Console.WriteLine(CreatePaySlip.RoundToDollar(y));
//
// createPayslip.CalculateIncomeTax(employeeJohn.AnnualSalary);

// var startDate = new DateTime(2017, 3, 1);
// var endDate = new DateTime(2017, 3, 31);
// var consolePaySlipDisplay = new ConsolePlaySlipDisplay();
// var createPaySlip = new CreatePaySlip(startDate, endDate, consolePaySlipDisplay);
