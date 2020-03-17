

namespace WorkEngineKata
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var workflow = new Workflow();
            workflow.Add(new UploadVideo());
            workflow.Add(new NotifyWebService());
            workflow.Add(new NotifyVideoOwner());
            workflow.Add(new UpdateDatabase());
            
            var workflowEngine = new WorkFlowEngine();
            workflowEngine.Run(workflow);
        }
    }
}