namespace PlaySlip.Application
{
    public sealed class Constants
    {
        public const string DateErrorMessage =
            "Date must be entered in the following format Mar 1, 2017. Payment end date must occur AFTER payment start date. Try again.";

        public const string WelcomeMessage = "Welcome to the payslip generator";

        public const string FirstNamePrompt = "\nPlease input your first name: ";

        public const string LastNamePrompt = "\nPlease input your first name: ";
        
        public const string GeneralError = "There was an error. Please try again.";

        public const string AnnualSalaryPrompt = "\nPlease enter your annual salary: ";
        
        public const string AnnualSalaryErrorMessage = "Annual salary must be a positive number. Try again.";

        public const string SuperPrompt = "\nPlease enter your super rate: ";

        public const string SuperRateErrorMessage = "Super rate must be between 0% - 50%. Try again.";

        public const string PaymentStartDatePrompt = "\nPlease enter your payment start date (ex. Mar 1, 2017): ";

        public const string PaymentEndDatePrompt = "\nPlease enter your payment end date (ex. Mar 31, 2017): "; 

    }

    
}