namespace BookStore.Client.Pages.Rental
{
    public partial class FetchRentalBooks
    {

        private List<RentalBook> rentalBooks;
        protected override async Task OnInitializedAsync()
        {
            await GetRentalBooks();
        }

        private async Task GetRentalBooks()
        {
            var result = await RentalBookService.GetRentalBooks();
            rentalBooks = result;
        }

        private void CreateNewRental()
        {
            // Navegar para a página de criação de um novo rental
            NavigationManager.NavigateTo("/create-rental");
        }

        private void EditRental(string id)
        {
            // Navegar para a página de edição do rental com o ID correspondente
            NavigationManager.NavigateTo($"/edit-rental/{id}");
        }

        private void RedirectToCreateUser()
        {
            NavigationManager.NavigateTo("/create-user");
        }
    }
}
