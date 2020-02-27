using System;

namespace PlaySlip.Application
{
    public class PrintPaySlip
    {
        private readonly IInputValidator _inputValidator;
        private readonly IDisplay _paySlipDisplay;


        public PrintPaySlip(IDisplay paySlipDisplay,
            IInputValidator inputValidator) // only interface methods are available 
        {
            _paySlipDisplay = paySlipDisplay; // composition
            _inputValidator = inputValidator;
        }

        public string GetName(string firstOrLastNamePrompt)
        {
            _paySlipDisplay.Display(firstOrLastNamePrompt);
            return Console.ReadLine();
            
            _paySlipDisplay.Display(Constants.GeneralError);
            
        }

        public string GetAnnualSalary()
        {
            _paySlipDisplay.Display(Constants.AnnualSalaryPrompt); // not necessary for CSV 
            return Console.ReadLine();
            
        }
        
        public string GetSuperRate()
        {
            _paySlipDisplay.Display(Constants.SuperPrompt);
            return Console.ReadLine();
        }


        public string GetDate(string StartOrEndDatePrompt)
        {
            _paySlipDisplay.Display(StartOrEndDatePrompt);
            return Console.ReadLine();
            
        }


        public void Print()
        {
            _paySlipDisplay.Display(Constants.WelcomeMessage);

            var firstName = GetName(Constants.FirstNamePrompt);
            if (!_inputValidator.isValid(InputTypes.Name, firstName))
            {
                _paySlipDisplay.Display(Constants.GeneralError);
                firstName = GetName(Constants.FirstNamePrompt);
            }
                
            var lastName = GetName(Constants.LastNamePrompt);
            if (!_inputValidator.isValid(InputTypes.Name, lastName))
            {
                _paySlipDisplay.Display(Constants.GeneralError);
                lastName = GetName(Constants.LastNamePrompt);
            }

            
            var annualSalary = GetAnnualSalary();
            decimal decimalAnnualSalary = 0m;
            if (_inputValidator.isValid(InputTypes.AnnualSalary, annualSalary))
                decimalAnnualSalary = decimal.Parse(annualSalary);
            else
            {
                _paySlipDisplay.Display(Constants.AnnualSalaryErrorMessage);
                annualSalary = GetAnnualSalary();
            }
            

            var superRate = GetSuperRate();
            var decimalSuperRate = 0m;
            if (_inputValidator.isValid(InputTypes.Super, superRate))
                decimalSuperRate = decimal.Parse(superRate);
            else
            {
                _paySlipDisplay.Display(Constants.SuperRateErrorMessage);
                superRate = GetSuperRate();
            }
            
            
            var employee = new Employee(firstName, lastName, decimalAnnualSalary, decimalSuperRate);
            var fullName = employee.GenerateFullName();
            
            var startDate = GetDate(Constants.PaymentStartDatePrompt);
            DateTime paymentStartDate = new DateTime();
            if (_inputValidator.isValid(InputTypes.Date, startDate))
            {
                paymentStartDate = DateTime.Parse(startDate);
            }
            else
            {
                _paySlipDisplay.Display(Constants.DateErrorMessage);
                startDate = GetDate(Constants.PaymentStartDatePrompt);
            }
            
         

            var endDate = GetDate(Constants.PaymentEndDatePrompt);
            DateTime paymentEndDate = new DateTime();
            if (_inputValidator.isValid(InputTypes.Date, endDate))
            {
                paymentEndDate = DateTime.Parse(endDate);
            }
            else
            {
                _paySlipDisplay.Display(Constants.DateErrorMessage);
                endDate = GetDate(Constants.PaymentStartDatePrompt);
            }
            

            if (paymentEndDate < paymentStartDate)
            {
                _paySlipDisplay.Display(Constants.DateErrorMessage);
                endDate = GetDate(Constants.PaymentEndDatePrompt);
            }


            var createPaySlip = new PaySlip(paymentStartDate, paymentEndDate);


            createPaySlip.CalculateGrossIncome(employee.AnnualSalary);

            createPaySlip.CalculateNetIncome(employee.AnnualSalary);
            createPaySlip.CalculateSuper(employee.SuperRate);

            _paySlipDisplay.DisplayGeneratedPayslip(fullName, createPaySlip.PaymentStartDate,
                createPaySlip.PaymentEndDate, createPaySlip.GrossIncome, createPaySlip.IncomeTax,
                createPaySlip.NetIncome, createPaySlip.Super);
        }
    }
}


// static  x interface doesn't work 