using System;
using System.Collections.Generic;

namespace PlaySlip.Application
{
    public class PaySlipManager // should this implement an interface? No, there are no situations at the moment that would require this, it would be over engineering 
    {
        public PaySlipManager(IDisplay paySlipDisplay, IInputCollector paySlipInputCollector) // only interface methods are available 
        {
            _paySlipDisplay = paySlipDisplay; // composition
            
            _paySlipInputCollector = paySlipInputCollector;
        }

        public void Process()
        {
            _paySlipDisplay.Display(Constants.WelcomeMessage);
            
           // composition and loosely coupled because you can pass in any validator with IValidator interface 
           var firstName = ReadAndValidate( new Input(new List<string>()
                                                                                            { Constants.FirstNamePrompt }, 
                                                                                            new NameValidator(), 
                                                                                            Constants.GeneralError));

            var lastName = ReadAndValidate(new Input(new List<string>() 
                                                                                            { Constants.LastNamePrompt },
                                                                                            new NameValidator(), 
                                                                                            Constants.GeneralError));

            var annualSalary = ReadAndValidate(new Input(new List<string>()
                                                                                                { Constants.AnnualSalaryPrompt },
                                                                                                new AnnualSalaryValidator(),
                                                                                                Constants.AnnualSalaryErrorMessage));
            
            var superRate = ReadAndValidate(new Input(new List<string>() 
                                                                                {Constants.SuperPrompt}, 
                                                                                new SuperValidator(),
                                                                                Constants.SuperRateErrorMessage));

            var startAndEndDates = ReadAndValidate(new Input(new List<string>() 
                                                                                                {Constants.PaymentStartDatePrompt, Constants.PaymentEndDatePrompt}, 
                                                                                                new DateValidator(), 
                                                                                                Constants.DateErrorMessage));  
            

            var paySlipOutput = PaySlipOutput(
                new Employee(firstName[0], lastName[0], decimal.Parse(annualSalary[0]), decimal.Parse(superRate[0])),
                new PaySlip(DateTime.Parse(startAndEndDates[0]), DateTime.Parse(startAndEndDates[1]))
                );
            
            _paySlipDisplay.Display(paySlipOutput);
        }
        
        // separate methods??? 


        private List<string> ReadAndValidate(Input input) 
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
        
        
        // not sure if this is the right place to put this - this is an appropriate place for this  
        private List<string> PaySlipOutput(Employee employee, PaySlip paySlip)    // pass in object instead
        {
            paySlip.AllPaySlipCalculations(employee.AnnualSalary, employee.SuperRate);
            
            var lines = new List<string>
            {
                "\nYour payslip has been generated: \n",
                $"Name: {employee.GenerateFullName()}",
                $"Pay Period: {DateHelper.ToFormattedDate(paySlip.PaymentStartDate)} – {DateHelper.ToFormattedDate(paySlip.PaymentEndDate)}",
                $"Gross Income: {CurrencyHelper.ToRoundedDollar(paySlip.GrossIncome)}",
                $"Income Tax: {CurrencyHelper.ToRoundedDollar(paySlip.IncomeTax)}",
                $"Net Income: {CurrencyHelper.ToRoundedDollar(paySlip.NetIncome)}",
                $"Super: {CurrencyHelper.ToRoundedDollar(paySlip.Super)}"
            };

            return lines;
        }
        
        private readonly IDisplay _paySlipDisplay;
        
        private readonly IInputCollector _paySlipInputCollector;
    }
}


// static  x interface doesn't work 