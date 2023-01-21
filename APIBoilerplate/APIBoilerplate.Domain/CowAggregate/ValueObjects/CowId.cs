using APIBoilerplate.Domain.Common.Models;

namespace APIBoilerplate.Domain.CowAggregate.ValueObjects

{
    public sealed class CowId : ValueObject
    {
        public Guid Value { get; }

        private CowId(Guid value)
        {
            Value = value;
        }

        public static CowId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}