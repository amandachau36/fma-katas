namespace PlaySlip
{
    public interface IDisplay
    {
        void DisplayFirstNamePrompt();

        void DisplayLastNamePrompt();

        void DisplayAnnualSalaryPrompt();

        void DisplayAnnualSalaryErrorMessage();

        void DisplaySuperRatePrompt();

        void DisplaySuperRateErrorMessage();

        void DisplayPaymentStartDatePrompt();

        void DisplayPaymentEndDatePrompt();

        void DisplayDateErrorMessage();
        
        void DisplayGeneratedPayslip(); 
    }
}