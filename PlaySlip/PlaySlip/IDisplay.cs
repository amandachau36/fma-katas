using System;

namespace PlaySlip
{
    public interface IDisplay
    {
        void DisplayWelcomeMessage();
        void DisplayFirstNamePrompt();

        void DisplayGeneralError();

        void DisplayLastNamePrompt();

        void DisplayAnnualSalaryPrompt();

        void DisplayAnnualSalaryErrorMessage();

        void DisplaySuperRatePrompt();

        void DisplaySuperRateErrorMessage();

        void DisplayPaymentStartDatePrompt();

        void DisplayPaymentEndDatePrompt();

        void DisplayDateErrorMessage();

        public void DisplayGeneratedPayslip(string fullName, string startDate, string endDate, decimal grossIncome,
            decimal incomeTax, decimal netIncome, decimal super);

    }
}