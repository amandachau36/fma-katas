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
            
            var firstName = ReadAndValidate(Constants.FirstNamePrompt, Constants.GeneralError, new NameValidator()); // should I just create one new instance of NameValidator()
            
            var lastName = ReadAndValidate(Constants.LastNamePrompt, Constants.GeneralError, new NameValidator());
            
            var annualSalary = ReadAndValidate(Constants.AnnualSalaryPrompt, Constants.AnnualSalaryErrorMessage, new AnnualSalaryValidator());

            var superRate = ReadAndValidate(Constants.SuperPrompt, Constants.SuperRateErrorMessage, new SuperValidator());
            
            var employee = new Employee(firstName, lastName, decimal.Parse(annualSalary), decimal.Parse(superRate));
            
            var fullName = employee.GenerateFullName();

            var dateValidator = new DateValidator();    
            
            var startDate = ReadAndValidate(Constants.PaymentStartDatePrompt, Constants.DateErrorMessage, dateValidator );
            
            var endDate = ReadAndValidate(Constants.PaymentEndDatePrompt, Constants.DateErrorMessage, dateValidator, startDate );

            var paySlip = new PaySlip(DateTime.Parse(startDate), DateTime.Parse(endDate));
            
            paySlip.AllPaySlipCalculations(employee.AnnualSalary, employee.SuperRate);

            _paySlipDisplay.DisplayGeneratedPayslip(fullName, paySlip.PaymentStartDate,
                paySlip.PaymentEndDate, paySlip.GrossIncome, paySlip.IncomeTax,
                paySlip.NetIncome, paySlip.Super);
        }

       
        private string ReadAndValidate(string prompt, string error, IValidator iValidator, string optionalArg = null) // is there a better way to do this? 
        {
            string input;
            
            bool isValid;
            
            do
            {
                _paySlipDisplay.Display(prompt);
                
                input = Console.ReadLine();
                
                isValid = iValidator.IsValid(input, optionalArg);  

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