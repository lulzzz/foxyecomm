using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Domain.Events
{
    public class OptionCreatedEvent : DomainEvent
    {

        public string Name { get; set; }

        protected OptionCreatedEvent() { }

        public OptionCreatedEvent(object aggregateRootKey) : base(aggregateRootKey) { }

        public OptionCreatedEvent(object aggregateRootKey,string name)
            :base(aggregateRootKey)
        {
            this.Name = name;
        }
    }
}
