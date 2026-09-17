namespace ITAssetManager.Domain.Employees.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; private set; }
        public string EmployeeName { get; private set; } = null!;
        public string EmailAddress { get; private set; } = null!;
        public bool IsActive { get; private set; }

        public Employee(Guid employeeId, string employeeName, string emailAddress)
        {
            if (employeeId == Guid.Empty)
            {
                throw new ArgumentException("Medarbetarens ID får inte vara tomt.");
            }

            if (string.IsNullOrWhiteSpace(employeeName) || employeeName.Trim().Length < 2)
            {
                throw new ArgumentException("Medarbetarens namn måste innehålla minst två tecken.");
            }

            if (string.IsNullOrWhiteSpace(emailAddress) ||
                !emailAddress.Contains('@') ||
                !emailAddress.Contains('.'))
            {
                throw new ArgumentException("E-postadressen är ogiltig.");
            }

            EmployeeId = employeeId;
            EmployeeName = employeeName.Trim();
            EmailAddress = emailAddress.Trim();
            IsActive = true;
        }

        public void Deactivate()
        {
            if (IsActive == false)
            {
                throw new InvalidOperationException("Medarbetaren är redan inaktiv.");
            }

            IsActive = false;
        }
    }
}