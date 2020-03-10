using System;

namespace Watch
{
    public class Stopwatch
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        public DateTime StartTime { get; private set; }                            // not a big deal that it's public

        private bool _isTimerRunning;
        public Stopwatch(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        
        public void Start()
        {
            if (_isTimerRunning)
                throw new InvalidStopWatchOperationException("Cannot start stopwatch twice in a row");
                                                                                // System vs custom - custom gives you more info in the try/catch block without depending on message

            StartTime = _dateTimeProvider.Now();
            
            _isTimerRunning = true;
        }

        public TimeSpan Stop()
        {
            _isTimerRunning = false;
            
            return _dateTimeProvider.Now() - StartTime;
        }
        
        
        
    }
}



