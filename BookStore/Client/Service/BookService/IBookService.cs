using BookStore.Shared;

namespace BookStore.Client.Service.BookService
{
    public interface IBookService
    {

        event Action OnChange;
        List<Book> Books { get; set; }
        Task<List<Book>> GetBooks();
        Task<ServiceResponse<Book>> GetBook(string id);
        Task<ServiceResponse<Book>> AddBook(Book book);
        Task<ServiceResponse<Book>> DeleteBook(int id);
        Task<ServiceResponse<Book>> UpdateBook(Book book);


    }
}
