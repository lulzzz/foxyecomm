using System;

namespace FoxyEcomm.Common.Interfaces
{
    public interface IMessagePublisher : IDisposable
    {
        void Publish<TMessage>(TMessage message);
    }
}
