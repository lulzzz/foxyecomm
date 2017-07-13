using System;
using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Common.Interfaces
{
    public interface IMessageSubscriber : IDisposable
    {
        void Subscribe();

        event EventHandler<MessageReceivedEventArgs> MessageReceived;
    }
}
