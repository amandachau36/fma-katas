using System.Threading;

namespace ConferenceTrack.Client
{
    public class Talk
    {
        public string TalkTitle { get; }
        public double Duration { get; }
        public bool IsAllocated { get; private set; }

        public Talk( string talkTitle, double duration)
        {
            TalkTitle = talkTitle;
            Duration = duration;
            IsAllocated = false;
        }

        public void UpdateIsAllocated(bool isAllocated)
        {
            IsAllocated = isAllocated;
        }
        
    }
}