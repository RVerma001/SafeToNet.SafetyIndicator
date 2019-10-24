using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SafeToNet.Data.Repositories;
using SafeToNet.SafetyIndicator.Core.Models.Entities;

namespace SafeToNet.SafetyIndicator.Core.Repositories
{
    public class SafetyIndicatorRepository : CosmosBaseRepository<Models.Entities.SafetyIndicator>, ISafetyIndicatorRepository
    {
        private readonly IMongoCollection<Models.Entities.SafetyIndicator> _mongoCollection;

        public SafetyIndicatorRepository(IMongoClient mongoClient, IMongoCollection<Models.Entities.SafetyIndicator> mongoCollection,
            string databaseName, string collectionName) : base(mongoClient, mongoCollection, databaseName,
            collectionName)
        {
            _mongoCollection = mongoCollection;
            CreateIndexes().Wait();
        }

        public async Task CreateIndexes()
        {
            var indexDefinition = Builders<Models.Entities.SafetyIndicator>.IndexKeys.Combine(
                Builders<Models.Entities.SafetyIndicator>.IndexKeys.Ascending(f => f.DateGenerated),
                Builders<Models.Entities.SafetyIndicator>.IndexKeys.Ascending(f => f.DeviceId));

            await _mongoCollection.Indexes.CreateOneAsync(new CreateIndexModel<Models.Entities.SafetyIndicator>(indexDefinition));
        }

        public async Task Insert(IEnumerable<Models.Entities.SafetyIndicator> items)
        {
            var enumerable = items.ToList();
            if (items == null || !enumerable.Any()) throw new ArgumentNullException(nameof(items));

            foreach (var insight in enumerable)
            {
                await _mongoCollection.InsertOneAsync(insight);
                //await InsertAsync(insight);
            }
        }

        public async Task<IEnumerable<Models.Entities.SafetyIndicator>> GetLastOneDayAndDeviceIdBy(Guid deviceId)
        {
            var builder = Builders<Models.Entities.SafetyIndicator>.Filter;

            var filter = builder.Eq(f => f.DeviceId, deviceId) &
            builder.Lte(f => f.DateGenerated, DateTime.UtcNow)
            & builder.Gte(f => f.DateGenerated, DateTime.UtcNow.AddHours(-24));

            return await _mongoCollection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Models.Entities.SafetyIndicator>> GetLastHoursInsightsByDeviceId(Guid deviceId, double hours)
        {
            var builder = Builders<Models.Entities.SafetyIndicator>.Filter;

            var filter = builder.Eq(f => f.DeviceId, deviceId) &
                         builder.Lte(f => f.DateGenerated, DateTime.UtcNow)
                         & builder.Gte(f => f.DateGenerated, DateTime.UtcNow.AddHours(-hours));

            return await _mongoCollection.Find(filter).ToListAsync();
        }
    }
}