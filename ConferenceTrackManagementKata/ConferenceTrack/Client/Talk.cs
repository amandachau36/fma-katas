using System;
using System.Threading;

namespace ConferenceTrack.Client
{
    public class Talk
    {
        public string TalkTitle { get; }
        public double Duration { get; }
        public bool IsAllocated { get; private set; }
        public TimeSpan TalkTime { get; private set; }

        public string FormattedTitleAndTime { get; private set; }

        public Talk( string talkTitle, double duration)
        {
            TalkTitle = talkTitle;
            Duration = duration;
            IsAllocated = false;
        }

        public void SetIsAllocated(bool isAllocated)
        {
            IsAllocated = isAllocated;
        }

        public void SetTalkTime(TimeSpan talkTime)
        {
            TalkTime = talkTime;
        }

        public void SetScheduledTalk(string scheduledTalk)
        {
            FormattedTitleAndTime = scheduledTalk;
        }
        
    }
}