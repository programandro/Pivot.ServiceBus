using System;

namespace Pivot.ServiceBus.Implementations
{
    internal class WiredMessage
    {
        public WiredMessage(string address, Guid correlationId, object content)
        {
            Address = address;
            CorrelationId = correlationId;
            Content = content;
        }

        public string Address { get; }
        public Guid CorrelationId { get; }
        public object Content { get; }
    }
}