namespace FoxyEcomm.Common.Interfaces
{
    public interface IDomainEventHandler
    {

    }

    public interface IDomainEventHandler<TEvent> : IHandler<TEvent>, IDomainEventHandler
        where TEvent : class, IDomainEvent
    {
    }
}
