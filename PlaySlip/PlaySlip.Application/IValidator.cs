using System.Collections.Generic;

namespace PlaySlip.Application
 { 
     public interface IValidator
     {
         bool IsValid( List<string> input);
        
     }
 }


