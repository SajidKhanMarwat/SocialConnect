using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using SocialConnect.Application.Caching;

namespace SocialConnect.Infrastructure.Caching
{
    public class Cache<C> : ICache<C> where C : class
    {
    }
}
