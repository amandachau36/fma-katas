namespace InversionOfControl
{
    public interface IServiceA
    {
        int CalculateA();
    }

    public class ServiceA : IServiceA
    {
        private readonly IServiceB _serviceB;
        private readonly IMyLogger _myLogger;

        public ServiceA(IServiceB serviceB, IMyLogger myLogger)
        {
            _myLogger = myLogger;
            _serviceB = serviceB;
        }
        
        public int CalculateA()
        {
            _myLogger.Log("ServiceA");
            return 10 * _serviceB.CalculateB();
        }
    }

 
}