using System;

namespace Watch
{
    public class Stopwatch
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        public DateTime StartTime { get; private set; }                            // not a big deal that it's public because it has a private set, alternatively use private field but cannot be tested 

        private bool _isTimerRunning;                                              // default is initialised to false
        public Stopwatch(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        
        public void Start()
        {
                                                                                // Do validation first!!! Good job
            if (_isTimerRunning)                                                // System vs custom - custom gives you more info in the try/catch block without depending on message
                throw new InvalidStopWatchOperationException("Cannot start stopwatch twice in a row");
            
            StartTime = _dateTimeProvider.Now();
            
            _isTimerRunning = true;
        }

        public TimeSpan Stop()
        {
            if(!_isTimerRunning)                                                //can also do this validation
                throw new InvalidStopWatchOperationException("Stopwatch is not running");
           
            _isTimerRunning = false;
            return _dateTimeProvider.Now() - StartTime;
        }
        
        
        
    }
}



