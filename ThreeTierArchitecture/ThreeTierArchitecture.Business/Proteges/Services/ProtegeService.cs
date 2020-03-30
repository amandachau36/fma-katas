using System;
using System.Collections.Generic;
using ThreeTierArchitecture.Business.Interfaces;
using ThreeTierArchitecture.Business.Proteges.Models;
using ThreeTierArchitecture.Data;
using ThreeTierArchitecture.Data.Proteges.Repositories;

namespace ThreeTierArchitecture.Business.Proteges.Services
{
    public class ProtegeService : IMemberService
    {
        public ITimeStampedGroups GetMembers()
        {
            var protegesRepository = new ProtegesRepository(); // Add reference to dependencies

            var proteges = protegesRepository.GetProteges();
            
            return new TimeStampedProteges(DateTime.UtcNow, proteges);
        }

      
    }
}


