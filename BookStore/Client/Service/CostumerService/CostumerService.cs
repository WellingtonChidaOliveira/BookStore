using System.Net.Http.Json;

namespace BookStore.Client.Service.CostumerService
{
    public class CostumerService : ICostumerService
    {
        private readonly HttpClient _httpClient;

        public CostumerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<Customer>> AddCostumer(Customer customer)
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
    }
}
