using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pivot.ServiceBus.Implementations
{
    public interface ISubcriptionBinder : IDisposable
    {
        IEnumerable<OutgoingSubscription> GetOutgoingSubscriptions(Type type);
        IEnumerable<IncommingSubscription> GetIncommingSubscriptions(Type type);
    }
}