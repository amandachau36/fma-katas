using System.Collections.Generic;

namespace PlaySlip.Application
{
    public class NameValidator : IValidator
    {
        public bool IsValid(List<string> input)
        {
            return !string.IsNullOrWhiteSpace(input[0]);
        }
    }
}