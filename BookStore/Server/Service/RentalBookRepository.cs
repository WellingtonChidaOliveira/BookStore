namespace BookStore.Server.Service
{
    public class RentalBookRepository : BaseRepository<RentalBook>, IRentalBookRepository
    {
        public RentalBookRepository(IMongoDbContext context) : base(context, "RentalBooks")
        {
        }


    }
}
