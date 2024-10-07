using Moq;
using WKApp.Domain.DAL;
using WKApp.Domain.Models.Employee;
using WKApp.Domain.Models.Employee.ValueObjects;
using WKApp.Domain.Services;

namespace WKApp.Tests.Domain.UnitTests.ServicesTests;

[TestFixture]
public class EmployeeNumberServiceTests
{
    [Test]
    public void GetLastEmployeeNumberValue_NoObjectInRepository_ShouldReturnValueEqualToZero()
    {
        var employeeRepositoryMock = new Mock<IRepository<Employee>>();
        employeeRepositoryMock
            .Setup(r => r.GetAll())
            .Returns([]);

        var sut = new EmployeeNumberService(employeeRepositoryMock.Object);

        var result = sut.GetLastEmployeeNumberValue();

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void GetLastEmployeeNumberValue_OneObjectInRepository_ShouldReturnValueEqualToOne()
    {
        var firstEmployee = new Employee(
            It.IsAny<Guid>(),
            new("00000001"),
            new("Smith"),
            It.IsAny<Gender>());

        var employeeRepositoryMock = new Mock<IRepository<Employee>>();
        employeeRepositoryMock
            .Setup(r => r.GetAll())
            .Returns([firstEmployee]);

        var sut = new EmployeeNumberService(employeeRepositoryMock.Object);

        var result = sut.GetLastEmployeeNumberValue();

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void CreateNextEmployeeNumber_NoObjectInRepository_ShouldReturnObjectWithVeryFirstValue()
    {
        var employeeRepositoryMock = new Mock<IRepository<Employee>>();
        employeeRepositoryMock
            .Setup(r => r.GetAll())
            .Returns([]);

        var sut = new EmployeeNumberService(employeeRepositoryMock.Object);

        var result = sut.CreateNextEmployeeNumber();

        Assert.That(result, Is.EqualTo(new EmployeeNumber("00000001")));
    }

    [Test]
    public void CreateNextEmployeeNumber_OneObjectInRepository_ShouldReturnObjectWithNextEmployeeNumberValue()
    {
        var firstEmployee = new Employee(
            It.IsAny<Guid>(),
            new("00000001"),
            new("Smith"),
            It.IsAny<Gender>());

        var employeeRepositoryMock = new Mock<IRepository<Employee>>();
        employeeRepositoryMock
            .Setup(r => r.GetAll())
            .Returns([firstEmployee]);

        var sut = new EmployeeNumberService(employeeRepositoryMock.Object);

        var result = sut.CreateNextEmployeeNumber();

        Assert.That(result, Is.EqualTo(new EmployeeNumber("00000002")));
    }
}
