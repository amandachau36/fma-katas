using System;

namespace PlaySlip.Application
{
    public class DateValidator : IValidator
    {
        public bool IsValid(string input)
        {
            DateTime temp;
            return (DateTime.TryParse(input, out temp));
        }
    }
}