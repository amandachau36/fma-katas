using System.Collections.Generic;

namespace PlaySlip.Application
{
    public interface IDisplay // output display and another IinputProcessor display
    {
        void Display(string message);
        void Display(IEnumerable<string> messages);
        
    }
}