namespace PlaySlip.Application
{
    public class NameValidator : IValidator
    {
        public bool IsValid(params string[] input)
        {
            return !string.IsNullOrWhiteSpace(input[0]);
        }
    }
}