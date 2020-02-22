using System;

namespace PlaySlip
{
    public class CreatePaySlip
    {
        public DateTime PaymentStartDate { get; private set;  } 
        
        public DateTime PaymentEndDate { get; private set;  }
        
        public TimeSpan PayPeriod { get; private set; }

        public decimal GrossIncome { get; private set; }
        
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

        public void CalculateGrossIncome(decimal AnnualSalary)
        {    
            
            CalculatePayPeriod();
            // doesn't take into account leap years or that the proportion of work days/weekend  may vary between pay periods 
            decimal payPeriodInDays = Convert.ToDecimal(PayPeriod.TotalDays); // convert to double then decimal
            decimal daysInYear = 365m;   
            GrossIncome = payPeriodInDays * (AnnualSalary / daysInYear);
        }

        // public int RoundToDollar(decimal amount)
        // {
        //     return amount.
        // }


    }
}