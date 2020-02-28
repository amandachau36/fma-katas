using System;
using System.Collections.Generic;

namespace PlaySlip.Application
{
    public class ConsolePlaySlipDisplay : IDisplay
    {
        public void Display(string message)
        {
            Console.Write(message);
        }
        
        
        public void Display(List<string> messages)
        {
            foreach (var message in messages)
            {
                Console.Write(message);
            }
        }
        
        public string ToFormattedDate(DateTime date) //  how can I make it date.toFormattedDate() and should this be in IDisplay ? 
        {
            return date.ToString("MMMM dd, yyyy");
        }
        
        public decimal RoundToDollar(decimal amount)
        {
            return Decimal.Round(amount);  //  how can I make it amount.RoundToDollar()
        }

        
        public void DisplayGeneratedPayslip(string fullName, DateTime startDate, DateTime endDate, decimal grossIncome, decimal incomeTax, decimal netIncome, decimal super)
        {
            string[] lines =
            {
                "\nYour payslip has been generated: \n",
                $"Name: {fullName}",
                $"Pay Period: {ToFormattedDate(startDate)} – {ToFormattedDate(endDate)}",
                $"Gross Income: {RoundToDollar(grossIncome)}",
                $"Income Tax: {RoundToDollar(incomeTax)}",
                $"Net Income: {RoundToDollar(netIncome)}",
                $"Super: {RoundToDollar(super)}"
            };

           
            foreach (var line in lines)
            {
                Console.WriteLine(line);

            }
   
        }
        
        
        
    }
}


// other methods are private