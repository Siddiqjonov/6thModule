using CarSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Model).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Year).IsRequired();
        builder.Property(c => c.Color).HasMaxLength(50);
        builder.Property(c => c.IsAvailable).IsRequired();
    }
}