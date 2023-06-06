using BlazorInputFile;
using Microsoft.AspNetCore.Components;

namespace BookStore.Client.Pages.Rental
{
    public partial class EditRentalBook
    {
        private RentalBook RentalBook;

        private IFileListEntry selectedPhoto;
        [Parameter]
        public string id { get;set;}

        protected override async Task OnInitializedAsync()
        {
            id = NavigationManager.Uri.Split('/').LastOrDefault();
            var result = await RentalBookService.GetRentalBookId(id);
            if (result is not null )
                RentalBook = result;
        }

        private async Task UpdateRental()
        {
            await RentalBookService.ReturnBook(RentalBook);
            NavigationManager.NavigateTo("/");
        }

        private async Task HandlePhotoChange(IFileListEntry[] files)
        {
            var file = files.FirstOrDefault();
            if (file is not null)
            {
                var ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);
                RentalBook.Book.Photo = ms.ToArray();
                RentalBook.Book.ImageUrl = $"data:{file.Type};base64,{Convert.ToBase64String(RentalBook.Book.Photo)}";
            }
        }
    }
}
