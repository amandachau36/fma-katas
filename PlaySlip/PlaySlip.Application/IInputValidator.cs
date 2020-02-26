// using System;
//
// namespace PlaySlip.Application
// {
//     public interface IInputValidator
//     {
//         bool isValid(InputTypes inputType, string input);
//     }
//
//     public class ConsoleInputValidator : IInputValidator
//     {
//         private readonly IDisplay _display;
//
//         public ConsoleInputValidator(IDisplay display)
//         {
//             _display = display;
//         }
//         public bool isValid(InputTypes inputType, string input)
//         {
//             switch (inputType)
//             {
//                 case InputTypes.Super:
//                     IsSuperValid(input);
//                     break;
//                 default:
//                     throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
//             }
//         }
//
//         private bool IsSuperValid(string superRate)
//         {
//             var inputSsNotValid = true;
//
//             while (inputSsNotValid)
//             {
//                 var decimalSuperRate = decimal.Parse(superRate);
//                 
//                 var maxSuper = 50;
//                 var minSuper = 0;
//
//                 if (decimalSuperRate > minSuper && decimalSuperRate < maxSuper)
//                     inputSsNotValid = false;
//             }
//
//             return true;
//         }
//     }
//
//     public enum InputTypes
//     {
//         Super,
//         Name,
//         AnnualSalary,
//         Date,
//         EndDate, 
//         
//         
//         
//     }
}