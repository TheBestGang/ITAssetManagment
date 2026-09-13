using ITAssetManager.Domain.Employees.Models;

namespace ITAssetManager.Domain.Employees.Interface
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        IReadOnlyList<Employee> GetAll();

        Employee? GetById(Guid employeeId);

        Employee? GetByEmail(string emailAddress);

        void Update(Employee employee);
    }
}