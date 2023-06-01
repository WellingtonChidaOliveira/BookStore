using BlazorInputFile;
using Microsoft.AspNetCore.Components;

namespace BookStore.Client.Pages.BookPages
{
    public partial class CreateBook
    {
        private Book NewBook { get; set; } = new Book();
        byte[] _fileBytes = null;
        private async Task AddBook()
        {
            // Salvar o novo livro no banco de dados
            await BookService.AddBook(NewBook);

            // Redirecionar para a página de listagem de livros
            NavigationManager.NavigateTo("/fetchbooks");
        }
        private async Task HandlePhotoChange(IFileListEntry[] files)
        {
            var file = files.FirstOrDefault();
            if (file is not null)
            {
                var ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);
                NewBook.Photo = ms.ToArray();
                NewBook.ImageUrl = $"data:{file.Type};base64,{Convert.ToBase64String(NewBook.Photo)}";
            }
        }

        private byte[] ConvertToBytes(string file)
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
