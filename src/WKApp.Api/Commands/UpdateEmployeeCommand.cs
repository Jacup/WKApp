using WKApp.Domain.Models.Employee;

namespace WKApp.Api.Commands;

public class UpdateEmployeeCommand
{
    public Guid EmployeeId { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
}
