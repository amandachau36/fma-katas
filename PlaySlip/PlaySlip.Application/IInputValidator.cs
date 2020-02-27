// using System;

 namespace PlaySlip.Application
 {
     public interface IInputValidator
     {
         bool isValid(InputTypes inputType, string input);  // are there situations where the input is not a string? 
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