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
        
        private string ToFormattedDate(DateTime date) //  how can I make it date.toFormattedDate() and should this be in IDisplay ? 
        {
            return date.ToString("MMMM dd, yyyy");
        }

        private decimal ToRoundedDollar(decimal amount)
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
                $"Gross Income: {ToRoundedDollar(grossIncome)}",
                $"Income Tax: {ToRoundedDollar(incomeTax)}",
                $"Net Income: {ToRoundedDollar(netIncome)}",
                $"Super: {ToRoundedDollar(super)}"
            };

           
            foreach (var line in lines)
            {
                Console.WriteLine(line);

            }
   
        }
        
        
        
    }
}


// other methods are private