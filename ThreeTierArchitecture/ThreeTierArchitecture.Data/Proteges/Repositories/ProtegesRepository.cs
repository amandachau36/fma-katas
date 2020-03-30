using System;
using System.Collections.Generic;

namespace ThreeTierArchitecture.Data.Proteges.Repositories
{
    public class ProtegesRepository
    {
        public List<string> GetProteges()  //pretend this is accessing a db
        {
            return new List<string>
            {
                "Amanda",
                "James",
                "Braden"
            };
        }
    }
}