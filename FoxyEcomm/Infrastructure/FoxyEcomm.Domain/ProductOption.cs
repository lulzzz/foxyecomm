using System;
using FoxyEcomm.Common.Attributes;
using FoxyEcomm.Common.Models;
using FoxyEcomm.Domain.Events;

namespace FoxyEcomm.Domain
{
    public class ProductOption : AggregateRoot<Guid>
    {
        public Guid OptionGroupId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid OptionId { get; private set; }

        public decimal Price { get; private set; }

        public ProductOption()
        {
            ApplyEvent(new ProductOptionCreatedEvent(Guid.Empty));
        }

        public ProductOption(Guid id)
        {
            ApplyEvent(new ProductOptionCreatedEvent(id));
        }

        public ProductOption(Guid id, Guid productId, Guid optionGroupId,Guid optionId , decimal price)
        {
            ApplyEvent(new ProductOptionCreatedEvent(id, productId, optionGroupId, optionId, price));
        }

     
        [InlineEventHandler]
        private void HandleProductOptionCreatedEvent(ProductOptionCreatedEvent evnt)
        {
            this.Id = (Guid)evnt.AggregateRootKey;
            this.ProductId = evnt.ProductId;
            this.OptionGroupId = evnt.OptionGroupId;
            this.OptionId = evnt.OptionId;
            this.Price = evnt.Price;
        }
    }
}
