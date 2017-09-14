using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreQ
{
    public interface ISubcriptionBinder : IDisposable
    {
        Task<IEnumerable<Subscription>> GetSubscriptions(string endpoint, Type type);
    }
}