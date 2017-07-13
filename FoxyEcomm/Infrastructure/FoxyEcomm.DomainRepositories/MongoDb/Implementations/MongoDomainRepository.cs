﻿using System;
using System.Threading.Tasks;
using FoxyEcomm.Common.Interfaces;
using FoxyEcomm.Common.Models;
using FoxyEcomm.DomainRepositories.MongoDb.Models;
using MongoDB.Driver;

namespace FoxyEcomm.DomainRepositories.MongoDb.Implementations
{
    public class MongoDomainRepository : DomainRepository
    {
        private readonly MongoSetting setting;
        private readonly Lazy<MongoClient> client;
        private readonly Lazy<IMongoDatabase> database;

        public MongoDomainRepository(MongoSetting setting, IMessagePublisher bus) : base(bus)
        {
            this.setting = setting;
            this.client = new Lazy<MongoClient>(() => new MongoClient(setting.ConnectionString));
            this.database = new Lazy<IMongoDatabase>(() => client.Value.GetDatabase(setting.DatabaseName));
        }

        private async Task<TAggregateRoot> GetAggregateAsync<TKey, TAggregateRoot>(FilterDefinition<TAggregateRoot> filter)
            where TKey : IEquatable<TKey>
            where TAggregateRoot : IAggregateRoot<TKey>
        {
            var collection = database.Value.GetCollection<TAggregateRoot>(setting.CollectionName);
            return await collection.Find<TAggregateRoot>(filter).FirstOrDefaultAsync();
        }

        protected override async Task<TAggregateRoot> GetAggregateAsync<TKey, TAggregateRoot>(TKey aggregateRootKey)
        {
            var builder = Builders<TAggregateRoot>.Filter;
            var filter = builder.Eq(x => x.Id, aggregateRootKey);
            return await GetAggregateAsync<TKey, TAggregateRoot>(filter);
        }

        protected override async Task SaveAggregateAsync<TKey, TAggregateRoot>(TAggregateRoot aggregateRoot)
        {
            var collection = database.Value.GetCollection<TAggregateRoot>(setting.CollectionName);
            var builder = Builders<TAggregateRoot>.Filter;
            var filter = builder.Eq(x => x.Id, aggregateRoot.Id);
            var saved = await GetAggregateAsync<TKey, TAggregateRoot>(filter);
            if (saved != null)
            {
                await collection.ReplaceOneAsync(filter, aggregateRoot);
            }
            else
            {
                await collection.InsertOneAsync(aggregateRoot);
            }
        }
    }
}
