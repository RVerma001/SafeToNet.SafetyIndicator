using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using OpenTracing;
using SafeToNet.SafetyIndicator.Core.Models.Entities;
using SafeToNet.Commons.OpenTracing;
using SafeToNet.Data.Repositories;

namespace SafeToNet.SafetyIndicator.Core.Repositories
{
    public class AccessRepository : CosmosBaseRepository<AuthCredentials>, IAccessRepository
    {
        public AccessRepository(IMongoClient mongoClient,
            IMongoCollection<AuthCredentials> mongoCollection,
            string databaseName,
            string collectionName)
            : base(mongoClient,
                mongoCollection,
                databaseName,
                collectionName)
        {
        }

        public AuthCredentials Insert(AuthCredentials accessCode, IScope scope)
        {
            if (accessCode == null)
                throw new ArgumentNullException(nameof(accessCode));

            return base.Insert(accessCode);
        }

        public async Task<AuthCredentials> Update(AuthCredentials accessCode, IScope scope)
        {
            if (accessCode == null)
                throw new ArgumentNullException(nameof(accessCode));

            var filter = Builders<AuthCredentials>.Filter.Eq(item => item.Id, accessCode.Id);

            filter.TraceFilter(scope);

            return await ReplaceOneAsync(accessCode, filter);
        }

        public async Task<AuthCredentials> GetByAccessCode(string code, IScope scope)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(code));

            var filter = Builders<AuthCredentials>.Filter.Eq(a => a.Code, code);

            filter.TraceFilter(scope);

            return await GetOneByExpressionAsync(filter);

        }

        public async Task<AuthCredentials> GetByDeviceId(Guid deviceId, IScope scope)
        {
            if (deviceId == Guid.Empty)
                throw new ArgumentException(nameof(deviceId));

            var filter = Builders<AuthCredentials>.Filter.Eq(a => a.DeviceId, deviceId);

            filter.TraceFilter(scope);

            return await GetOneByExpressionAsync(filter);
        }

        public async Task<AuthCredentials> GetById(Guid id, IScope scope)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(nameof(id));

            var filter = Builders<AuthCredentials>.Filter.Eq(a => a.Id, id);

            filter.TraceFilter(scope);

            return await GetOneByExpressionAsync(filter);
        }

        public async Task DeleteByDeviceId(Guid deviceId, IScope scope)
        {
            if (deviceId == Guid.Empty)
                throw new ArgumentException(nameof(deviceId));

            var filter = Builders<AuthCredentials>.Filter.Eq(a => a.DeviceId, deviceId);

            filter.TraceFilter(scope);

            var accessCodes = await GetByExpressionAsync(filter);

            foreach (var a in accessCodes)
            {
                var deleteFilter = Builders<AuthCredentials>.Filter.Eq(c => c.Id, a.Id);

                await DeleteAsync(deleteFilter);
            }
        }
    }
}
