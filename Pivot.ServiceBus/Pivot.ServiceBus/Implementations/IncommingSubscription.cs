using System;
using System.Collections.Generic;
using System.Text;

namespace Pivot.ServiceBus.Implementations
{
    public class IncommingSubscription
    {
        public Type Type { get; }
        public Type ConsumerType { get; }
    }
}
