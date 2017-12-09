using System;
using System.Threading.Tasks;

namespace Pivot.ServiceBus.Implementations
{
    public interface IChannel : IDisposable
    {
        string Address { get; }

        Task Send(string address, byte[] bytes);
        Task StartListening();
        byte[] GetNextBytes();
    }
}