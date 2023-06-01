using BlazorInputFile;

namespace BookStore.Client.Pages.Customers
{
    public partial class CreateCustomer
    {
        private Customer user = new Customer();
        private string zipCode;
        private string phone;

        private List<string> phones = new List<string>();
        
        private async Task HandleSubmit()
        {
          
            user.Phone.Add(new Phone { Number = phone });
            user.Address.Add(new Address { Zip = zipCode });
            await CustomerService.AddCostumer(user);

            // Limpar o formulário após o cadastro
            //Implements redirect to initial page after save
            user = new Customer();
        }

        private async Task HandlePhotoChange(IFileListEntry[] files)
        {
            var file = files.FirstOrDefault();
            if (file is not null)
            {
                var ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);
                user.Photo = ms.ToArray();
                user.ImageUrl = Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
