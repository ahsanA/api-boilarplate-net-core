namespace APIBoilerplate.Domain.UserAggregate// TODO: Add proper namespace
{
    using APIBoilerplate.Domain.Common.Models;
    using APIBoilerplate.Domain.UserAggregate.ValueObjects;
    
    public class User: AggregateRoot<UserId>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        private User(UserId id,
                     string firstName,
                     string lastName,
                     string email,
                     string password) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(string firstName,
                                  string lastName,
                                  string email,
                                  string password)
        {
            return new(UserId.CreateUnique(), firstName, lastName, email, password);
        }
    }
}