using System;

namespace PlaySlip
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var employeeJohn = new Employee("John", "Doe", 60050);
            
            var createPayslip = new CreatePaySlip();
            var startDate = "Mar 1, 2017";
            var endDate = "Mar 31, 2017";
            createPayslip.SetPaymentStartDate(startDate);
            createPayslip.SetPaymentEndDate(endDate);
            createPayslip.CalculatePayPeriod();
            createPayslip.CalculateGrossIncome(employeeJohn.AnnualSalary);
            Console.WriteLine("gross salary: " + createPayslip.GrossIncome);

            var x = 100.23m;
            Console.WriteLine(CreatePaySlip.RoundToDollar(x));
            var y = 100.56m;
            Console.WriteLine(CreatePaySlip.RoundToDollar(y));
            
            createPayslip.CalculateIncomeTax(employeeJohn.AnnualSalary);
            
            
        
            
        }
    }
}


