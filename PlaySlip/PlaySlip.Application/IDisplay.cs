using System;
using System.Collections.Generic;

namespace PlaySlip.Application
{
    public interface IDisplay // output display and another IinputProcessor display
    {                        

        void Display(string message);
        //void Display(List<string> messages);

        public void DisplayGeneratedPayslip(string fullName, DateTime startDate, DateTime endDate, decimal grossIncome,
            decimal incomeTax, decimal netIncome, decimal super);

    }
}