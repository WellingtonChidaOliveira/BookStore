using System.Net.Http.Json;

namespace BookStore.Client.Service.BookService
{
    public class BookService : IBookService
    {
        public HttpClient _httpClient { get; }

        public List<Book> Books { get; set; } = new List<Book>();

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public event Action OnChange;

        public async Task<ServiceResponse<Book>> AddBook(Book book)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Book", book);
            if (result.IsSuccessStatusCode)
            {
                return new ServiceResponse<Book>
                {
                    Data = book,
                    Success = true,
                    Message = "Book added successfully"
                };
            }
            else
            {
                return new ServiceResponse<Book>
                {
                    Data = null,
                    Success = false,
                    Message = result.RequestMessage.ToString()
                };
            }
        }

        public async Task<ServiceResponse<Book>> DeleteBook(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/book/{id}");
            if (result.IsSuccessStatusCode)
            {
                return new ServiceResponse<Book>
                {
                    Data = null,
                    Success = true,
                    Message = "Book deleted successfully"
                };
            }
            else
            {
                return new ServiceResponse<Book>
                {
                    Data = null,
                    Success = false,
                    Message = "Book not deleted"
                };
            }
        }

        public async Task<ServiceResponse<Book>> GetBook(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<Book>($"api/book/{id}");
            if (result is not null)
            {
                return new ServiceResponse<Book>
                {
                    Data = result,
                    Success = true,
                    Message = "Book retrieved successfully"
                };
            }
            else
            {
                return new ServiceResponse<Book>
                {
                    Data = null,
                    Success = false,
                    Message = "Book not found"
                };
            }

        }

        public async Task<List<Book>> GetBooks()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Book>>("api/Book");
            if (result is not null)
            {
                return result;
            }
            else
            {
                return null;
            }



        }

        public async Task<ServiceResponse<Book>> UpdateBook(Book book)
        {
            var result = await _httpClient.PutAsJsonAsync<Book>("api/Book", book);

            if (result.IsSuccessStatusCode)
            {
                return new ServiceResponse<Book>
                {
                    Data = book,
                    Success = true,
                    Message = "Book updated successfully"
                };
            }
            else
            {
                return new ServiceResponse<Book>
                {
                    Data = null,
                    Success = false,
                    Message = "Book not updated"
                };
            }

        }

        public byte[] ConvertToBytes(string file)
        {
            byte[] bytes = null;
            if (!string.IsNullOrWhiteSpace(file))
            {
                bytes = Convert.FromBase64String(file);
            }
            return bytes;
        }
    }
}
