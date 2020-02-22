namespace PlaySlip
{
    public class Employee
    {
        public string FirstName { get; } // properties 
        public string LastName { get; } // could do a private set for all these properties    
        public decimal AnnualSalary { get;  }

        public Employee(string firstName, string lastName, decimal annualSalary) //constructor
        {
            FirstName = firstName;    // only test constructor if it has logic
            LastName = lastName;
            AnnualSalary = annualSalary;
        }
        
        public string GenerateFullName()
        {
            return $"{FirstName} {LastName}";
        }
        
    }
}