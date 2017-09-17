using System;
using System.Threading.Tasks;

namespace Pivot.ServiceBus
{
    public interface IBus : IDisposable
    {
        Task Start();
        Task Stop();
        Task Send(object message);
        Task Send(string endpoint, object message);
        Task Publish(object message);
        Task<object> Request(string endpoint, object message, TimeSpan timeOut);
        Task<U> Request<T, U>(string endpoint, T message, TimeSpan timeOut);
    }
}
  