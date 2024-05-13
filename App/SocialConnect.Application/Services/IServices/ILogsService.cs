using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Application.Services.IServices
{
    public interface ILogsService
    {
        Task SaveLogs(string message);
    }
}
