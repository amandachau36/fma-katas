using System;
using System.Collections.Generic;

namespace WorkEngineKata
{
    public class WorkFlowEngine
    {
       
        
        public void Run(IWorkflow workflow)
        {
            foreach (var activity in workflow.GetTasks())
            {
                try
                {
                    activity.Execute();
                }
                catch (Exception e)
                {
                    // logging
                    // Terminate and persist the state of the workflow
                    throw;
                }
                
            }
        }

  
    }
}