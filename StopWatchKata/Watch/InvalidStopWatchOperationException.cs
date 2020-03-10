using System;

namespace Watch
{
    public class InvalidStopWatchOperationException : Exception  //look at argument exceptions
    {
        
        public InvalidStopWatchOperationException(string message) : base(message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
        }
    }
}