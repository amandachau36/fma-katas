using System;
using ThreeTierArchitecture.Business.Mentors.Services;
using ThreeTierArchitecture.Business.Proteges.Services;


namespace ThreeTierArchitecture.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var displayMembers = new DisplayMembers();
            displayMembers.Display(new ProtegeService());
            
            displayMembers.Display(new MentorService());
            

            displayMembers.Display("James");
        }
    }
}

// var protegeService = new ProtegeService();
//
// var timeStampedProteges = protegeService.GetMembers();
//
// Console.WriteLine(timeStampedProteges.TimeStamp);
//
// foreach (var protege in timeStampedProteges.Members)
// {
//     Console.WriteLine(protege);
// }