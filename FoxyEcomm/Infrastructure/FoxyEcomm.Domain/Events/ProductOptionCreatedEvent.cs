using System;
using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Domain.Events
{
    public class ProductOptionCreatedEvent : DomainEvent
    {
        public Guid ProductId { get; set; }
        public Guid OptionGroupId { get; set; }

        public Guid OptionId { get; set; }
        public decimal  Price { get; set; }

        protected ProductOptionCreatedEvent() { }

        public ProductOptionCreatedEvent(object aggregateRootKey) : base(aggregateRootKey) { }

        public ProductOptionCreatedEvent(object aggregateRootKey,Guid productId, Guid optionGroupId, Guid optionId , decimal price)
            :base(aggregateRootKey)
        {
            this.ProductId = productId;
            this.OptionGroupId = optionGroupId;
            this.OptionId = optionId;
            this.Price = price;
        }
    }
}
