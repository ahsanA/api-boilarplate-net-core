namespace APIBoilerplate.Contracts.Cows
{
    public record CowOnboardingResponse(
        string Id,         
        string DisplayNumber,
        double InitialWeight, 
        double InitialPrice, 
        DateTime OnBoardingDate,
        string FarmId,
        DateTime AddedDate,
        DateTime ModifiedDate
        );
}