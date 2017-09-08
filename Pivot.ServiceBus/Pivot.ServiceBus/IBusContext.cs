using System;
using System.Threading.Tasks;

namespace Pivot.ServiceBus
{
    internal interface IBusContext
    {
        Task Send(object message);
        Task Send(string endpoint, object message);
        Task Publish(object message);
        Task Notify(object message);
        Task<object> Request(string endpoint, object message, TimeSpan timeOut);
        Task<object> Request(object message, TimeSpan timeOut);
    }
}