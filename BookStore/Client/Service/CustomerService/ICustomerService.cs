namespace BookStore.Client.Service.CustomerService
{
    public interface ICustomerService
    {
        Task<ServiceResponse<Customer>> AddCustomer(Customer customer);

        Task<Address> SearchPostalCode (string postalCode);
    }
}
