using System;

namespace FoxyEcomm.Common.Interfaces
{
    public interface IMessageConsumer : IDisposable
    {
        IMessageSubscriber Subscriber { get; }
    }
}
