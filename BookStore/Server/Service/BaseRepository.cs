using BookStore.Server.Data.MongoDb;
using BookStore.Shared.Base;
using MongoDB.Driver;

namespace BookStore.Server.Service
{
    public abstract class BaseRepository<TEntity> where TEntity : IDocument
    {
        protected readonly IMongoCollection<TEntity> collection;

        protected BaseRepository(IMongoDbContext context, string collectionName)
        {
            collection = context.GetCollection<TEntity>(collectionName);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await collection.Find(FilterDefinition<TEntity>.Empty).ToListAsync();
        }

        public async Task<TEntity> Get(string id)
        {
            return await collection.Find<TEntity>(entity => entity.id == id).FirstOrDefaultAsync();
        }

        public async Task Add(TEntity entity)
        {
            await collection.InsertOneAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            await collection.ReplaceOneAsync(filter: entity => entity.id == entity.id, replacement: entity);
        }

        public async Task Delete(string id)
        {
            await collection.DeleteOneAsync(entity => entity.id == id);
        }

    }
}
