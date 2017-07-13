using System;

namespace FoxyEcomm.Common.Interfaces
{
    public interface IDomainEvent
    {
        Guid Id { get; }

        object AggregateRootKey { get; set; }

        string AggregateRootType { get; set; }

        DateTime Timestamp { get; }
    }
}
