namespace APIBoilerplate.Domain.Common.Models
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }

        public override bool Equals(object? obj)
        {
            var valueObject = obj as ValueObject;

            if (ReferenceEquals(valueObject, null))
            {
                return false;
            }

            if (GetType() != obj?.GetType())
            {
                return false;
            }

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
        }

        public abstract IEnumerable<object> GetEqualityComponents();

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }
    }
}