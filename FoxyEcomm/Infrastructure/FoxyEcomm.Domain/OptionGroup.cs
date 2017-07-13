using System;
using FoxyEcomm.Common.Attributes;
using FoxyEcomm.Common.Models;
using FoxyEcomm.Domain.Events;

namespace FoxyEcomm.Domain
{
    public class OptionGroup : AggregateRoot<Guid>
    {
        public string Name { get; private set; }
        

        public OptionGroup()
        {
            ApplyEvent(new OptionGroupCreatedEvent(Guid.Empty));
        }

        public OptionGroup(Guid id)
        {
            ApplyEvent(new OptionGroupCreatedEvent(id));
        }

        public OptionGroup(Guid id,string name)
        {
            ApplyEvent(new OptionGroupCreatedEvent(id, name));
        }

     
        [InlineEventHandler]
        private void HandleOptionGroupCreatedEvent(OptionGroupCreatedEvent evnt)
        {
            this.Id = (Guid)evnt.AggregateRootKey;
            this.Name = evnt.Name;
        }
    }
}
