// using System;

 namespace PlaySlip.Application
 {
     public interface IInputValidator
     {
         bool IsValid(InputTypes inputType, string input);  // are there situations where the input is not a string? 
     }
  

     public enum InputTypes
     {
         Super,
         Name,
         AnnualSalary,
         Date,
         EndDate,

     }
 
}