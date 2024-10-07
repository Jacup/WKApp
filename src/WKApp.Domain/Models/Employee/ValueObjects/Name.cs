namespace WKApp.Domain.Models.Employee.ValueObjects;

public class Name : ValueObject<string>
{
    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
        {
            throw new ArgumentException("Name cannot be empty and must have a maximum length of 50 characters.", nameof(value));
        }

        Value = value;
    }
}
