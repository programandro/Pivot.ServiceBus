using System;

namespace Pivot.ServiceBus.Implementations
{
    public class OutgoingSubscription
    {
        public Type Type { get; set; }
        public string[] Addresses { get; set; }
    }
}