namespace BookStore.Server.Service
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IMongoDbContext context) : base(context, "Customer")
        {
        }
    }
}
