using System;
using System.Collections.Generic;
using ThreeTierArchitecture.Business.Interfaces;

namespace ThreeTierArchitecture.Business.Proteges.Models
{
    public class TimeStampedProteges : ITimeStampedGroups
    {
        public DateTime TimeStamp { get; }
        
        public List<string> Members { get; }

        public TimeStampedProteges(DateTime timeStamp, List<string> proteges)
        {
            TimeStamp = timeStamp;
            Members = proteges;
        }
        
    }
}