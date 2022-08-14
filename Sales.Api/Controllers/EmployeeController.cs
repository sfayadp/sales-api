using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.DTOs;
using Sales.Api.Services.Contratcs;

namespace Sales.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Lista a todos los empleados
        /// </summary>
        /// <returns>Lista de empleados</returns>
        [HttpGet]
        [Route(nameof(EmployeeController.GetEmployees))]
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            return _employeeService.GetEmployes();
        }

        /// <summary>
        /// Lista un empleado
        /// </summary>
        /// <returns>Lista un empleado</returns>
        [HttpGet]
        [Route(nameof(EmployeeController.GetEmployeByID))]
        public EmployeeDTO GetEmployeByID(int Id)
        {
            return _employeeService.GetEmploye(Id);
        }

        /// <summary>
        /// Guardar un empleado
        /// </summary>
        /// <returns>Lista un empleado</returns>
        [HttpPost]
        [Route(nameof(EmployeeController.SaveEmployee))]
        public string SaveEmployee(EmployeeDTO employee)
        {
            return _employeeService.SaveEmployee(employee);
        }

        /// <summary>
        /// Editar un empleado
        /// </summary>
        /// <returns>Lista un empleado</returns>
        [HttpPost]
        [Route(nameof(EmployeeController.UpdateEmployee))]
        public string UpdateEmployee(EmployeeDTO employee)
        {
            return _employeeService.UpdateEmployee(employee);
        }
    }
}
