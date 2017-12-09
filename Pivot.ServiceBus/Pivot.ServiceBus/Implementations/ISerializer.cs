using System;

namespace Pivot.ServiceBus.Implementations
{
    public interface ISerializer : IDisposable
    {
        byte[] Serialize(object value);
        T Deserialize<T>(byte[] bytes);
    }
}