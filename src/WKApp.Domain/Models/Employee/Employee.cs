using WKApp.Domain.Models.Employee.ValueObjects;

namespace WKApp.Domain.Models.Employee;

public class Employee
{
    public Employee(Guid id, EmployeeNumber employeeNumber, Name name, Gender gender)
    {
        Id = id;
        EmployeeNumber = employeeNumber ?? throw new ArgumentNullException(nameof(employeeNumber));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Gender = gender;
    }

    public Guid Id { get; private set; }

    public EmployeeNumber EmployeeNumber { get; private set; }

    public Name Name { get; set; }

    public Gender Gender { get; set; }

    public void Update(Name name, Gender gender)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Gender = gender;
    }
}
