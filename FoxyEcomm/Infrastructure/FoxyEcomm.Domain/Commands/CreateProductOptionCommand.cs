using System;
using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Domain.Commands
{
    public class CreateProductOptionCommand : Command
    {

        public Guid ProductOptionId { get; set; }
        public Guid ProductId { get; set; }
        public Guid OptionGroupId { get; set; }

        public Guid OptionId { get; set; }

        public decimal Price { get; set; }
    }
}
