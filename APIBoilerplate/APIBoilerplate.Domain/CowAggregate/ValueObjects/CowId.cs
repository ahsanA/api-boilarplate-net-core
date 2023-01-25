using APIBoilerplate.Domain.Common.Models;

namespace APIBoilerplate.Domain.CowAggregate.ValueObjects

{
    public sealed class CowId : ValueObject
    {
        public Guid Value { get; private set;}

        private CowId(Guid value)
        {
            Value = value;
        }

        public static CowId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static CowId Create(Guid value)
        {
            return new(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}