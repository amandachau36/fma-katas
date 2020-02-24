using System;

namespace PlaySlip
{
    public class PrintPaySlip
    {
        private readonly IDisplay _paySlipDisplay;


        public PrintPaySlip(IDisplay playSlipDisplay) 
        {
            _paySlipDisplay = playSlipDisplay; 

        }
         public string GetName(Action firstOrLastNamePrompt) 
        {
            while (true)
            {
                firstOrLastNamePrompt();
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;
                _paySlipDisplay.DisplayGeneralError();  // why can't this just be a part of the class but not in the interface 

            }
        }

        public decimal GetAnnualSalary()
        {
            while (true)
            {
                _paySlipDisplay.DisplayAnnualSalaryPrompt();
                var input = Console.ReadLine();
                decimal annualSalary;
                if (Decimal.TryParse(input, out annualSalary) && annualSalary > 0) // should this logic be here . . . 
                    return annualSalary;
                _paySlipDisplay.DisplayAnnualSalaryErrorMessage();
            }
        }
        
        
        public decimal GetSuperRate()
        {
            while (true)
            {
                _paySlipDisplay.DisplaySuperRatePrompt();
                var input = Console.ReadLine();
                decimal super;
                var maxSuper = 50;
                var minSuper = 0;
                if (Decimal.TryParse(input, out super) && super > minSuper && super < maxSuper) // should this logic be here . . . Should also put it in the backend 
                    return super;
                _paySlipDisplay.DisplaySuperRateErrorMessage();
            }
        }
        
        public static decimal RoundToDollar(decimal amount)
        {
            return Decimal.Round(amount);  //  how can I make it amount.RoundToDollar()
        }


        public DateTime GetDate(Action datePrompt)
        {
            while (true)
            {
                datePrompt();
                var input = Console.ReadLine();
                DateTime date;
                if (DateTime.TryParse(input, out date))
                    return date;
                _paySlipDisplay.DisplayDateErrorMessage();

            }
        }


        public string ToFormattedDate(DateTime date)
        {
            return date.ToString("MMMM dd, yyyy");
        }


        public void Print()
        {
            _paySlipDisplay.DisplayWelcomeMessage();

            var firstName = GetName(_paySlipDisplay.DisplayFirstNamePrompt);
            
            var lastName = GetName(_paySlipDisplay.DisplayLastNamePrompt);
            
            var annualSalary = GetAnnualSalary();
            
            var superRate = GetSuperRate();
            
            var employee = new Employee(firstName, lastName, annualSalary, superRate);

            var fullName = employee.GenerateFullName();

            var paymentStartDate = GetDate(_paySlipDisplay.DisplayPaymentStartDatePrompt);

            var paymentEndDate = GetDate(_paySlipDisplay.DisplayPaymentEndDatePrompt);
            
            
            var createPaySlip = new CreatePaySlip(paymentStartDate, paymentEndDate);  
            
            
            createPaySlip.CalculateGrossIncome(employee.AnnualSalary);
            
            createPaySlip.CalculateNetIncome( employee.AnnualSalary);
            createPaySlip.CalculateSuper( employee.SuperRate);

            _paySlipDisplay.DisplayGeneratedPayslip(fullName, ToFormattedDate(createPaySlip.PaymentStartDate), ToFormattedDate(createPaySlip.PaymentEndDate), RoundToDollar(createPaySlip.GrossIncome), RoundToDollar(createPaySlip.IncomeTax), RoundToDollar(createPaySlip.NetIncome), RoundToDollar(createPaySlip.Super) );
            
            
            
        }
        
    }
}