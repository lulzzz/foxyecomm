using System;
using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Domain.Commands
{
    public class CreateProductPropertyCommand : Command
    {
        public Guid ProductPropertyId { get; set; }
        public Guid ProductId { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }
        
    }
}
