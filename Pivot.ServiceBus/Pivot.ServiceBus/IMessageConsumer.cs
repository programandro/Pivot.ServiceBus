using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pivot.ServiceBus
{
    public interface IMessageConsumer<T>
    {
        Task Consume(MessageContext<T> context);
    }

    public interface IMessageConsumer<TRequest, TResponse>
    {
        Task<TResponse> Process(MessageContext<TRequest> context);
    }
}
