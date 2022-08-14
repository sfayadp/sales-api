using Microsoft.EntityFrameworkCore;
using Sales.Api.Domains.Contracts;
using Sales.Api.DTOs;
using Sales.Api.Models;

namespace Sales.Api.Domains.Employees
{
    public class EmployeeDomainService : IEmployeeDomainService
    {
        private readonly StoreDBContext _context;
        public EmployeeDomainService(StoreDBContext context)
        {
             _context = context;
        }
        public Employee GetEmploye(int Id)
        {
            return _context.Employees.Where(x => x.Id == Id).First();
        }

        public IEnumerable<Employee> GetEmployes()
        {
            return _context.Employees.ToList();
        }

        public string SaveEmployee(EmployeeDTO employee)
        {
            Employee newEmployee = new Employee();
            string result = "";
            if(employee != null)
            {
                newEmployee.FirstName = employee.FirstNameDTO;
                newEmployee.LastName = employee.LastNameDTO;
                newEmployee.UserName = employee.UserNameDTO;
                newEmployee.Password = employee.PasswordDTO;
            }
            _context.Employees.Add(newEmployee);
            
            if (newEmployee != null)
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

        public string UpdateEmployee(EmployeeDTO employee)
        {
            Employee updatedEmployeed = _context.Employees.Where(x => x.Id == employee.IdDTO).First();
            string result = "";
            if (updatedEmployeed != null)
            {
                updatedEmployeed.FirstName = employee.FirstNameDTO;
                updatedEmployeed.LastName = employee.LastNameDTO;
                updatedEmployeed.UserName = employee.UserNameDTO;
                updatedEmployeed.Password = employee.PasswordDTO;
            }

            _context.Entry(updatedEmployeed).State = EntityState.Modified;

            if (updatedEmployeed != null)
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
