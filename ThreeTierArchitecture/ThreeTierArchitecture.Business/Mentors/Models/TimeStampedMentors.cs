using System;
using System.Collections.Generic;
using ThreeTierArchitecture.Business.Interfaces;

namespace ThreeTierArchitecture.Business.Mentors.Models
{
    public class TimeStampedMentors : ITimeStampedGroups
    {
        public DateTime TimeStamp { get;  }
        
        public List<string> Members { get; }

        public TimeStampedMentors(DateTime timeStamp, List<string> mentors)
        {
            TimeStamp = timeStamp;
            Members = mentors;
        }
    }
}