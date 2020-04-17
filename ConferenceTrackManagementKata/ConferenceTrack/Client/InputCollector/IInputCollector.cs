namespace ConferenceTrack.Client.InputCollector
{
    public interface IInputCollector
    {
        string[] Collect(string path); //TODO: does this make sense when it collects input in the console? 

    }
}