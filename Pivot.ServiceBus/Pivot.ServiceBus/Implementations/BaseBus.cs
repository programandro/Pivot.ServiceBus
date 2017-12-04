using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pivot.ServiceBus.Implementations
{
    public abstract class BaseBus : IBus
    {
        protected IChannel _channel;
        protected ISerializer _serializer;
        protected IConsumerProvider _consumerProvider;

        public BaseBus(IChannel channel, ISerializer serializer, IConsumerProvider consumerProvider)
        {
            _channel = channel;
            _serializer = serializer;
            _consumerProvider = consumerProvider;
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _serializer?.Dispose();
        }

        public Task Publish(object message)
        {
            throw new NotImplementedException();
        }

        public Task<object> Request(string endpoint, object message, TimeSpan timeOut)
        {
            throw new NotImplementedException();
        }

        public Task<U> Request<T, U>(string endpoint, T message, TimeSpan timeOut)
        {
            throw new NotImplementedException();
        }

        public Task Send(object message)
        {
            throw new NotImplementedException();
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

public enum SendBehavior
{
    Spread
}