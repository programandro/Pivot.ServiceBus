using Pivot.ServiceBus;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PreQ
{
    public class Bus : IBus
    {
        private ISubcriptionBinder _binder;
        private IQueueChannel _channel;
        private IMessageSerializer _serializer;

        public void Dispose()
        {
            _binder?.Dispose();
            _channel?.Dispose();
            _serializer?.Dispose();
        }

        public async Task Publish(object message)
        {
            if (message == null)
                throw new NullReferenceException("Message can't be null");

            var subscriptions = (await _binder.GetSubscriptions(null, message.GetType()))?.ToArray();
            if (subscriptions != null && subscriptions.Length > 0)
            {
                var bytes = _serializer.Serialize(message);
                var tasks = subscriptions.SelectMany(s => s.Addresses).Distinct().Select(q => _channel.Publish(q, bytes));
                Task.WaitAll(tasks.ToArray());
            }
        }

        public Task<object> Request(string endpoint, object message, TimeSpan timeOut)
        {
            throw new NotImplementedException();
        }

        public Task<U> Request<T, U>(string endpoint, T message, TimeSpan timeOut)
        {
            throw new NotImplementedException();
        }

        public async Task Send(object message)
        {
            if (message == null)
                throw new NullReferenceException("Message can't be null");

            var subscriptions = (await _binder.GetSubscriptions(null, message.GetType()))?.ToArray();
            if (subscriptions != null && subscriptions.Length > 0)
            {
                var bytes = _serializer.Serialize(message);
                var tasks = subscriptions.SelectMany(s => s.Addresses).Distinct().Select(q => _channel.Publish(q, bytes));
                Task.WaitAll(tasks.ToArray());
            }
        }

        public Task Send(string endpoint, object message)
        {
            throw new NotImplementedException();
        }

        public Task Start()
        {
            throw new NotImplementedException();
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}
