using System;
using System.Threading.Tasks;
using FoxyEcomm.Common.Extensions;
using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Domain.Events;
using FoxyEcomm.Orm.Interfaces;
using FoxyEcomm.Services.Inventory.Entities;

namespace FoxyEcomm.Services.Inventory
{
    internal sealed class InventoryEventHandler :
        IDomainEventHandler<ProductCreatedEvent>,
        IDomainEventHandler<ProductPropertyCreatedEvent>,
        IDomainEventHandler<OptionGroupCreatedEvent>,
        IDomainEventHandler<OptionCreatedEvent>,
        IDomainEventHandler<ProductOptionCreatedEvent>
    {
        private readonly IDapperRepository _dataProvider;

        public InventoryEventHandler(
            IDapperRepository dataProvider)
        {
            this._dataProvider = dataProvider;
        }

        public async Task HandleAsync(ProductCreatedEvent message)
        {
            await this._dataProvider.InsertAsync(new ProductEntity()
            {
                Id = message.AggregateRootKey.ToString().ToGuid(),
                Name = message.Name,
                Code = message.Code,
                Stock = message.Stock,
                UnitPrice = message.UnitPrice,
                Vat = message.Vat,
                BrandId = message.BrandId,
                ShortDesc = message.ShortDesc,
                LongDesc = message.LongDesc,
                Created = DateTime.Now,
                UpdateTime = DateTime.Now
            });
        }

        public async Task HandleAsync(ProductPropertyCreatedEvent message)
        {
            await this._dataProvider.InsertAsync(new ProductPropertyEntity()
            {
                Id = message.AggregateRootKey.ToString().ToGuid(),
                ProductId = message.ProductId,
                Key = message.Key,
                Value = message.Value
            });
        }
        public async Task HandleAsync(OptionGroupCreatedEvent message)
        {
            await this._dataProvider.InsertAsync(new OptionGroupEntity()
            {
                Id = message.AggregateRootKey.ToString().ToGuid(),
                Name = message.Name
            });
        }

        public async Task HandleAsync(OptionCreatedEvent message)
        {
            await this._dataProvider.InsertAsync(new OptionEntity()
            {
                Id = message.AggregateRootKey.ToString().ToGuid(),
                Name = message.Name
            });
        }

        public async Task HandleAsync(ProductOptionCreatedEvent message)
        {
            await this._dataProvider.InsertAsync(new ProductOptionEntity()
            {
                Id = message.AggregateRootKey.ToString().ToGuid(),
                ProductId = message.ProductId,
                OptionGroupId = message.OptionGroupId,
                OptionId = message.OptionId,
                Price = message.Price
            });
        }
    }
}
