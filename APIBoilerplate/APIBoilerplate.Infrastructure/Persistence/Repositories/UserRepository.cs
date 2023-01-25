using APIBoilerplate.Application.Common.Interfaces.Persistence;
using APIBoilerplate.Domain.UserAggregate;

namespace APIBoilerplate.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users = new();
        public Task<User?> GetUserByEmailAsync(string email)
        {
            return Task.FromResult(Users.FirstOrDefault(u => u.Email == email));
        }

        public Task<User> AddAsync(User user)
        {
            Users.Add(user);
            return Task.FromResult(user);
        }
    }
}