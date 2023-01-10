namespace APIBoilerplate.Application.Common.Interfaces.Persistence
{
    using APIBoilerplate.Domain.Entities;

    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> AddAsync(User user);
    }
}