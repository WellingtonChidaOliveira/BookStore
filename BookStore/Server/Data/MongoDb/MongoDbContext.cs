using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Security.Authentication;

namespace BookStore.Server.Data.MongoDb
{
    public class MongoDbContext : IMongoDbContext
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        public MongoDbContext(IConfiguration configurationManager)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl
                (new MongoUrl(configurationManager.GetConnectionString("DefaultConnection")));

            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            _client = new MongoClient(settings);
            _database = _client.GetDatabase(configurationManager["DatabaseName"]);

        }


        public IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName)
        {
            return _database.GetCollection<TEntity>(collectionName);
        }
    }
}
