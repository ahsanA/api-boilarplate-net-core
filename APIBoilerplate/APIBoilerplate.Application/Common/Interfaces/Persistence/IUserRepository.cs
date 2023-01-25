using APIBoilerplate.Domain.UserAggregate;
namespace APIBoilerplate.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> AddAsync(User user);
    }
}