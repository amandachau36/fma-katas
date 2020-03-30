namespace InversionOfControl
{
    public class ServiceC : IServiceC
    {
        private readonly IMyLogger _logger;

        public ServiceC(IMyLogger logger)
        {
            _logger = logger;
        }
        public int CalculateC()
        {
            _logger.Log("service C");
            return 2;
        }
    }

    public interface IServiceC
    {
        int CalculateC();
    }
}