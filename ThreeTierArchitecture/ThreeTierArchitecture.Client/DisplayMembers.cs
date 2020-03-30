using System;
using ThreeTierArchitecture.Business;
using ThreeTierArchitecture.Business.Interfaces;
using ThreeTierArchitecture.Business.Mentors.Services;

namespace ThreeTierArchitecture.Client
{
    public class DisplayMembers
    {
        // private readonly IMemberService _memberService; // strategy pattern
        //
        // public DisplayMembers(IMemberService memberService)
        // {
        //     _memberService = memberService; // dependency injection
        //     
        // }

        public void Display(IMemberService memberService)
        {
            var timeStampedMembers = memberService.GetMembers();
            
            DisplayTimeStampAndMembers(timeStampedMembers);
            
        }

        public void Display(string protegeName)
        {
            var timeStampedMembers = new MentorForProtegeService(protegeName).GetMentorByProtegeName();
            
            DisplayTimeStampAndMembers(timeStampedMembers);
        
        }

        private void DisplayTimeStampAndMembers(ITimeStampedGroups timeStampedMembers)
        {
            Console.WriteLine(timeStampedMembers.TimeStamp);

            foreach (var member in timeStampedMembers.Members)
            {
                Console.WriteLine(member);
            }  
            
        }
        
    }
    
}