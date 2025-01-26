using ECM.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECM.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100); 

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(u => u.CreatedAt)
            .IsRequired();

        builder.ToTable("Users");
    }
}