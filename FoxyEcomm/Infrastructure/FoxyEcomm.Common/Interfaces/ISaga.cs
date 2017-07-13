using System;

namespace FoxyEcomm.Common.Interfaces
{
    public interface ISaga<TKey, TMessage> : IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
        where TMessage : IDomainEvent
    {
        void Transit(TMessage message);
    }
}
