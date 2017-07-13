using System;
using FoxyEcomm.Common.Attributes;
using FoxyEcomm.Common.Models;
using FoxyEcomm.Domain.Events;

namespace FoxyEcomm.Domain
{
    public class Option : AggregateRoot<Guid>
    {
        public string Name { get; private set; }
        
        

        public Option()
        {
            ApplyEvent(new OptionCreatedEvent(Guid.Empty));
        }

        public Option(Guid id)
        {
            ApplyEvent(new OptionCreatedEvent(id));
        }

        public Option(Guid id,string name)
        {
            ApplyEvent(new OptionCreatedEvent(id, name));
        }

     
        [InlineEventHandler]
        private void HandleOptionCreatedEvent(OptionCreatedEvent evnt)
        {
            this.Id = (Guid)evnt.AggregateRootKey;
            this.Name = evnt.Name;
        }
    }
}
