using System;
using System.Collections.Generic;

namespace ThreeTierArchitecture.Business.Interfaces
{
    public interface ITimeStampedGroups  // okay to only have properties without methods. Another 
    {
        DateTime TimeStamp { get; }
        List<string> Members { get; }
        
    }
}