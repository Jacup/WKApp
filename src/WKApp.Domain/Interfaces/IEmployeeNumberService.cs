using WKApp.Domain.Models.Employee.ValueObjects;

namespace WKApp.Domain.Interfaces;

public interface IEmployeeNumberService
{
    EmployeeNumber CreateNextEmployeeNumber();

    int GetLastEmployeeNumberValue();
}
