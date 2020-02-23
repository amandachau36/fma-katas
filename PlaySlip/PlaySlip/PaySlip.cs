using System;

namespace PlaySlip
{
    public class CreatePaySlip
    {
        public DateTime PaymentStartDate { get; private set;  } 
        
        public DateTime PaymentEndDate { get; private set;  }
        
        public TimeSpan PayPeriod { get; private set; }

        public decimal GrossIncome { get; private set; }

        public decimal IncomeTax { get; private set; }
        
        // should I be setting all these values in the constructor . . . 

        public void SetPaymentStartDate(string date) // make this into an interface but can't pass in the string?  
        {
            PaymentStartDate = DateTime.Parse(date);
        }
        
        public void SetPaymentEndDate(string date) // not DRY 
        {
            PaymentEndDate = DateTime.Parse(date);
        }

        public void CalculatePayPeriod()
        {
            // add 1 day because pay period is in inclusive of the PaymentEndDate
            PayPeriod = PaymentEndDate.Subtract(PaymentStartDate) + TimeSpan.FromDays(1); 
        }

        public void CalculateGrossIncome(decimal annualSalary)
        {    
            
            CalculatePayPeriod();
            // doesn't take into account leap years or that the proportion of work days/weekend  may vary between pay periods 
            decimal payPeriodInDays = Convert.ToDecimal(PayPeriod.TotalDays); // convert to double then decimal
            decimal daysInYear = 365m;   
            GrossIncome = payPeriodInDays * (annualSalary / daysInYear);
        }

        public static decimal RoundToDollar(decimal amount)
        {
            return Decimal.Round(amount);  //  how can I make it amount.RoundToDollar()
        }

        public void CalculateIncomeTax(decimal annualSalary)
        {
            decimal incomeTaxPerYear = 0;
            if (annualSalary <= 18200m)
                incomeTaxPerYear = 0;
            else if (annualSalary > 18200m && annualSalary <= 37000m)
                incomeTaxPerYear = (annualSalary - 18200m) * 0.19m;
            else if (annualSalary > 37000m && annualSalary <= 87000m)
                incomeTaxPerYear = 3572m + (annualSalary - 37000m) * 0.325m;
            else if (annualSalary > 87000m && annualSalary <= 180000m)
                incomeTaxPerYear = 19822m + (annualSalary - 87000m) * 0.37m;
            else if (annualSalary > 180000m)
                incomeTaxPerYear = 54232 + (annualSalary - 180000m) * 0.45m;

            decimal payPeriodInDays = Convert.ToDecimal(PayPeriod.TotalDays);
            IncomeTax = incomeTaxPerYear * (payPeriodInDays/ 365m);

        }


    }
}