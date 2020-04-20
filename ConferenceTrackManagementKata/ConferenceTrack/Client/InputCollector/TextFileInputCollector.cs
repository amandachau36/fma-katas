namespace ConferenceTrack.Client.InputCollector
{
    public class TextFileInputCollector : IInputCollector
    {
        public string[] Collect(string path)
        {
             return System.IO.File.ReadAllLines(path);
        }
        
    }
}