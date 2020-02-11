using System;

namespace MagicYearCalculator
{
    public class MagicCalculator
    {
        // should I use short instead? It's okay to use int because memory is not that expensive these days
        public int MagicYear(int workStartYear)
        {
            return workStartYear + 65;
        }

        public decimal MonthlySalary(decimal annualSalary)
        {
            // float, double, decimal
            // always use decimals with $$$$
            // leave decimal until point before presentation
            // use cast sparingly 
            // just use decimals for this one
            //https://stackoverflow.com/questions/618535/difference-between-decimal-float-and-double-in-net
            return annualSalary / 12;
        }

        public decimal RoundedMonthlySalary(decimal monthlySalary)
        {
            
            return Math.Round(monthlySalary);
        }
        
        public string FullName(string firstName, string lastName)
        {
            
            return firstName + " " + lastName;
        }

        public void RunMagicCalc()
        {

            Console.WriteLine("Welcome to the magic year! ");
            Console.Write("\n Please input your name: ");
            var firstName = Console.ReadLine();
            
            Console.Write("\n Please enter your surname: ");
            var lastName = Console.ReadLine();
            
            Console.Write("\n Please enter your annual salary: ");
            int annualSalary;
            var validAnnualSalary = Int32.TryParse(Console.ReadLine(), out annualSalary );
            
            Console.Write("\n Please enter your work start year: ");
            int startYear;
            var validStartYear =  Int32.TryParse(Console.ReadLine(), out startYear );
            
            if (validAnnualSalary && validStartYear)
                Console.WriteLine(@"Your magic age details are
Name: {0}
Monthly Salary: {1}
Magic Year: {2}", FullName(firstName, lastName), RoundedMonthlySalary(MonthlySalary(annualSalary)), MagicYear(startYear) );
            else
                Console.WriteLine("Either annual salary or start year are invalid");

        }
        
        
        
        
        
            
    }
}