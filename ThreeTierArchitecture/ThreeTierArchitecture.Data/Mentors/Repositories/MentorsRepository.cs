using System.Collections.Generic;

namespace ThreeTierArchitecture.Data.Mentors.Repositories
{
    public class MentorsRepository
    {
        public List<string> GetMentors()
        {
            return new List<string>
            {
                "Sam",
                "Justin",
                "James",
                "Simon",
                "Srikanth",
                "Sumanth",
                "Amr"
            };
        }
    }
}