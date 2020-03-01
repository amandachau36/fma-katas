using System;
using System.Collections.Generic;

namespace PlaySlip.Application
{
    public class PaySlipManager // should this implement an interface?  
    {
        private readonly IDisplay _paySlipDisplay;
        private readonly IInputCollector _paySlipInputCollector;

        public PaySlipManager(IDisplay paySlipDisplay, IInputCollector paySlipInputCollector) // only interface methods are available 
        {
            _paySlipDisplay = paySlipDisplay; // composition
            _paySlipInputCollector = paySlipInputCollector;
        }

        public void Process()
        {
            _paySlipDisplay.Display(Constants.WelcomeMessage);

            var firstName =
                ReadAndValidate(Constants.FirstNamePrompt, Constants.GeneralError,
                    new NameValidator()); // should I just create one new instance of NameValidator()

            var lastName = ReadAndValidate(Constants.LastNamePrompt, Constants.GeneralError, new NameValidator());

            var annualSalary = ReadAndValidate(Constants.AnnualSalaryPrompt, Constants.AnnualSalaryErrorMessage,
                new AnnualSalaryValidator());

            var superRate = ReadAndValidate(Constants.SuperPrompt, Constants.SuperRateErrorMessage,
                new SuperValidator());

            var employee = new Employee(firstName, lastName, decimal.Parse(annualSalary), decimal.Parse(superRate));

            var fullName = employee.GenerateFullName();

            var dateValidator = new DateValidator();

            var startDate =
                ReadAndValidate(Constants.PaymentStartDatePrompt, Constants.DateErrorMessage, dateValidator);

            var endDate = ReadAndValidate(Constants.PaymentEndDatePrompt, Constants.DateErrorMessage, dateValidator,
                startDate);

            var paySlip = new PaySlip(DateTime.Parse(startDate), DateTime.Parse(endDate));

            paySlip.AllPaySlipCalculations(employee.AnnualSalary, employee.SuperRate);

            var paySlipOutput = PaySlipOutput(fullName, paySlip.PaymentStartDate,
                paySlip.PaymentEndDate, paySlip.GrossIncome, paySlip.IncomeTax,
                paySlip.NetIncome, paySlip.Super);

            _paySlipDisplay.Display(paySlipOutput);
        }


        private string ReadAndValidate(string prompt, string error, IValidator iValidator,
                string optionalArg = null) // is there a better way to do this? 
        {
            string input;

            bool isValid;

            do
            {
                _paySlipDisplay.Display(prompt);

                input = _paySlipInputCollector.CollectInput();

                isValid = iValidator.IsValid(input, optionalArg);

                if (!isValid)
                {
                    _paySlipDisplay.Display(error);
                }

            } while (!isValid);

            return input;
        }

        private string ToFormattedDate(DateTime date) //  how can I make it date.toFormattedDate() and should this be in IDisplay ? 
        {
            return date.ToString("MMMM dd, yyyy");
        }

        private decimal ToRoundedDollar(decimal amount)
        {
            return Decimal.Round(amount); //  how can I make it amount.RoundToDollar()
        }
        
        private List<string> PaySlipOutput(string fullName, DateTime startDate, DateTime endDate, 
            decimal grossIncome, decimal incomeTax, decimal netIncome, decimal super)  // not sure if this is the right place to put this 
        {
            var lines = new List<string>
            {
                "\nYour payslip has been generated: \n",
                $"Name: {fullName}",
                $"Pay Period: {ToFormattedDate(startDate)} – {ToFormattedDate(endDate)}",
                $"Gross Income: {ToRoundedDollar(grossIncome)}",
                $"Income Tax: {ToRoundedDollar(incomeTax)}",
                $"Net Income: {ToRoundedDollar(netIncome)}",
                $"Super: {ToRoundedDollar(super)}"
            };

            return lines;
        }
    }
}


// static  x interface doesn't work 