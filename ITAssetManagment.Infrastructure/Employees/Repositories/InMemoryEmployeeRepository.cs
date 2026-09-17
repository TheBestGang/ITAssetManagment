using ITAssetManager.Domain.Employees.Interface;
using ITAssetManager.Domain.Employees.Models;

namespace ITAssetManagment.Infrastructure.Employees.Repositories
{
    internal class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public IReadOnlyList<Employee> GetAll()
        {
            return _employees.ToList();
        }

        public Employee? GetById(Guid employeeId)
        {
            foreach (Employee employee in _employees)
            {
                if (employee.EmployeeId == employeeId)
                {
                    return employee;
                }
            }

            return null;
        }

        public Employee? GetByEmail(string emailAddress)
        {
            foreach (Employee employee in _employees)
            {
                if (employee.EmailAddress.Equals(
                    emailAddress.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    return employee;
                }
            }

            return null;
        }

        public void Update(Employee employee)
        {
            Employee? existingEmployee = GetById(employee.EmployeeId);

            if (existingEmployee == null)
            {
                throw new InvalidOperationException("Medarbetaren kunde inte hittas.");
            }
        }

        
    }
}