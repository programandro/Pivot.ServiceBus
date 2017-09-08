using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pivot.ServiceBus
{
    public sealed class MessageContext<T>
    {
        private IBusContext _context;
        public MessageContext(IBusContext context)
        {
            _context = context;
        }

        public T Message { get; set; }
        public async Task Send(object message) => await _context.Send(message);
        public async Task Send(string endpoint, object message) => await _context.Send(endpoint, message);
        public async Task Publish(object message) => await _context.Publish(message);
        public async Task Notify(object message) => await _context.Notify(message);
        public async Task<object> Request(string endpoint, object message, TimeSpan timeOut) => await _context.Request(endpoint, message, timeOut);
        public async Task<object> Request(object message, TimeSpan timeOut) => await _context.Request(message, timeOut);
    }
}
