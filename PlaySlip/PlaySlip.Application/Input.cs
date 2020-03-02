using System.Collections.Generic;

namespace PlaySlip.Application
{
    public class Input
    {
        public List<string> Prompts { get; }
        
        public IValidator Validator { get; }
        
        public string Error { get; }   
        
        public Input(List<string> prompts, IValidator validator, string error) 
        {
            Prompts = prompts;
            
            Validator = validator;
            
            Error = error;
        }
        
    }
}