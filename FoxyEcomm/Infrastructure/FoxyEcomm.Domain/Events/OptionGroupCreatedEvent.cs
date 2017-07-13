using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Domain.Events
{
    public class OptionGroupCreatedEvent : DomainEvent
    {

        public string Name { get; set; }

        protected OptionGroupCreatedEvent() { }

        public OptionGroupCreatedEvent(object aggregateRootKey) : base(aggregateRootKey) { }

        public OptionGroupCreatedEvent(object aggregateRootKey,string name)
            :base(aggregateRootKey)
        {
            this.Name = name;
        }
    }
}
