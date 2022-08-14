using Sales.Api.DTOs;
using Sales.Api.Models;

namespace Sales.Api.Domains.Contracts
{
    public interface IEmployeeDomainService
    {   
        IEnumerable<Employee> GetEmployes();
        Employee GetEmploye(int Id);
        string SaveEmployee(EmployeeDTO employee);
        string UpdateEmployee(EmployeeDTO employee);
    }
}
