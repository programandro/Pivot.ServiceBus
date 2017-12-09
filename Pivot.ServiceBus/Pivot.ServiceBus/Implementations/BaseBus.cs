using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pivot.ServiceBus.Implementations
{
    public abstract class BaseBus : IBus
    {
        protected IChannel _channel;
        protected ISerializer _serializer;
        protected ISubcriptionBinder _binder;
        protected bool _isRunning;
        private Task _receivingTask;

        public BaseBus(IChannel channel, ISerializer serializer, ISubcriptionBinder binder)
        {
            _channel = channel;
            _serializer = serializer;
            _binder = binder;
            _isRunning = false;
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _serializer?.Dispose();
        }

        public async Task Publish(object message)
        {
            if (message == null)
                throw new NullReferenceException("Message can't be null");

            var subscriptions = (await _binder.GetOutgoingSubscriptions(message.GetType()))?.ToList();
            if (subscriptions != null && subscriptions.Count > 0)
            {                
                var tasks = subscriptions.SelectMany(s => s.Addresses).Distinct().Select(a => Send(a, message));
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

            var type = message.GetType();
            var subscriptions = (await _binder.GetOutgoingSubscriptions(type))?.ToList();
            if (subscriptions != null && subscriptions.Count > 0)
            {
                var addresses = subscriptions.SelectMany(s => s.Addresses).Distinct().ToList();

                if (addresses.Count > 1)
                    throw new ArgumentException($"There is more than one address configured for type '{type}'");

                await Send(addresses[0], message);
            }
        }

        public async Task Send(string endpoint, object message)
        {
            if (message == null)
                throw new NullReferenceException("Message can't be null");

            var wiredMessage = new WiredMessage(_channel.Address, Guid.NewGuid(), message);
            var bytes = _serializer.Serialize(wiredMessage);
            await _channel.Send(endpoint, bytes);
        }

        public async Task Start()
        {
            await _channel.StartListening();            
            _isRunning = true;

            _receivingTask = Task.Run(() =>
                    {
                        while (_isRunning)
                        {
                            var bytes = _channel.GetNextBytes();
                            Receive(bytes);
                        }
                    });
        }

        private void Receive(byte[] bytes)
        {
            var wiredMessage = _serializer.Deserialize<WiredMessage>(bytes);
            if (wiredMessage?.Content == null)
                return;

            var consumerSubscriptions = _binder.GetIncommingSubscriptions(wiredMessage.Content.GetType());
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}