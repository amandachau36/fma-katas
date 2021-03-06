using System;
using System.Collections.Generic;

namespace PlaySlip.Application
{
    public class DateValidator : IValidator
    {
        public bool IsValid(List<string> input)
        {
            
            DateTime startDate;
            
            var isStartDateValid = DateTime.TryParse(input[0], out startDate); //this not the best way to do things
            
            DateTime endDate;

            var isEndDateValid = DateTime.TryParse(input[1], out endDate);

            if (!isStartDateValid || !isEndDateValid)
            {
                return false;
            }
            
            return endDate > startDate && endDate <= DateTime.Now;
        }

       
    }
}