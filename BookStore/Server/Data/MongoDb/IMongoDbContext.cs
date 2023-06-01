using MongoDB.Driver;

namespace BookStore.Server.Data.MongoDb
{
    public interface IMongoDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName);   
    }
}
