namespace BookStore.Client.Service.CostumerService
{
    public interface ICostumerService
    {
        Task<ServiceResponse<Customer>> AddCostumer(Customer customer);
    }
}
