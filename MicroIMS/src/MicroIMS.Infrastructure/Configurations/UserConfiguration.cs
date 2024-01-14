using MicroIMS.Domain.Entities;
using MicroIMS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroIMS.Infrastructure.Configurations;


public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Email)
            .HasConversion(x => x.Value, v => Email.Create(v).Value);

        builder
            .Property(x => x.FirstName);

        builder
            .Property(x => x.LastName);

        builder.HasIndex(x => x.Email).IsUnique();
    }
}
