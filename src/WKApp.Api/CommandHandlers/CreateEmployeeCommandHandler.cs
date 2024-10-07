using WKApp.Api.Commands;
using WKApp.Api.Interfaces;
using WKApp.Domain.DAL;
using WKApp.Domain.Interfaces;
using WKApp.Domain.Models.Employee;
using WKApp.Domain.Models.Employee.ValueObjects;

namespace WKApp.Api.CommandHandlers;

public class CreateEmployeeCommandHandler : ICommandHandler<Employee, CreateEmployeeCommand>
{
    private readonly IEmployeeNumberService _employeeNumberService;
    private readonly IRepository<Employee> _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeNumberService employeeNumberService, IRepository<Employee> employeeRepository)
    {
        _employeeNumberService = employeeNumberService;
        _employeeRepository = employeeRepository;
    }

    public Employee Handle(CreateEmployeeCommand command)
    {
        var employee = new Employee(
            Guid.NewGuid(),
            _employeeNumberService.CreateNextEmployeeNumber(),
            new Name(command.Name),
            command.Gender);

        return employee;
    }
}
