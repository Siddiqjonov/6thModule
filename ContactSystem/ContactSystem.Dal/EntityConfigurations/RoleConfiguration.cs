using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContactSystem.Dal.Entities;

namespace ContactSystem.Dal.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.RoleName).IsRequired().HasMaxLength(50);

        builder.HasMany(r => r.RoleUsers)
               .WithOne(ur => ur.Role)
               .HasForeignKey(ur => ur.RoleId);
    }
}

