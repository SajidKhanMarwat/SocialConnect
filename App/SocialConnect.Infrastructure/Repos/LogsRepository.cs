using SocialConnect.Core.Context;
using SocialConnect.Core.Entities;
using SocialConnect.Core.IRepos;

namespace SocialConnect.Infrastructure.Repos
{
    public class LogsRepository : ILogsRepository
    {
        private SocialDbContext _context;
        public LogsRepository(SocialDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task Add(Log message)
        {
            await _context.Logs.AddAsync(message);
        }

        public async Task AddMessage(string message)
        {
            var entity = new Log()
            {
                Message = message,
            };
            await _context.Logs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
