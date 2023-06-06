namespace BookStore.Client.Service.RentalBookService
{
    public interface IRentalBookService
    {
        public List<RentalBook> rentalBooks { get; set; }
        public Task<RentalBook> GetRentalBookById(string id);
        public Task<List<RentalBook>> GetRentalBooksByUserId(string userId);
        public Task<List<RentalBook>> GetRentalBooks();

        public Task<RentalBook> GetRentalBookId(string id);
        public Task RentBook(RentalBook rentalBook);
        public Task ReturnBook(RentalBook rentalBook);



    }
}
