using SocialConnect.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.IRepos
{
    public interface ILogsRepository
    {
        Task Add(Log message);
        Task AddMessage(string message);
    }
}
