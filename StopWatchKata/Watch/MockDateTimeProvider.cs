using System;

namespace Watch
{
    public class MockDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return new DateTime(2020,02,02, 10, 0,0 );
        }
    }
}