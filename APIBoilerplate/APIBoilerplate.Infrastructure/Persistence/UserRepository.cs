namespace APIBoilerplate.Infrastructure.Persistence
{
    using System.Threading.Tasks;
    using APIBoilerplate.Application.Common.Interfaces.Persistence;
    using APIBoilerplate.Domain.Entities;


    public class UserRepository : IUserRepository
    {
        private static readonly List<User> users = new();

        public Task<User?> GetUserByEmailAsync(string email)
        {
            return Task.FromResult(users.FirstOrDefault(u => u.Email == email));
        }

        public Task<User> AddAsync(User user)
        {
            users.Add(user);           
            return Task.FromResult(user);
        }
    }
}