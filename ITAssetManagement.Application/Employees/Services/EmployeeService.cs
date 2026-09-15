using ITAssetManagement.Application.Employees.Interfaces;
using ITAssetManager.Domain.Employees.Models;
using ITAssetManager.Domain.Employees.Interface;

namespace ITAssetManagement.Application.Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void DeactivateEmployee(Guid employeeId)
        {
            Employee? employee = _employeeRepository.GetById(employeeId);
            if (employee == null)
            {
                throw new InvalidOperationException("Medarbetare hittades inte.");
            }
            employee.Deactivate();
            _employeeRepository.Update(employee);
        }

        public IReadOnlyList<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public void RegisterEmployee(string employeeName, string emailAddress)
        {
            Employee? existingEmployee = _employeeRepository.GetByEmail(emailAddress);

            if (existingEmployee != null)
            {
                throw new InvalidOperationException("En medarbetare med den här e-postadressen finns redan.");
            }
            
            Employee employee = new Employee(
        Guid.NewGuid(),
        employeeName,
        emailAddress);
            
            _employeeRepository.Add(employee);
        }
    }
}

