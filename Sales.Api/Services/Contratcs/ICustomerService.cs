using Sales.Api.DTOs;

namespace Sales.Api.Services.Contratcs
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetCustomers();
        CustomerDTO GetCustomer(int Id);
        string SaveCustomer(CustomerDTO customer);
        string UpdateCustomer(CustomerDTO customer);
    }
}
