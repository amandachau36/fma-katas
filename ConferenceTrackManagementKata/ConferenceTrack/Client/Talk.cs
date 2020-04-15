namespace ConferenceTrack.Client
{
    public class Talk
    {
        public string TalkTitle { get; }
        public int Duration { get; }

        public Talk( string talkTitle, int duration)
        {
            TalkTitle = talkTitle;
            Duration = duration;
        }
        
    }
}