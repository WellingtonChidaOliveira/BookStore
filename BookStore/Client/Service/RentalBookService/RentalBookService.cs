using System.Net.Http.Json;

namespace BookStore.Client.Service.RentalBookService
{
    public class RentalBookService : IRentalBookService
    {
        private readonly HttpClient _httpClient;

        public RentalBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<RentalBook> rentalBooks { get; set; }

        public async Task<RentalBook> GetRentalBookById(string id)
        {
            var result = await GetRentalBooks();

            if (result is not null)
            {
                return result.Where(x => x.Book.id == id).FirstOrDefault();
            }
            else
            {
                return new RentalBook();
            }
        }

        public async Task<List<RentalBook>> GetRentalBooks()
        {
            var result = await _httpClient.GetFromJsonAsync<List<RentalBook>>("api/RentalBook");
            if (result is not null)
            {
                return result;
            }
            else
            {
                return rentalBooks;
            }
        }

        public async Task<List<RentalBook>> GetRentalBooksByUserId(string userId)
        {
            var result = await GetRentalBooks();

            if (result is not null)
            {
                return result.Where(x => x.Customer.id == userId).ToList();
            }
            else
            {
                return rentalBooks;
            }
        }

        public async Task RentBook(RentalBook rentalBook)
        {
            await _httpClient.PostAsJsonAsync("api/RentalBook", rentalBook);
        }

        public async Task ReturnBook(RentalBook rentalBook)
        {
            await _httpClient.PutAsJsonAsync($"api/RentalBook/{rentalBook.id}", rentalBook);
        }



    }
}
