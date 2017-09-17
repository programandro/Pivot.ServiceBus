using System;
using System.Threading.Tasks;

namespace Pivot.ServiceBus
{
    public interface IBus
    {
        Task Start();
        Task Stop();
        Task Send(object message);
        Task Send(string endpoint, object message);
        Task Publish(object message);
        Task Notify(object message);
        Task<object> Request(string endpoint, object message, TimeSpan timeOut);
    }
}
  