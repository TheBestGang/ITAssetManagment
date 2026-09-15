using ITAssetManagement.Application.Employees.Interfaces;
using ITAssetManager.Domain.Employees.Models;
using ITAssetManagment.Presentation.Employees.Interfaces;

namespace ITAssetManagment.Presentation.Employees.Services
{
    public class EmployeeDialogService : IEmployeeDialog
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeDialogService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("--- Hantera medarbetare ---");
                Console.WriteLine("1. Registrera medarbetare");
                Console.WriteLine("2. Visa alla medarbetare");
                Console.WriteLine("3. Inaktivera medarbetare");
                Console.WriteLine("0. Tillbaka");

                string? choice = Console.ReadLine();


                // ALTERNATIV 0 - TILLBAKA
                if (choice == "0")
                {
                    break;
                }

                // ALTERNATIV 1 - REGISTRERA
                if (choice == "1")
                {
                    Console.WriteLine("Registrera medarbetare");

                    Console.WriteLine("Ange medarbetarens namn:");
                    string? employeeName = Console.ReadLine();

                    Console.WriteLine("Ange medarbetarens e-postadress:");
                    string? emailAddress = Console.ReadLine();

                    try
                    {
                        _employeeService.RegisterEmployee(employeeName!, emailAddress!);
                        Console.WriteLine("Medarbetaren registrerades.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }


                // ALTERNATIV 2 - VISA ALLA
                if (choice == "2")
                {
                    IReadOnlyList<Employee> employees = _employeeService.GetAllEmployees();

                    foreach (Employee employee in employees)
                    {
                        Console.WriteLine(
                            $"ID: {employee.EmployeeId}, Namn: {employee.EmployeeName}, E-post: {employee.EmailAddress}, Aktiv: {employee.IsActive}");
                    }
                }


                // ALTERNATIV 3 - INAKTIVERA
                if (choice == "3")
                {
                    Console.WriteLine("Ange ID på medarbetaren som ska inaktiveras:");

                    string? employeeIdInput = Console.ReadLine();

                    if (Guid.TryParse(employeeIdInput, out Guid employeeId))
                    {
                        try
                        {
                            _employeeService.DeactivateEmployee(employeeId);
                            Console.WriteLine("Medarbetaren inaktiverades.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt ID.");
                    }
                }
            }
        }
    }
}