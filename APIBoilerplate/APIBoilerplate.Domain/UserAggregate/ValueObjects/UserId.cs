using APIBoilerplate.Domain.Common.Models;
namespace APIBoilerplate.Domain.UserAggregate.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; private set; }
        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId Create(string userId)
        {
            return new UserId(new Guid(userId));
        }

        public static UserId Create(Guid userId)
        {
            return new UserId(userId);
        }

        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}