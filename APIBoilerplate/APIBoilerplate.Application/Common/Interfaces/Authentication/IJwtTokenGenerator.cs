namespace APIBoilerplate.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        // string GenerateToken(string userId, string userName, string role);
        string GenerateToken(Guid userId, string firstName, string lastName);
    }
}