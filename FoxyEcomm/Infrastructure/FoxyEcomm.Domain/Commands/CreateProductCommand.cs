using System;
using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Domain.Commands
{
    public class CreateProductCommand : Command
    {
        public Guid ProductId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Vat { get; set; }

        public Guid BrandId { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }
    }
}
