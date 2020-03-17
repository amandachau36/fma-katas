using System.Collections.Generic;

namespace WorkEngineKata
{
    public class Workflow : IWorkflow
    {
        
        private readonly List<IActivity> _activities; // implementation details 
        
        public Workflow()
        {
            _activities = new List<IActivity>();
        }
        
        public void Add(IActivity activity)
        {
            _activities.Add(activity);
        }

        public void Remove(IActivity activity)
        {
            _activities.Remove(activity);
        }

        public IEnumerable<IActivity> GetTasks() // use IEnumerable otherwise will expose  private _activities. can't add or remove IEnumerable 
        {
            // returns a readonly version of your internal list
            return _activities;
        }
    }
}