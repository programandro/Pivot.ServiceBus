using System;
using System.Threading.Tasks;

namespace PreQ
{
    internal interface IQueueChannel : IDisposable
    {
        Task Publish(string queueAddress, byte[] bytes);
    }
}