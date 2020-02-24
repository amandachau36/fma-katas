using System;

namespace PlaySlip
{
    public class ConsolePlaySlipDisplay : IDisplay
    {
        public void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the payslip generator");
        }

        public void DisplayFirstNamePrompt()
        {
            Console.Write("\nPlease input your first name: ");
        }

        public void DisplayGeneralError()
        {
            Console.WriteLine("There was an error. Please try again.");
        }

        public void DisplayLastNamePrompt()
        {
            Console.Write("\nPlease input your last name: ");
        }

        public void DisplayAnnualSalaryPrompt()
        {
            Console.Write("\nPlease enter your annual salary: ");
        }

        public void DisplayAnnualSalaryErrorMessage()
        {
            Console.WriteLine("Annual salary must be a positive number. Try again.");
        }

        public void DisplaySuperRatePrompt()
        {
            Console.Write("\nPlease enter your super rate: ");
        }

        public void DisplaySuperRateErrorMessage()
        {
            Console.WriteLine("Super rate must be between 0% - 50%. Try again.");
            
        }

        public void DisplayPaymentStartDatePrompt()
        {
            Console.Write("\nPlease enter your payment start date (ex. Mar 1, 2017): ");
        }

        public void DisplayPaymentEndDatePrompt()
        {
            Console.Write("\nPlease enter your payment end date (ex. Mar 31, 2017): ");
        }

        public void DisplayDateErrorMessage()
        {
            Console.WriteLine("Date must be entered in the following format Mar 1, 2017. Payment end date must occur AFTER payment start date. Try again. ");
        }

        public string ToFormattedDate(DateTime date) //  how can I make it date.toFormattedDate()
        {
            return date.ToString("MMMM dd, yyyy");
        }
        
        
        public void DisplayGeneratedPayslip(string fullName, string startDate, string endDate, decimal grossIncome, decimal incomeTax, decimal netIncome, decimal super)
        {
            string[] lines =
            {
                "\nYour payslip has been generated: \n",
                $"Name: {fullName}",
                $"Pay Period: {ToFormattedDate(startDate)} – {ToFormattedDate(endDate)}",
                $"Gross Income: {grossIncome}",
                $"Income Tax: {incomeTax}",
                $"Net Income: {netIncome}",
                $"Super: {super}"
            };

           
            foreach (var line in lines)
            {
                Console.WriteLine(line);

            }
   
        }
        
        
        
    }
}