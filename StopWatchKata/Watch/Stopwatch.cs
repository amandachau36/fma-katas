using System;

namespace Watch
{
    public class Stopwatch
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        
        //TODO: I think this should be a private field but then I can't test it 
        public DateTime StartTime { get; private set; } 
        
        public Stopwatch(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        
        public void Start()
        {
            StartTime = _dateTimeProvider.Now();
        }

        public TimeSpan Stop()
        {
            return _dateTimeProvider.Now() - StartTime;
        }
        
        
        
    }
}



