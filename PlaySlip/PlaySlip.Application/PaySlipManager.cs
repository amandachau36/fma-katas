using System;

namespace PlaySlip.Application
{
    public class PaySlipManager
    {
        private readonly IDisplay _paySlipDisplay;
        public PaySlipManager(IDisplay paySlipDisplay) // only interface methods are available 
        {
            _paySlipDisplay = paySlipDisplay; // composition
        }
        
        
        public void Process()
        {
            _paySlipDisplay.Display(Constants.WelcomeMessage);

            var firstName = ReadAndValidate(Constants.FirstNamePrompt, Constants.GeneralError, new NameValidator());

            var lastName = ReadAndValidate(Constants.LastNamePrompt, Constants.GeneralError, new NameValidator());
            
            var annualSalary = ReadAndValidate(Constants.AnnualSalaryPrompt, Constants.AnnualSalaryErrorMessage, new AnnualSalaryValidator());

            var superRate = ReadAndValidate(Constants.SuperPrompt, Constants.SuperRateErrorMessage, new SuperValidator());
            
            var employee = new Employee(firstName, lastName, decimal.Parse(annualSalary), decimal.Parse(superRate));
            
            var fullName = employee.GenerateFullName();

            var startDate = ReadAndValidate(Constants.PaymentStartDatePrompt, Constants.DateErrorMessage, new DateValidator() );

            var endDate = ReadAndValidate(Constants.PaymentEndDatePrompt, Constants.DateErrorMessage, new DateValidator());

            var createPaySlip = new PaySlip(DateTime.Parse(startDate), DateTime.Parse(endDate));
            
            createPaySlip.CalculateGrossIncome(employee.AnnualSalary);

            createPaySlip.CalculateNetIncome(employee.AnnualSalary);

            createPaySlip.CalculateSuper(employee.SuperRate);

            _paySlipDisplay.DisplayGeneratedPayslip(fullName, createPaySlip.PaymentStartDate,
                createPaySlip.PaymentEndDate, createPaySlip.GrossIncome, createPaySlip.IncomeTax,
                createPaySlip.NetIncome, createPaySlip.Super);
        }

        private string ReadAndValidate(string prompt, string error, IValidator iValidator)
        {
            string input;
            
            bool isValid;
            
            do
            {
                _paySlipDisplay.Display(prompt);
                
                input = Console.ReadLine();
                
                isValid = iValidator.IsValid(input);

                if (!isValid)
                {
                    _paySlipDisplay.Display(error);
                }
                
            } while (!isValid);

            return input;
        }
    }
}


// static  x interface doesn't work 