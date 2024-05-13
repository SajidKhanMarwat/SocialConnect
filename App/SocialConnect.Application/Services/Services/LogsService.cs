using SocialConnect.Application.Services.IServices;
using SocialConnect.Core.IRepos;

namespace SocialConnect.Application.Services.Services
{
    //private ILogsRepository _logsRepository;
    public class LogsService : ILogsService
    {
        private ILogsRepository _logs;
        public LogsService(ILogsRepository logs)
        {
            _logs = logs;
        }

        public async Task SaveLogs(string message)
        {
            await _logs.AddMessage(message);
        }
    }
}
