using System;
using System.Text;

namespace PlaySlip.Application
{
    public class PaySlip
    {
        public DateTime PaymentStartDate { get; } 
        
        public DateTime PaymentEndDate { get; }
        
        public TimeSpan PayPeriod { get; private set; }

        public decimal GrossIncome { get; private set; }

        public decimal IncomeTax { get; private set; }
        
        public decimal NetIncome { get; private set; }
        
        public decimal Super { get; private set; }
        
        public PaySlip(DateTime paymentStartDate, DateTime paymentEndDate) // should I pass an instance of Employee into the constructor? NO
        {
            PaymentStartDate = paymentStartDate;
            
            PaymentEndDate = paymentEndDate;
            
            CalculatePayPeriod();
        }
        
        public void CalculatePayPeriod()
        {
            PayPeriod = PaymentEndDate.Subtract(PaymentStartDate) + TimeSpan.FromDays(1);   // add 1 day because pay period is in inclusive of the PaymentEndDate
        }

        public void CalculateGrossIncome(decimal annualSalary) // doesn't take into account leap years or that the proportion of work days/weekend  may vary between pay periods 
        {
            var payPeriodInDays = Convert.ToDecimal(PayPeriod.TotalDays); // convert to double then decimal

            GrossIncome = payPeriodInDays * (annualSalary / _numberOfDaysInYear);
        }
        
        public void CalculateIncomeTax(decimal annualSalary)   
        {
            decimal incomeTaxPerYear = 0;

            if (annualSalary <= 18200m)
            {
                incomeTaxPerYear = 0;   
            }
            else if (annualSalary > 18200m && annualSalary <= 37000m)
            {
                incomeTaxPerYear = (annualSalary - 18200m) * 0.19m;
            }
            else if (annualSalary > 37000m && annualSalary <= 87000m)
            {
                incomeTaxPerYear = 3572m + (annualSalary - 37000m) * 0.325m;
            }
            else if (annualSalary > 87000m && annualSalary <= 180000m)
            {
                incomeTaxPerYear = 19822m + (annualSalary - 87000m) * 0.37m;
            }
            else if (annualSalary > 180000m)
            {
                incomeTaxPerYear = 54232 + (annualSalary - 180000m) * 0.45m;
            }
            
            decimal payPeriodInDays = Convert.ToDecimal(PayPeriod.TotalDays);
            
            IncomeTax = incomeTaxPerYear * (payPeriodInDays/ _numberOfDaysInYear);
        }

        public void CalculateNetIncome()
        {
            NetIncome = GrossIncome - IncomeTax;
        }

        public void CalculateSuper(decimal superRate)
        {
            Super = GrossIncome * superRate / 100m;
        }

        public void AllPaySlipCalculations(decimal annualSalary, decimal superRate)
        {
            CalculateGrossIncome(annualSalary);
            CalculateIncomeTax(annualSalary);
            CalculateNetIncome();
            CalculateSuper(superRate);
        }

        private decimal _numberOfDaysInYear = 365;

    }
}