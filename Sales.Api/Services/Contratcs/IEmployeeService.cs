using Sales.Api.DTOs;

namespace Sales.Api.Services.Contratcs
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetEmployes();
        EmployeeDTO GetEmploye(int Id);
        string SaveEmployee(EmployeeDTO employee);
        string UpdateEmployee(EmployeeDTO employee);

    }
}
