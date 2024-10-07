namespace WKApp.Domain.Models.Employee.ValueObjects;

public class EmployeeNumber : ValueObject<string>
{
    public EmployeeNumber(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length != 8 || !value.All(char.IsDigit))
        {
            throw new ArgumentException("Employee number must be 8 digit numeric value.", nameof(value));
        }

        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}