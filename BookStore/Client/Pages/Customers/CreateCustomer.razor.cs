using BlazorInputFile;
using BookStore.Shared.Utils;

namespace BookStore.Client.Pages.Customers
{
    public partial class CreateCustomer
    {
        private Customer user = new Customer();
        private string zipCode;
        private string phone;
        private string phoneType = TypesTel.Celular;

        private async Task HandleSubmit()
        {
           
            await CustomerService.AddCustomer(user);

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

        private void AddPhone()
        {
            user.Phone.Add(new Phone { Number = phone, Type = phoneType });
            phone = string.Empty;
        }
        private void RemovePhone(string phone)
        {
            user.Phone.Remove(user.Phone.FirstOrDefault(x => x.Number == phone));
        }

        private async Task AddAddress()
        {
            var result = await CustomerService.SearchPostalCode(zipCode);
            user.Address.Add(result);
            zipCode = string.Empty;
        }

        private void RemoveAddress(string zipCode)
        {
            user.Address.Remove(user.Address.FirstOrDefault(x => x.Zip == zipCode));
        }
    }
}
