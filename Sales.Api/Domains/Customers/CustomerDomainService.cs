using Microsoft.EntityFrameworkCore;
using Sales.Api.Domains.Contracts;
using Sales.Api.DTOs;
using Sales.Api.Models;

namespace Sales.Api.Domains.Customers
{
    public class CustomerDomainService : ICustomerDomainService
    {
        readonly StoreDBContext _context;

        public CustomerDomainService(StoreDBContext context)
        {
            _context = context;
        }
            public Customer GetCustomer(int Id)
        {
            return _context.Customers.Where(x => x.Id == Id).First();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public string SaveCustomer(CustomerDTO customer)
        {
            Customer newCustomer = new Customer();
            string result = "";
            if (customer != null)
            {
                newCustomer.FirstName = customer.FirstNameDTO;
                newCustomer.LastName = customer.LastNameDTO;
                newCustomer.UserName = customer.UserNameDTO;
                newCustomer.Password = customer.PasswordDTO;
            }
            _context.Customers.Add(newCustomer);

            if (newCustomer != null)
            {
                result = "Ok";
                _context.SaveChanges();
            }
            else
            {
                result = "No se pudo guardar el registro";
            }

            return result;
        }

        public string UpdateCustomer(CustomerDTO customer)
        {
            Customer updatedCustomer = _context.Customers.Where(x => x.Id == customer.IdDTO).First();
            string result = "";
            if (updatedCustomer != null)
            {
                updatedCustomer.FirstName = customer.FirstNameDTO;
                updatedCustomer.LastName = customer.LastNameDTO;
                updatedCustomer.UserName = customer.UserNameDTO;
                updatedCustomer.Password = customer.PasswordDTO;
            }

            _context.Entry(updatedCustomer).State = EntityState.Modified;

            if (updatedCustomer != null)
            {
                result = "Ok";
                _context.SaveChanges();
            }
            else
            {
                result = "No se pudo editar el registro";
            }
            return result;
        }
    }
}
