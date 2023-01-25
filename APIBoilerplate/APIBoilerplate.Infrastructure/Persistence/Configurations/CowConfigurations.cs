using APIBoilerplate.Domain.CowAggregate;
using APIBoilerplate.Domain.CowAggregate.ValueObjects;
using APIBoilerplate.Domain.FarmAgreegate.ValueObjects;
using APIBoilerplate.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIBoilerplate.Infrastructure.Persistence.Configurations
{
    public class CowConfigurations : IEntityTypeConfiguration<Cow>
    {
        public void Configure(EntityTypeBuilder<Cow> builder)
        {
            ConfigureCowsTable(builder);
        }

        private void ConfigureCowsTable(EntityTypeBuilder<Cow> builder)
        {
            builder.ToTable("Cows");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CowId.Create(value))
                .IsRequired();

            builder.Property(c => c.DisplayNumber)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(c => c.FarmId)
                .HasConversion(
                    id => id.Value,
                    value => FarmId.Create(value));

            builder.Property(c => c.AddedBy)
               .HasConversion(
                   ab => ab.Value,
                   value => UserId.Create(value));

            builder.Property(c => c.ModifiedBy)
                .HasConversion(
                    ab => ab.Value,
                    value => UserId.Create(value));
        }
    }
}