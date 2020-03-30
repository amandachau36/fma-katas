using System;
using ThreeTierArchitecture.Business.Interfaces;
using ThreeTierArchitecture.Business.Mentors.Models;
using ThreeTierArchitecture.Data.Mentors.Repositories;

namespace ThreeTierArchitecture.Business.Mentors.Services
{
    public class MentorService : IMemberService
    {
        
        public ITimeStampedGroups GetMembers()
        {
            var mentorsRepository = new MentorsRepository();

            var mentors = mentorsRepository.GetMentors();
            
            return new TimeStampedMentors(DateTime.UtcNow, mentors);
        }

    
    }
}