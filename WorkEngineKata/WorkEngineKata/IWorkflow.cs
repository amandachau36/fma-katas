using System.Collections.Generic;

namespace WorkEngineKata
{
    public interface IWorkflow
    {
        void Add(IActivity activity);

        void Remove(IActivity activity);

        public IEnumerable<IActivity> GetTasks();
    }
}