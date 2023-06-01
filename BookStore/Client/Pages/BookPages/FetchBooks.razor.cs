
namespace BookStore.Client.Pages.BookPages
{
    public partial class FetchBooks
    {
        private IEnumerable<Book> Books;
        protected override async Task OnInitializedAsync()
        {
            BookService.OnChange += StateHasChanged;
            await GetBooks();
        }

        public void Dispose()
        {
            BookService.OnChange -= StateHasChanged;
        }

        private async Task GetBooks()
        {
           var result = await BookService.GetBooks();
           Books = result.Data;
           
            
        }

        private void RedirectToCreate()
        {
            NavigationManager.NavigateTo("/createbook");
        }
    }
}
