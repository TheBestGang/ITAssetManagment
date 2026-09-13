using ITAssetManagement.Application.Employees.Interfaces;
using ITAssetManager.Domain.Employees.Models;
using ITAssetManager.Domain.Employees.Interface;

namespace ITAssetManagement.Application.Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
       public readonly IEmployeeRepository employeeRepository;
        public void DeactivateEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public void RegisterEmployee(string employeeName, string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
