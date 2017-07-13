using System;
using System.Collections.Generic;
using Autofac;
using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Common.Models;
using FoxyEcomm.Orm.Interfaces;
using FoxyEcomm.PostgreSql;
using FoxyEcomm.Services.Common;
using FoxyEcomm.Services.Common.Exceptions;

namespace FoxyEcomm.Services.Inventory
{
    public sealed class InventoryServiceRegister : MicroserviceRegister<InventoryService>
    {
        private readonly string _connectionString;

        public InventoryServiceRegister(FoxyEcommConfiguration configuration) : base(configuration)
        {
            this._connectionString = ThisConfiguration?.Settings?.GetItemByKey("DataProviderConnectionString").Value;
            if (string.IsNullOrEmpty(this._connectionString))
            {
                throw new ServiceRegistrationException("Connection String for Data Provider has not been specified.");
            }
        }

        protected override Func<IComponentContext, IDapperRepository> DataProviderInitializer =>
            x => new PostgreSqlDataProvider(_connectionString);

      

        protected override IEnumerable<Func<IComponentContext, ICommandHandler>> CommandHandlersInitializer
        {
            get
            {
                yield return x => new InventoryCommandHandler(x.Resolve<IDomainRepository>());
            }
        }

        protected override IEnumerable<Func<IComponentContext, IDomainEventHandler>> EventHandlersInitializer
        {
            get
            {
                yield return x => new InventoryEventHandler(
                    this.ResolveDataProvider(x));
            }
        }

        protected override Func<ICommandConsumer, IEventConsumer, InventoryService> ServiceInitializer => 
            (cc, ec) => new InventoryService(cc, ec);

    
    }
}
