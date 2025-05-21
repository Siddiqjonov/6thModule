using CarSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(rt => rt.RefreshTokenId);

        builder.Property(rt => rt.Token).IsRequired();
        builder.Property(rt => rt.Expires).IsRequired();
        builder.Property(rt => rt.IsRevoked).IsRequired();
    }
}