using System;
using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Domain.Commands
{
    public class CreateOptionCommand : Command
    {
        public Guid OptionId { get; set; }

        public string Name { get; set; }
    }
}
