namespace Lighting.Core.Repositories
{
    public interface ILoggerHelperRepository
    {
        void LogMessage(string message);
        void LogMessage(Exception ex);
    }
}
