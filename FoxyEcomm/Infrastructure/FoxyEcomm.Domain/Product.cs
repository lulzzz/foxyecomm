using System;
using FoxyEcomm.Common.Attributes;
using FoxyEcomm.Common.Models;
using FoxyEcomm.Domain.Events;

namespace FoxyEcomm.Domain
{
    public class Product : AggregateRoot<Guid>
    {
        public string Name { get; private set; }

        public int Stock { get; private set; }

        public decimal UnitPrice { get; private set; }

        public decimal Vat { get; private set; }

        public string Code { get; private set; }

        public string ShortDescription { get; private set; }

        public string LongDescription { get; private set; }

        public DateTime Created { get; private set; }

        public Guid BrandId { get; private set; }

        public Product()
        {
            ApplyEvent(new ProductCreatedEvent(Guid.Empty));
        }

        public Product(Guid id)
        {
            ApplyEvent(new ProductCreatedEvent(id));
        }

        public Product(Guid id, string code, string name, int stock, decimal unitPrice, decimal vat, Guid brandId,
            string shortDesc, string longDesc)
        {
            ApplyEvent(new ProductCreatedEvent(id, code, name, stock, unitPrice, vat, brandId, shortDesc, longDesc));
        }


        [InlineEventHandler]
        private void HandleProductCreatedEvent(ProductCreatedEvent evnt)
        {
            this.Id = (Guid) evnt.AggregateRootKey;
            this.Name = evnt.Name;
            this.Code = evnt.Code;
            this.UnitPrice = evnt.UnitPrice;
            this.Vat = evnt.Vat;
            this.Stock = evnt.Stock;
            this.Created = evnt.Timestamp;
            this.BrandId = evnt.BrandId;
            this.ShortDescription = evnt.ShortDesc;
            this.LongDescription = evnt.LongDesc;
        }
    }
}
