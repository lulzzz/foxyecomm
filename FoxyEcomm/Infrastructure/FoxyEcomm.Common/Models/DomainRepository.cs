using System;
using System.Threading.Tasks;
using FoxyEcomm.Common.Interfaces;

namespace FoxyEcomm.Common.Models
{
    public abstract class DomainRepository : IDomainRepository
    {
        private readonly IMessagePublisher messagePublisher;

        protected DomainRepository(IMessagePublisher messagePublisher)
        {
            this.messagePublisher = messagePublisher;
        }

        public async Task SaveAsync<TKey, TAggregateRoot>(TAggregateRoot aggregateRoot, bool purge = true)
            where TKey : IEquatable<TKey>
            where TAggregateRoot : class, IAggregateRoot<TKey>, new()
        {
            await this.SaveAggregateAsync<TKey, TAggregateRoot>(aggregateRoot);
            foreach(var evnt in aggregateRoot.UncommittedEvents)
            {
                messagePublisher.Publish(evnt);
            }

            if (purge)
            {
                ((IPurgeable)aggregateRoot).Purge();
            }
        }

        public async Task<TAggregateRoot> GetByKeyAsync<TKey, TAggregateRoot>(TKey key)
            where TKey : IEquatable<TKey>
            where TAggregateRoot : class, IAggregateRoot<TKey>, new()
        {
            var result = await this.GetAggregateAsync<TKey, TAggregateRoot>(key);
            ((IPurgeable)result).Purge();
            return result;
        }

        protected abstract Task SaveAggregateAsync<TKey, TAggregateRoot>(TAggregateRoot aggregateRoot)
            where TKey : IEquatable<TKey>
            where TAggregateRoot : class, IAggregateRoot<TKey>, new();

        protected abstract Task<TAggregateRoot> GetAggregateAsync<TKey, TAggregateRoot>(TKey aggregateRootKey)
            where TKey : IEquatable<TKey>
            where TAggregateRoot : class, IAggregateRoot<TKey>, new();
    }
}
