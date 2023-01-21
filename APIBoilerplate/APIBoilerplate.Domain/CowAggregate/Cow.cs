using APIBoilerplate.Domain.CowAggregate.ValueObjects;
using APIBoilerplate.Domain.FarmAgreegate.ValueObjects;
using APIBoilerplate.Domain.Common.Models;
using APIBoilerplate.Domain.UserAggregate.ValueObjects;

namespace APIBoilerplate.Domain.CowAggregate
{
    public sealed class Cow : AggregateRoot<CowId>
    {
        public string DisplayNumber { get; }
        public double InitialWeight { get; }
        public double InitialPrice { get; } 
        public DateTime OnBoardingDate { get; }

        public DateTime AddedDate { get; }
        public UserId AddedBy { get; }
        public DateTime? ModifiedDate { get; }
        public UserId? ModifiedBy { get; }
        public FarmId FarmId { get; }

        private Cow(CowId id,
                    string displayNumber,
                    double initialWeight,
                    double initialPrice,
                    DateTime onBoardingDate,
                    DateTime addedDate,
                    UserId addedBy,
                    DateTime? modifiedDate,
                    UserId? modifiedBy,
                    FarmId farmId) : base(id)
        {
            DisplayNumber = displayNumber;
            InitialWeight = initialWeight;
            InitialPrice = initialPrice;
            OnBoardingDate = onBoardingDate;
            AddedDate = addedDate;
            AddedBy = addedBy;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
            FarmId = farmId;
        }

        public static Cow Create(string displayNumber,
                                 double initialWeight,
                                 double initialPrice,
                                 DateTime onBoardingDate,
                                 DateTime addedDate,
                                 UserId addedBy,
                                 FarmId farmId)
        {
            return new (CowId.CreateUnique(),
                           displayNumber,
                           initialWeight,
                           initialPrice,
                           onBoardingDate,
                           addedDate,
                           addedBy,
                           null,
                           null,
                           farmId);
        }

    }
}