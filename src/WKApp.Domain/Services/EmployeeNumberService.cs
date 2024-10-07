using WKApp.Domain.DAL;
using WKApp.Domain.Interfaces;
using WKApp.Domain.Models.Employee;
using WKApp.Domain.Models.Employee.ValueObjects;

namespace WKApp.Domain.Services;

public class EmployeeNumberService : IEmployeeNumberService
{
    private readonly IRepository<Employee> _repository;

    public EmployeeNumberService(IRepository<Employee> repository)
    {
        _repository = repository;
    }

    public EmployeeNumber CreateNextEmployeeNumber()
    {
        int lastEmployeeNumber = GetLastEmployeeNumberValue();

        return new EmployeeNumber((lastEmployeeNumber + 1).ToString("D8"));
    }

    public int GetLastEmployeeNumberValue()
    {
        return _repository
            .GetAll()
            .Select(employee => int.Parse(employee.EmployeeNumber.ToString()))
            .DefaultIfEmpty(0)
            .Max();
    }
}
