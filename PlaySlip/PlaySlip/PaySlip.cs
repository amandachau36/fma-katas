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
        
        public decimal NetIncome { get; private set; }
        
        public decimal Super { get; private set; }


        public CreatePaySlip(string paymentStartDate, string paymentEndDate)
        {
            PaymentStartDate = DateTime.Parse(paymentStartDate);
            PaymentEndDate = DateTime.Parse(paymentEndDate);
            CalculatePayPeriod();
        }
        

        public void CalculatePayPeriod()
        {
            // add 1 day because pay period is in inclusive of the PaymentEndDate
            PayPeriod = PaymentEndDate.Subtract(PaymentStartDate) + TimeSpan.FromDays(1); 
        }

        public void CalculateGrossIncome(decimal annualSalary)
        {    
            
            // doesn't take into account leap years or that the proportion of work days/weekend  may vary between pay periods 
            decimal payPeriodInDays = Convert.ToDecimal(PayPeriod.TotalDays); // convert to double then decimal
            decimal daysInYear = 365m;   
            GrossIncome = payPeriodInDays * (annualSalary / daysInYear);
        }

        public static decimal RoundToDollar(decimal amount)
        {
            return Decimal.Round(amount);  //  how can I make it amount.RoundToDollar()
        }

        public void CalculateIncomeTax(decimal annualSalary)  // perhaps I should just chuck annual salary in the constructor as welllll but then I can't use it for the different ppl 
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

        public void CalculateNetIncome()
        {
            NetIncome = GrossIncome - IncomeTax;
        }

        public void CalculateSuper(decimal superRate)
        {
            Super = GrossIncome * superRate / 100m;

        }
        
        
        
        

    }
}