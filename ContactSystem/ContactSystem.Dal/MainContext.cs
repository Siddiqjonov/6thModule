using ContactSystem.Dal.Entities;
using ContactSystem.Dal.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactSystem.Dal;

public class MainContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public MainContext(DbContextOptions<MainContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
