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
            
            var firstNameInput = new Input(new List<string>() { Constants.FirstNamePrompt }, new NameValidator(), Constants.GeneralError);
            
            var firstName = ReadAndValidate(firstNameInput); 

            var lastNameInput = new Input(new List<string>() { Constants.LastNamePrompt }, new NameValidator(), Constants.GeneralError);
            
            var lastName = ReadAndValidate(lastNameInput); 
            
            var annualSalaryInput = new Input(new List<string>() { Constants.AnnualSalaryPrompt }, new AnnualSalaryValidator(), Constants.AnnualSalaryErrorMessage);

            var annualSalary = ReadAndValidate(annualSalaryInput);

            var superRateInput = new Input(new List<string>() {Constants.SuperPrompt}, new SuperValidator(),
                Constants.SuperRateErrorMessage);

            var superRate = ReadAndValidate(superRateInput);
            
            var employee = new Employee(firstName[0], lastName[0], decimal.Parse(annualSalary[0]), decimal.Parse(superRate[0]));
            
            var fullName = employee.GenerateFullName();
            
            var startAndEndDateInput = new Input(new List<string>() {Constants.PaymentStartDatePrompt, Constants.PaymentEndDatePrompt}, new DateValidator(), 
                Constants.DateErrorMessage);

            var startAndEndDates = ReadAndValidate(startAndEndDateInput);
            
            var paySlip = new PaySlip(DateTime.Parse(startAndEndDates[0]), DateTime.Parse(startAndEndDates[1]));
            
            paySlip.AllPaySlipCalculations(employee.AnnualSalary, employee.SuperRate);
            
            var paySlipOutput = PaySlipOutput(fullName, paySlip.PaymentStartDate,
                paySlip.PaymentEndDate, paySlip.GrossIncome, paySlip.IncomeTax,
                paySlip.NetIncome, paySlip.Super);
            
            _paySlipDisplay.Display(paySlipOutput);
        }


        private List<string> ReadAndValidate(Input input) // is there a better way to do this? 
        {
            var output = new List<string>();

            bool isValid;

            do
            {
                foreach (var prompt in input.Prompts)
                {
                    _paySlipDisplay.Display(prompt);

                    output.Add(_paySlipInputCollector.CollectInput());    
                }
                
                isValid = input.Validator.IsValid(output);

                if (!isValid)
                {
                    _paySlipDisplay.Display(input.Error);
                    
                    output.Clear();
                }

            } while (!isValid);

            return output;
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