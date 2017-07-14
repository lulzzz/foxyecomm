using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Common.Models;
using FoxyEcomm.Domain.Commands;
using FoxyEcomm.Orm.Interfaces;
using FoxyEcomm.Services.Common;
using FoxyEcomm.Services.Common.Attributes;
using FoxyEcomm.Services.Inventory.Entities;
using FoxyEcomm.Services.Inventory.Models;

namespace FoxyEcomm.Services.Inventory
{

    [RoutePrefix("api/inventory")]
    public class InventoryController :
        MicroserviceApiController<InventoryService>
    {
        public InventoryController(FoxyEcommConfiguration configuration,
            ICommandSender commandSender,
            IEnumerable<Lazy<IDapperRepository, NamedMetadata>> dataProvider)
            : base(configuration, commandSender, dataProvider)
        {
        }

        [HttpGet]
        [VersionedRoute("system/info", 1)]
        public IHttpActionResult GetSystemInformation()
        {
            return Ok(new
            {
                Service = "Inventory Service",
                Date = DateTime.Now
            });
        }

        [HttpPost]
        [VersionedRoute("", 1)]
        public IHttpActionResult Create([FromBody] CreateProductRequest request)
        {
            if (ModelState.IsValid)
            {

                var id = Guid.NewGuid();
                var command = new CreateProductCommand()
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    BrandId = request.BrandId,
                    ProductId = id,
                    Code = request.Code,
                    Vat = request.Vat,
                    UnitPrice = request.UnitPrice,
                    Stock = request.Stock,
                    ShortDesc = request.ShortDescription,
                    LongDesc = request.LongDescription
                };
                CommandSender.Publish(command);
                return Created(string.Empty, id);

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
       

        [HttpGet]
        [VersionedRoute("", 1)]
        public async Task<IHttpActionResult> GetProducts()
        {
            return Ok(await this.DataProvider.FindAllAsync<ProductEntity>());
        }

        [HttpGet]
        [VersionedRoute("{id}/details", 1)]
        public async Task<IHttpActionResult> GetProduct(Guid id)
        {
            return Ok(await this.DataProvider.FindAsync<ProductEntity>(p => p.Id == id));
        }
    }
}

