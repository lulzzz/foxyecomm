using System;
using System.Collections.Generic;
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
                var entity =
                    this.DataProvider.FindAsync<ProductEntity>(
                        ent =>
                            ent.Code == request.Code);
                var id = Guid.NewGuid();
                if (entity.Result == null)
                {
                    var command = new CreateProductCommand()
                    {
                        Id = Guid.NewGuid(),
                        Name = request.Name,
                        BrandId = request.BrandId,
                        ProductId = id,
                        Code= request.Code,
                        Vat = request.Vat,
                        UnitPrice = request.UnitPrice,
                        Stock = request.Stock,
                        ShortDesc = request.ShortDescription,
                        LongDesc = request.LongDescription
                    };
                    CommandSender.Publish(command);
                    return Created(string.Empty, id);
                }
                return BadRequest("Product already exists!");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [VersionedRoute("", 1)]
        public IHttpActionResult GetProducts()
        {
            return Ok(this.DataProvider.FindAll<ProductEntity>());
        }
        [HttpPost]
        [VersionedRoute("property", 1)]
        public IHttpActionResult Create([FromBody] CreateProductPropertyRequest request)
        {
            if (ModelState.IsValid)
            {
                var entity =
                    this.DataProvider.FindAsync<ProductPropertyEntity>(
                        ent =>
                            ent.ProductId == request.ProductId && ent.Key == request.Key && ent.Value == request.Value);
                var id = Guid.NewGuid();
                if (entity.Result == null)
                {
                    var command = new CreateProductPropertyCommand()
                    {
                        Id = Guid.NewGuid(),
                        ProductPropertyId = id,
                        ProductId = request.ProductId,
                        Key = request.Key,
                        Value = request.Value
                    };
                    CommandSender.Publish(command);
                    return Created(string.Empty, id);
                }
                return BadRequest("Product Property already exists!");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [VersionedRoute("options/group", 1)]
        public IHttpActionResult Create([FromBody] CreateOptionGroupRequest request)
        {
            if (ModelState.IsValid)
            {
                var entity =
                    this.DataProvider.FindAsync<OptionGroupEntity>(
                        ent =>
                            ent.Name == request.Name);
                var id = Guid.NewGuid();
                if (entity.Result == null)
                {
                    var command = new CreateOptionGroupCommand()
                    {
                        Id = Guid.NewGuid(),
                        Name = request.Name,
                        OptionGroupId = id
                    };
                    CommandSender.Publish(command);
                    return Created(string.Empty, id);
                }
                return BadRequest("Option Group already exists!");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost]
        [VersionedRoute("options/option", 1)]
        public IHttpActionResult Create([FromBody] CreateOptionRequest request)
        {
            if (ModelState.IsValid)
            {
                var entity =
                    this.DataProvider.FindAsync<OptionEntity>(
                        ent =>
                            ent.Name == request.Name);
                var id = Guid.NewGuid();
                if (entity.Result == null)
                {
                    var command = new CreateOptionCommand()
                    {
                        Id = Guid.NewGuid(),
                        Name = request.Name,
                        OptionId = id
                    };
                    CommandSender.Publish(command);
                    return Created(string.Empty, id);
                }
                return BadRequest("Option already exists!");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [VersionedRoute("option", 1)]
        public IHttpActionResult Create([FromBody] CreateProductOptionRequest request)
        {
            if (ModelState.IsValid)
            {
                var entity =
                    this.DataProvider.FindAsync<ProductOptionEntity>(
                        ent =>
                            ent.ProductId == request.ProductId && ent.OptionGroupId == request.OptionGroupId &&
                            ent.OptionId == request.OptionId);
                var id = Guid.NewGuid();
                if (entity.Result == null)
                {
                    var command = new CreateProductOptionCommand()
                    {
                        Id = Guid.NewGuid(),
                        ProductOptionId = id,
                        OptionGroupId = request.OptionGroupId,
                        Price = request.Price,
                        ProductId = request.ProductId,
                        OptionId = request.OptionId
                    };
                    CommandSender.Publish(command);
                    return Created(string.Empty, id);
                }
                return BadRequest("Option already exists!");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}

