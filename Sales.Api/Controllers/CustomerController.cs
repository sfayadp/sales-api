using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.DTOs;
using Sales.Api.Services.Contratcs;
using Sales.Api.Services.Employees;

namespace Sales.Api.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Lista a todos los clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [HttpGet]
        [Route(nameof(CustomerController.GetCustomers))]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _customerService.GetCustomers();
        }

        /// <summary>
        /// Lista un cliente
        /// </summary>
        /// <returns>Lista un cliente</returns>
        [HttpGet]
        [Route(nameof(CustomerController.GetCustomerByID))]
        public CustomerDTO GetCustomerByID(int Id)
        {
            return _customerService.GetCustomer(Id);
        }

        /// <summary>
        /// Guardar un cliente
        /// </summary>
        /// <returns>Lista un cliente</returns>
        [HttpPost]
        [Route(nameof(CustomerController.SaveCustomer))]
        public string SaveCustomer(CustomerDTO customer)
        {
            return _customerService.SaveCustomer(customer);
        }

        /// <summary>
        /// Editar un cliente
        /// </summary>
        /// <returns>Lista un cliente</returns>
        [HttpPost]
        [Route(nameof(CustomerController.UpdateCustomer))]
        public string UpdateCustomer(CustomerDTO customer)
        {
            return _customerService.UpdateCustomer(customer);
        }
    }
}
