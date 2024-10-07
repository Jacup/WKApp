using WKApp.Domain.Models.Employee.ValueObjects;

namespace WKApp.Tests.Domain.UnitTests.EmployeeTests;

[TestFixture]
internal class EmployeeNumberTests
{
    [TestCase(null)]
    [TestCase("")]
    [TestCase("        ")]
    [TestCase("abcdefg")]
    [TestCase("abcdefgh")]
    [TestCase("abcdefghi")]
    [TestCase("1234567")]
    [TestCase("123456789")]
    [TestCase("1234567A")]
    [TestCase("1234567 ")]
    [TestCase(" 2345678")]
    [TestCase("A2345678")]
    public void EmployeeNumber_InvalidValue_ShouldThrowArgumentException(string? value)
    {
        Assert.Throws<ArgumentException>(() => new EmployeeNumber(value!));
    }

    [TestCase("00000000")]
    [TestCase("00000001")]
    [TestCase("99999999")]
    public void EmployeeNumber_ValidValue_ShouldNotThrowException(string value)
    {
        Assert.DoesNotThrow(() => new EmployeeNumber(value));
    }
}
