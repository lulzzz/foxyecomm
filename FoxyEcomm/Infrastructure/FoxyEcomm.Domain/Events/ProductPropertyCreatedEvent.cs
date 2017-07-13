using System;
using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Domain.Events
{
    public class ProductPropertyCreatedEvent : DomainEvent
    {

        public string Key { get; set; }
        public string Value { get; set; }

        public Guid ProductId { get; set; }

        protected ProductPropertyCreatedEvent() { }

        public ProductPropertyCreatedEvent(object aggregateRootKey) : base(aggregateRootKey) { }

        public ProductPropertyCreatedEvent(object aggregateRootKey,Guid productId,string key, string value)
            :base(aggregateRootKey)
        {
            this.ProductId = productId;
            this.Key = key;
            this.Value = value;
        }
    }
}
