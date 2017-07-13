using System;
using System.Threading.Tasks;
using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Domain;
using FoxyEcomm.Domain.Commands;

namespace FoxyEcomm.Services.Inventory
{
    internal sealed class InventoryCommandHandler :
        ICommandHandler<CreateProductCommand>,
        ICommandHandler<CreateProductPropertyCommand>,
        ICommandHandler<CreateOptionGroupCommand>,
        ICommandHandler<CreateOptionCommand>,
        ICommandHandler<CreateProductOptionCommand>
    {
        private readonly IDomainRepository _domainRepository;

        public InventoryCommandHandler(IDomainRepository domainRepository)
        {
            this._domainRepository = domainRepository;
        }

        public async Task HandleAsync(CreateProductCommand message)
        {
            var entity = new Product(message.ProductId, message.Code, message.Name, message.Stock, message.UnitPrice,
                message.Vat, message.BrandId, message.ShortDesc, message.LongDesc);
            await this._domainRepository.SaveAsync<Guid, Product>(entity);
        }

        public async Task HandleAsync(CreateProductPropertyCommand message)
        {
            var entity = new ProductProperty(message.ProductPropertyId, message.ProductId, message.Key, message.Value);
            await this._domainRepository.SaveAsync<Guid, ProductProperty>(entity);
        }

        public async Task HandleAsync(CreateOptionGroupCommand message)
        {
            var entity = new OptionGroup(message.OptionGroupId, message.Name);
            await this._domainRepository.SaveAsync<Guid, OptionGroup>(entity);
        }

        public async Task HandleAsync(CreateOptionCommand message)
        {
            var entity = new Option(message.OptionId, message.Name);
            await this._domainRepository.SaveAsync<Guid, Option>(entity);
        }

        public async Task HandleAsync(CreateProductOptionCommand message)
        {
            var entity = new ProductOption(message.ProductId, message.ProductOptionId, message.OptionGroupId,
                message.OptionId, message.Price);
            await this._domainRepository.SaveAsync<Guid, ProductOption>(entity);
        }
    }
}
