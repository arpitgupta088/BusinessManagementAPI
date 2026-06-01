using BusinessManagementAPI.Models;
using BusinessManagementAPI.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BusinessManagementAPI.Repository
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly IMongoCollection<Business> _businessCollection;

        public BusinessRepository(IOptions<MongoDbSettings> mongoDbSettings)     //ye constructor mongoDB se connection bna rha h
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _businessCollection = mongoDatabase.GetCollection<Business>(mongoDbSettings.Value.CollectionName);
        }

        public async Task<List<Business>> GetAllAsync()
        {
            return await _businessCollection
                .Find(_ => true)                               // sabhi businesses layega
                .ToListAsync();
        }

        public async Task<Business?> GetByIdAsync(string businessId)
        {
            return await _businessCollection
                .Find(x => x.BusinessId == businessId)                // gives one specific business
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(Business business)
        {
            await _businessCollection.InsertOneAsync(business);              // InsertOneAsync saves new business
        }

        public async Task UpdateAsync(string businessId, Business business)
        {
            var update = Builders<Business>.Update
                .Set(x => x.BusinessName, business.BusinessName)
                .Set(x => x.CreatorId, business.CreatorId)
                .Set(x => x.CreatorName, business.CreatorName)
                .Set(x => x.UpdatedDate, business.UpdatedDate)
                .Set(x => x.IsDeleted, business.IsDeleted);

            await _businessCollection.UpdateOneAsync(
                x => x.BusinessId == businessId,
                update);
        }
        public async Task DeleteAsync(string businessId)
        {
            await _businessCollection.DeleteOneAsync(
                x => x.BusinessId == businessId);
        }
    }
}
