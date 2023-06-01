using BlazorInputFile;
using Microsoft.AspNetCore.Components;

namespace BookStore.Client.Pages.BookPages
{
    public partial class EditBook
    {
        private Book book;
        private IFileListEntry selectedPhoto;
        [Parameter]
        public string id { get;set;}

        protected override async Task OnInitializedAsync()
        {
            id = NavigationManager.Uri.Split('/').LastOrDefault();
            var result = await BookRepository.GetBook(id);
            if (result is not null && result.Data is not null)
                book = result.Data;
        }

        private async Task UpdateBook()
        {
            await BookRepository.UpdateBook(book);
            NavigationManager.NavigateTo("/books");
        }

        private async Task HandlePhotoChange(IFileListEntry[] files)
        {
            var file = files.FirstOrDefault();
            if (file is not null)
            {
                var ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);
                book.Photo = ms.ToArray();
                book.ImageUrl = $"data:{file.Type};base64,{Convert.ToBase64String(book.Photo)}";
            }
        }
    }
}
