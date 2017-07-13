using System;
using FoxyEcomm.Common.Attributes;
using FoxyEcomm.Common.Models;
using FoxyEcomm.Domain.Events;

namespace FoxyEcomm.Domain
{
    public class ProductProperty : AggregateRoot<Guid>
    {
        public string Key { get; private set; }

        public string Value { get; private set; }

        public Guid ProductId { get; private set; }

        public ProductProperty()
        {
            ApplyEvent(new ProductPropertyCreatedEvent(Guid.Empty));
        }

        public ProductProperty(Guid id)
        {
            ApplyEvent(new ProductPropertyCreatedEvent(id));
        }

        public ProductProperty(Guid id, Guid productId,string key ,string value)
        {
            ApplyEvent(new ProductPropertyCreatedEvent(id, productId, key, value));
        }

     
        [InlineEventHandler]
        private void HandleProductPropertyCreatedEvent(ProductPropertyCreatedEvent evnt)
        {
            this.Id = (Guid)evnt.AggregateRootKey;
            this.ProductId = evnt.ProductId;
            this.Key = evnt.Key;
            this.Value = evnt.Value;
        }
    }
}
