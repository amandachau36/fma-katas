using System;
using ThreeTierArchitecture.Business.Interfaces;
using ThreeTierArchitecture.Business.Mentors.Models;
using ThreeTierArchitecture.Data;

namespace ThreeTierArchitecture.Business.Mentors.Services
{
    public class MentorForProtegeService
    {
        private string _protegeName;

        public MentorForProtegeService(string protegeName)
        {
            _protegeName = protegeName;
        }
        
        public ITimeStampedGroups GetMentorByProtegeName()  
        {
            var protegesAndMentorsRepository = new ProtegesAndMentorsRepository();

            var mentors = protegesAndMentorsRepository.GetMentors(_protegeName);

            return new TimeStampedMentors(DateTime.UtcNow, mentors);
        }
    }
}