namespace PlaySlip
{
    public class Employee
    {
        public string FirstName { get; } // properties
        public string LastName { get; }

        public Employee(string firstName, string lastName) //constructor
        {
            FirstName = firstName;
            LastName = lastName;
        }
        
        public string GenerateFullName()
        {
            return $"{FirstName} {LastName}";
        }
        
    }
}