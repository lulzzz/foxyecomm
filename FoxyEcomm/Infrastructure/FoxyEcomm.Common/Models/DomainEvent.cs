using System;
using FoxyEcomm.Common.Interfaces;

namespace FoxyEcomm.Common.Models
{
    public abstract class DomainEvent : IDomainEvent
    {
        protected DomainEvent() { }

        protected DomainEvent(object aggregateRootKey)
        {
            this.Id = Guid.NewGuid();
            this.AggregateRootKey = aggregateRootKey;
            this.Timestamp = DateTime.UtcNow;
            this.EventName = this.GetType().FullName;
        }

        public object AggregateRootKey { get; set; }

        public string AggregateRootType { get; set; }

        public string EventName { get; set; }

        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }

    }
}
