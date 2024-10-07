using WKApp.Api.Commands;
using WKApp.Api.Interfaces;
using WKApp.Domain.DAL;
using WKApp.Domain.Interfaces;
using WKApp.Domain.Models.Employee;
using WKApp.Domain.Models.Employee.ValueObjects;

namespace WKApp.Api.CommandHandlers;

public class UpdateEmployeeCommandHandler : ICommandHandler<Employee, UpdateEmployeeCommand>
{
    private readonly IEmployeeNumberService _employeeNumberService;
    private readonly IRepository<Employee> _employeeRepository;

    public Employee Handle(UpdateEmployeeCommand command)
    {
        var employee = _employeeRepository.GetById(command.EmployeeId);

        employee.Update(new Name(command.Name), command.Gender);

        return employee;
    }
}
