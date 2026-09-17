using ITAssetManager.Domain.Employees.Models;

namespace ITAssetManagement.Application.Employees.Interfaces
{
    public interface IEmployeeService
    {
        void RegisterEmployee(string employeeName, string emailAddress);

        IReadOnlyList<Employee> GetAllEmployees();

        void DeactivateEmployee(Guid employeeId);
    }
}
