namespace InversionOfControl
{
    public class ServiceB : IServiceB
    {
        private readonly IServiceC _serviceC;
        private readonly IMyLogger _logger;

        public ServiceB(IServiceC serviceC, IMyLogger logger)
        {
            _logger = logger;
            _serviceC = serviceC;
        }
        public int CalculateB()
        {
            _logger.Log("Service B");
            return 5 * _serviceC.CalculateC();
        }
    }

    public interface IServiceB
    {
        int CalculateB();
    }
}