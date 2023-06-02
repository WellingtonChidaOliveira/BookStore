using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BookStore.Client.Service.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<Customer>> AddCustomer(Customer customer)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Customer", customer);
            if (result.IsSuccessStatusCode)
            {
                return new ServiceResponse<Customer>
                {
                    Data = customer,
                    Success = true,
                    Message = "Customer added successfully"
                };
            }
            else
            {
                return new ServiceResponse<Customer>
                {
                    Data = null,
                    Success = false,
                    Message = result.RequestMessage.ToString()
                };
            }
        }

        public async Task<Address> SearchPostalCode(string postalCode)
        {
            Address address = new Address();
            var result = await _httpClient.GetStringAsync($"https://viacep.com.br/ws/{postalCode}/json/");

            address = MapAddressFromJson(result);


            return address;
        }

        public Address MapAddressFromJson(string json)
        {
            var addressData = JsonConvert.DeserializeObject<dynamic>(json);

            var address = new Address
            {
                Street = addressData.logradouro,
                City = addressData.localidade,
                State = addressData.uf,
                Zip = addressData.cep
            };

            return address;
        }

    }
}
