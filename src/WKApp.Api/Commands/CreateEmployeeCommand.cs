using WKApp.Domain.Models.Employee;

namespace WKApp.Api.Commands;

public class CreateEmployeeCommand
{
    public string Name { get; set; }

    public Gender Gender { get; set; }
}
