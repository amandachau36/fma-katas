using System;

namespace PlaySlip.Application
{
    public sealed class DateHelper
    {
        public static string ToFormattedDate(DateTime date) 
        {
            return date.ToString("MMMM dd, yyyy");  
        }

    }
}