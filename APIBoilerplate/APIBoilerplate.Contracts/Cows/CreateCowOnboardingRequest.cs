namespace APIBoilerplate.Contracts.Cows
{
    public record CreateCowOnboardingRequest(
        double InitialWeight, 
        double InitialPrice, 
        DateTime OnBoardingDate) ;
}