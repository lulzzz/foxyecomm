using System;
using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Domain.Events
{
    public class ProductCreatedEvent : DomainEvent
    {

        public string Code { get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Vat { get; set; }

        public Guid BrandId { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        protected ProductCreatedEvent() { }

        public ProductCreatedEvent(object aggregateRootKey) : base(aggregateRootKey) { }

        public ProductCreatedEvent(object aggregateRootKey,string code, string name, int stock,decimal unitprice,decimal vat, Guid brandId,string shortDesc,string longDesc)
            :base(aggregateRootKey)
        {
            this.Name = name;
            this.Code = code;
            this.UnitPrice = unitprice;
            this.Vat = vat;
            this.Stock = stock;
            this.BrandId = brandId;
            this.ShortDesc = shortDesc;
            this.LongDesc = longDesc;
        }
    }
}
