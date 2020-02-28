using System;

namespace PlaySlip.Application
{
    public class PaySlipManager
    {
        private readonly IInputValidator _inputValidator;
        private readonly IDisplay _paySlipDisplay;
        
        
        public PaySlipManager(IDisplay paySlipDisplay,
            IInputValidator inputValidator) // only interface methods are available 
        {
            _paySlipDisplay = paySlipDisplay; // composition
            _inputValidator = inputValidator;
        }
        
        
        public void Process()
        {
            _paySlipDisplay.Display(Constants.WelcomeMessage);

            var firstName = ReadAndValidate(InputTypes.Name, Constants.FirstNamePrompt, Constants.GeneralError);

            var lastName = ReadAndValidate(InputTypes.Name, Constants.LastNamePrompt, Constants.GeneralError);
            
            var annualSalary = ReadAndValidate(InputTypes.AnnualSalary, Constants.AnnualSalaryPrompt, Constants.AnnualSalaryErrorMessage);

            var superRate = ReadAndValidate(InputTypes.Super, Constants.SuperPrompt, Constants.SuperRateErrorMessage);
            
            var employee = new Employee(firstName, lastName, decimal.Parse(annualSalary), decimal.Parse(superRate));
            
            var fullName = employee.GenerateFullName();

            var startDate = ReadAndValidate(InputTypes.Date, Constants.PaymentStartDatePrompt, Constants.DateErrorMessage);

            var endDate = ReadAndValidate(InputTypes.Date, Constants.PaymentEndDatePrompt, Constants.DateErrorMessage);

            var createPaySlip = new PaySlip(DateTime.Parse(startDate), DateTime.Parse(endDate));
            
            createPaySlip.CalculateGrossIncome(employee.AnnualSalary);

            createPaySlip.CalculateNetIncome(employee.AnnualSalary);

            createPaySlip.CalculateSuper(employee.SuperRate);

            _paySlipDisplay.DisplayGeneratedPayslip(fullName, createPaySlip.PaymentStartDate,
                createPaySlip.PaymentEndDate, createPaySlip.GrossIncome, createPaySlip.IncomeTax,
                createPaySlip.NetIncome, createPaySlip.Super);
        }

        private string ReadAndValidate(InputTypes inputTypes, string prompt, string error)
        {
            string input;
            bool isValid = false;
            do
            {
                _paySlipDisplay.Display(prompt);
                
                input = Console.ReadLine();
                
                isValid = _inputValidator.IsValid(inputTypes, input);

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