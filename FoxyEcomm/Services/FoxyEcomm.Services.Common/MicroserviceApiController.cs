using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Common.Models;
using FoxyEcomm.Orm.Interfaces;

namespace FoxyEcomm.Services.Common
{
    [EnableCors("*","*","*",SupportsCredentials = true)]
    public abstract class MicroserviceApiController<TService> : ApiController
        where TService : Microservice
    {
        private readonly FoxyEcommConfiguration _configuration;
        private readonly ICommandSender _commandSender;
        private readonly IDapperRepository _dataProvider;

        protected MicroserviceApiController(FoxyEcommConfiguration configuration,
            ICommandSender commandSender,
            IEnumerable<Lazy<IDapperRepository, NamedMetadata>> dataProvider)
        {
            this._configuration = configuration;
            this._commandSender = commandSender;
            this._dataProvider = dataProvider.First(x => x.Metadata.Name == $"{typeof(TService).FullName}.DataProvider").Value;
        }

        protected FoxyEcommConfiguration FoxyEcommConfiguration => _configuration;

        protected ICommandSender CommandSender => _commandSender;

        protected IDapperRepository DataProvider => _dataProvider;
    }
}
