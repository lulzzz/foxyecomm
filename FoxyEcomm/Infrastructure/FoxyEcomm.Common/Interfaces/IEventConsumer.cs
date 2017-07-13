using System.Collections.Generic;

namespace FoxyEcomm.Common.Interfaces
{
    public interface IEventConsumer : IMessageConsumer
    {
        IEnumerable<IDomainEventHandler> EventHandlers { get; }
    }
}
