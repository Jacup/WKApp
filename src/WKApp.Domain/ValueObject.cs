namespace WKApp.Domain;

public abstract class ValueObject<TValue> where TValue : IEquatable<TValue>
{
    public TValue Value { get; protected set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (ValueObject<TValue>)obj;
        
        return Value.Equals(other.Value);
    }

    public override int GetHashCode() => Value.GetHashCode();

    public static bool operator ==(ValueObject<TValue> a, ValueObject<TValue> b)
    {
        if (ReferenceEquals(a, b))
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject<TValue> a, ValueObject<TValue> b) => !(a == b);
}