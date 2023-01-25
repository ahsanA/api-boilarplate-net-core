using APIBoilerplate.Domain.CowAggregate;

using Microsoft.EntityFrameworkCore;

namespace APIBoilerplate.Infrastructure.Persistence
{
    public class APIBoilerplateDbContext : DbContext
    {
        public APIBoilerplateDbContext(DbContextOptions<APIBoilerplateDbContext> options) : base(options)
        {
        }

        public DbSet<Cow> Cows { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(APIBoilerplateDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}