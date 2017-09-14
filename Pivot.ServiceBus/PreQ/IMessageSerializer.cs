using System;

namespace PreQ
{
    internal interface IMessageSerializer : IDisposable
    {
        byte[] Serialize(object message);
    }
}