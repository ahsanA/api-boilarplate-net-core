using APIBoilerplate.Domain.CowAggregate.ValueObjects;
using APIBoilerplate.Domain.FarmAgreegate.ValueObjects;
using APIBoilerplate.Domain.Common.Models;
using APIBoilerplate.Domain.UserAggregate.ValueObjects;

namespace APIBoilerplate.Domain.CowAggregate
{
    public sealed class Cow : AggregateRoot<CowId>
    {
        public string DisplayNumber { get; private set; }
        public double InitialWeight { get; private set; }
        public double InitialPrice { get; private set; } 
        public DateTime OnBoardingDate { get; private set; }

        public DateTime AddedDate { get; private set; }
        public UserId AddedBy { get; private set; }
        public DateTime ModifiedDate { get; private set; }
        public UserId ModifiedBy { get; private set; }
        public FarmId FarmId { get; private set; }

        
        private Cow(CowId id,
                    string displayNumber,
                    double initialWeight,
                    double initialPrice,
                    DateTime onBoardingDate,
                    DateTime addedDate,
                    UserId addedBy,
                    DateTime modifiedDate,
                    UserId modifiedBy,
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

#pragma warning disable CS8618
        private Cow()
        {
        }
#pragma warning restore CS8618

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
                           addedDate,
                           addedBy,
                           farmId);
        }

    }
}