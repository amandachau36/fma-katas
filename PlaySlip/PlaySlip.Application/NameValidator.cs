namespace PlaySlip.Application
{
    public class NameValidator : IValidator
    {
        public bool IsValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}