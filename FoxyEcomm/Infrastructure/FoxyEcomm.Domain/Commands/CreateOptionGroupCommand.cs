using System;
using FoxyEcomm.Common.Models;

namespace FoxyEcomm.Domain.Commands
{
    public class CreateOptionGroupCommand : Command
    {
        public Guid OptionGroupId { get; set; }

        public string Name { get; set; }
    }
}
