using System.Runtime;

namespace MicroIMS.Domain.Primitives;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetValues();
    private bool ValuesAreEqual(ValueObject other)
    {
        return GetValues().SequenceEqual(other.GetValues());
    }
    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);
    }
    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && ValuesAreEqual(other);
    }
    public override int GetHashCode()
    {
        return GetValues().Aggregate(default(int), HashCode.Combine);
    }
}