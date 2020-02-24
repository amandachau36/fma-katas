namespace PlaySlip
{
    public class Employee
    {
        public string FirstName { get; } // properties 
        public string LastName { get; } // could do a private set for all these properties    
        public decimal AnnualSalary { get;  }
        public decimal SuperRate { get;  }

        public Employee(string firstName, string lastName, decimal annualSalary, decimal superRate) //constructor
        {
            FirstName = firstName;    // only test constructor if it has logic
            LastName = lastName;
            AnnualSalary = annualSalary; // only set if positive integer
            SuperRate = superRate;

        }
        
        public string GenerateFullName()
        {
            return $"{FirstName} {LastName}";
        }
        
    }
}