using Sales.Api.DTOs;
using Sales.Api.Models;

namespace Sales.Api.Domains.Contracts
{
    public interface ICustomerDomainService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int Id);
        string SaveCustomer(CustomerDTO customer);
        string UpdateCustomer(CustomerDTO customer);
    }
}
