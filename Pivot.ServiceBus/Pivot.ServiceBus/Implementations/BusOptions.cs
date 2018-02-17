using System;
using System.Collections.Generic;

namespace Pivot.ServiceBus.Implementations
{
    public class BusOptions
    {
        public BusOptions()
        {
            SubscriptionsOptions = new Dictionary<Type, SubscriptionOptions>();
        }

        public Dictionary<Type, SubscriptionOptions> SubscriptionsOptions { get; }
        public SubscriptionOptions DefaultSubscriptionOptions { get; set; }
    }
}