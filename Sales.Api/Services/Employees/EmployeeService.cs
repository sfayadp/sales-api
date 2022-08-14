using Sales.Api.Domains.Contracts;
using Sales.Api.DTOs;
using Sales.Api.Services.Contratcs;
using Sales.Api.Models;
using AutoMapper;

namespace Sales.Api.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDomainService _employeeDomainService;
        private readonly IMapper _mapper;

        #region Builder
        public EmployeeService(
            IEmployeeDomainService employeeDomainService,
            IMapper mapper)
        {
            _employeeDomainService = employeeDomainService;
            _mapper = mapper;

        }
        #endregion Builder

        #region Methods

        public EmployeeDTO GetEmploye(int Id)
        {
            try
            {
                Employee employee = _employeeDomainService.GetEmploye(Id);
                if (employee == null)
                    return new EmployeeDTO();

                EmployeeDTO result = _mapper.Map<Employee, EmployeeDTO>(employee);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<EmployeeDTO> GetEmployes()
        {
            try
            {
                IEnumerable<Employee> employeesList = _employeeDomainService.GetEmployes();

                IEnumerable<EmployeeDTO> result = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employeesList);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string SaveEmployee(EmployeeDTO employee)
        {
            string result = _employeeDomainService.SaveEmployee(employee);
            return result;
        }

        public string UpdateEmployee(EmployeeDTO employee)
        {
            string result = _employeeDomainService.UpdateEmployee(employee); ;
            return result;
        }

        #endregion Methods
    }
}
