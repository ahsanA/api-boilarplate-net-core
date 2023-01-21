using APIBoilerplate.Domain.Common.Models;

namespace APIBoilerplate.Domain.FarmAgreegate.ValueObjects
{
    public sealed class FarmId : ValueObject
    {
        public Guid Value { get; }

        private FarmId(Guid value)
        {
            Value = value;
        }

        public static FarmId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}