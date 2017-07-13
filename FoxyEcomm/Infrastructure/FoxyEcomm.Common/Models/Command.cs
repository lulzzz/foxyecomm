using System;
using FoxyEcomm.Common.Interfaces;

namespace FoxyEcomm.Common.Models
{
    public abstract class Command : ICommand
    {
        public Command()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id
        {
            get; set;
        }
    }
}
