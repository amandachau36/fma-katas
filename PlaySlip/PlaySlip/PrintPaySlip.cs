using System;

namespace PlaySlip
{
    public class PrintPaySlip
    {
        private readonly IDisplay _paySlipDisplay;


        public PrintPaySlip(IDisplay playSlipDisplay)  // only interface methods are available 
        {
            _paySlipDisplay = playSlipDisplay; // composition
        }
         public string GetName(string firstOrLastNamePrompt) 
        {
            while (true) // inputIsNotValid
            {
                _paySlipDisplay.Display(firstOrLastNamePrompt);
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;
                _paySlipDisplay.Display(Constants.GeneralError);  

            }
        }

        public decimal GetAnnualSalary()
        {
            while (true)
            {
                _paySlipDisplay.Display(Constants.AnnualSalaryPrompt); // not necessary for CSV 
                var input = Console.ReadLine();
                decimal annualSalary;
                if (Decimal.TryParse(input, out annualSalary) && annualSalary >  0) // should this logic be here . . . 
                    return annualSalary;
                _paySlipDisplay.Display(Constants.AnnualSalaryErrorMessage);
            }
        }
        
        
        public bool ValidateSuperRate(decimal superRate)
        {
            return IsSuperInValidRange(superRate);
        }

        
        public decimal GetSuperRate()
        {
            while (true)
            {
                _paySlipDisplay.Display(Constants.SuperPrompt);
                var input = Console.ReadLine();
                decimal superRate;
               
                if (Decimal.TryParse(input, out superRate) && ValidateSuperRate(superRate)) // should this logic be here . . . 
                    return superRate;
                _paySlipDisplay.Display( Constants.SuperRateErrorMessage );
            }
        }
        
  

        public DateTime GetDate(string datePrompt)
        {
            while (true)
            {
                _paySlipDisplay.Display(datePrompt);
                var input = Console.ReadLine();
                DateTime date;
                if (DateTime.TryParse(input, out date))
                    return date;
                _paySlipDisplay.Display(Constants.DateErrorMessage);

            }
        }


   


        public void Print()
        {
            _paySlipDisplay.Display(Constants.WelcomeMessage);
            
            
            var firstName = GetName(Constants.FirstNamePrompt);
            
            
            var lastName = GetName(Constants.LastNamePrompt);
            
            var annualSalary = GetAnnualSalary();
            
            var superRate = GetSuperRate();
            
            var employee = new Employee(firstName, lastName, annualSalary, superRate);

            var fullName = employee.GenerateFullName();

            var paymentStartDate = GetDate(Constants.PaymentStartDatePrompt);

            var paymentEndDate = GetDate(Constants.PaymentEndDatePrompt);

            if (paymentEndDate < paymentStartDate)
            {    
                _paySlipDisplay.Display(Constants.DateErrorMessage);
                paymentEndDate = GetDate(Constants.DateErrorMessage);
            }
                
            
            
            var createPaySlip = new CreatePaySlip(paymentStartDate, paymentEndDate);  
            
            
            createPaySlip.CalculateGrossIncome(employee.AnnualSalary);
            
            createPaySlip.CalculateNetIncome( employee.AnnualSalary);
            createPaySlip.CalculateSuper( employee.SuperRate);

            _paySlipDisplay.DisplayGeneratedPayslip(fullName, createPaySlip.PaymentStartDate, createPaySlip.PaymentEndDate, createPaySlip.GrossIncome, createPaySlip.IncomeTax, createPaySlip.NetIncome, createPaySlip.Super);
            
            
            
        }
        
        
        private bool IsSuperInValidRange(decimal superRate)
        {
            var maxSuper = 50;
            var minSuper = 0;

            return superRate > minSuper && superRate < maxSuper;
        }

        
    }
}


// static  x interface doesn't work 