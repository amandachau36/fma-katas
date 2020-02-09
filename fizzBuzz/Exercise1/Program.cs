using System;

namespace Exercise1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var fizz = new Fizz();
            
            fizz.PrintFizzBuzz();


        }
    }
}



// automated testing - the practice of writing code to test our code 
// and then run those tests in an automated fashion


// code = production code  + test code

// Benefits of automated testing - test your code frequently and in less time,
// find bugs before deployment (reduce but not eliminate)
// deploy with confidence
// also allows for refactoring confidently
// focus more on quality 

// Unit test - tests a unit of an application without its **external dependencies** 
// can be one or multiple classes 
// + Cheap to write and execute fast
// - don't give you a lot of confidence

// Integration test
// tests the applications with its **external dependencies**
// + give you more confidence
// - takes longer to execute

// End-to-end tests 
// Drives an application through its UI 
// EX. Selenium
// + give you the greatest confidence 
// - very SLOW, very BRITTLE

// Test pyramid
// % unit (include edge cases) > integration > E2E (not for edge cases)
// unit test - test complex logic
// integration test - interaction with the database 

//takeaways 
//Favour unit tests to e2e test
//Cover unit test gaps with integration tests
//Use end-to-end tests sparingly

//testing frameworks = Library + Test Runner
//NUnit
//MSTest (built into VS)
//XUnit



//option F5 to run



