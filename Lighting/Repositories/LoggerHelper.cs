using Lighting.Core.Repositories;

namespace Lighting.Repositories
{
    public class LoggerHelper : ILoggerHelperRepository
    {
        private readonly ILogger<ILoggerFactory> _logger;
        public LoggerHelper(ILogger<ILoggerFactory> logger)
        {
            _logger = logger;
        }

        public void LogMessage(string message)
        { 
            _logger.LogInformation(message);
        }

        public void LogMessage(Exception ex)
        {
            _logger.LogError($"Error:{ex.Message},\n {ex.StackTrace}");
        }
    }
}
