using APIBoilerplate.Application.Common.Interfaces.Services;

namespace APIBoilerplate.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}