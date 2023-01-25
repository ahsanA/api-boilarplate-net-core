namespace APIBoilerplate.Contracts.Cows
{
    public record AddCowRequest(
        double InitialWeight,
        double InitialPrice,
        DateTime OnBoardingDate);
}