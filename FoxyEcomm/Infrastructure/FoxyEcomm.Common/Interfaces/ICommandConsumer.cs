using System.Collections.Generic;

namespace FoxyEcomm.Common.Interfaces
{
    public interface ICommandConsumer : IMessageConsumer
    {
        IEnumerable<ICommandHandler> CommandHandlers { get; }
    }
}
