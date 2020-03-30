using System;
using System.Collections.Generic;

namespace ThreeTierArchitecture.Data
{
    public class ProtegesAndMentorsRepository  //TODO: is it okay to have a data layer that doesn't have it's own distinct business layer
    // mentor service - get mentors by protege 
    // proteges service - 
    {
        private Dictionary<string, List<string>> ProtegesAndMentors = new Dictionary<string, List<string>>()
        {
            {"Amanda", new List<string>{"Sam", "James", "Justin"}},
            {"James", new List<string>{"Simon", "Srikanth"}}, 
            {"Braden", new List<string>{"Sumanth", "Amr"}}
        };
        
        public List<string> GetMentors(string protege) //TODO: throw error if protege does not exist
        {
            return ProtegesAndMentors[protege];
            
        } 
    }
}