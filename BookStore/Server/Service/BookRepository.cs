using BookStore.Server.Abstraction;
using BookStore.Server.Data.MongoDb;
using BookStore.Shared;

namespace BookStore.Server.Service
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(IMongoDbContext context) : base(context, "books")
        {
        }
    }
  
}
