using System;

namespace PlaySlip.Application
{
    public class DateValidator : IValidator
    {
        public bool IsValid(params string[] input)
        {
            // Validate start date
            if (input[1] == null)
            {
                DateTime temp;
                return DateTime.TryParse(input[0], out temp);
            }
            
            // Validate end date
            DateTime startDate;
            
            DateTime.TryParse(input[1], out startDate);
            
            DateTime endDate;
            
            
            
            var isEndDateValid = DateTime.TryParse(input[0], out endDate);
            
            if (isEndDateValid && endDate > startDate)
            {
                return true;
            }
            return false;
        }

       
    }
}