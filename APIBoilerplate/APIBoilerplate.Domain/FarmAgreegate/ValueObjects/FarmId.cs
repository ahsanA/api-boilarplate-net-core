using APIBoilerplate.Domain.Common.Models;

namespace APIBoilerplate.Domain.FarmAgreegate.ValueObjects
{
    public sealed class FarmId : ValueObject
    {
        public Guid Value { get; private set;}

        private FarmId(Guid value)
        {
            Value = value;
        }

        public static FarmId Create(string farmId)
        {
            return new FarmId(new Guid(farmId));
        }

        public static FarmId Create(Guid farmId)
        {
            return new FarmId(farmId);
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