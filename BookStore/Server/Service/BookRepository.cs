namespace BookStore.Server.Service
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(IMongoDbContext context) : base(context, "books")
        {
        }
    }
  
}
