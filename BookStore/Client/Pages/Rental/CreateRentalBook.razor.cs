using System.Linq;

namespace BookStore.Client.Pages.Rental
{
    public partial class CreateRentalBook
    {
        RentalBook RentalBook = new RentalBook();
        List<Book> Books = new List<Book>();
        List<Customer> Customers = new List<Customer>();

        string bookId;
        string customerId;


        protected async override Task OnInitializedAsync()
        {
            await GetBooks();
            await GetCustomer();
        }

        private async Task GetBooks()
        {
            var result = await BookService.GetBooks();
            Books = result;
        }

        private async Task GetCustomer()
        {
            var result = await CustomerService.GetCustomers();
            Customers = result;
        }

        private async Task CreateRental()
        {
            RentalBook.Book = Books.FirstOrDefault(x => x.id == bookId);
            RentalBook.Customer = Customers.FirstOrDefault(x => x.id == customerId);
            await RentalBookService.RentBook(RentalBook);
        }
    }
}
