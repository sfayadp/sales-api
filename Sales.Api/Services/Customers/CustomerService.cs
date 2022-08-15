using AutoMapper;
using Sales.Api.Domains.Contracts;
using Sales.Api.Domains.Employees;
using Sales.Api.DTOs;
using Sales.Api.Models;
using Sales.Api.Services.Contratcs;

namespace Sales.Api.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerDomainService _customerDomainService;
        readonly IMapper _mapper;

        #region Builder
        public CustomerService(
            ICustomerDomainService customerDomainService,
            IMapper mapper)
        {
            _customerDomainService = customerDomainService;
            _mapper = mapper;
        }
        #endregion Builder

        #region Methods

        public CustomerDTO GetCustomer(int Id)
        {
            try
            {
                Customer customer = _customerDomainService.GetCustomer(Id);
                if (customer == null)
                    return new CustomerDTO();

                CustomerDTO result = _mapper.Map<Customer, CustomerDTO>(customer);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<CustomerDTO> GetCustomers()
        {
            try
            {
                IEnumerable<Customer> customerList = _customerDomainService.GetCustomers();

                IEnumerable<CustomerDTO> result = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customerList);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string SaveCustomer(CustomerDTO customer)
        {
            string result = _customerDomainService.SaveCustomer(customer);
            return result;
        }

        public string UpdateCustomer(CustomerDTO customer)
        {
            string result = _customerDomainService.UpdateCustomer(customer); ;
            return result;
        }

        #endregion Methods
    }
}
