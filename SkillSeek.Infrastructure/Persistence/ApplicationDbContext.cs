using System.Reflection;
using SkillSeek.Domain.Entities;
using SkillSeek.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SkillSeek.Infrastructure.Persistence;

public sealed class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaims, UserRoles, UserLogin, RoleClaims, UserToken>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    #region Identity Tables
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRoles> UserRoles { get; set; }

    public DbSet<UserToken> UserToken { get; set; }
    
    public DbSet<UserLogin> UserLogin { get; set; }
    
    public DbSet<UserClaims> UserClaims { get; set; }
    
    public DbSet<RoleClaims> RoleClaims { get; set; }
    #endregion

    #region Other Entities
    public DbSet<Appointment> Appointment { get; set; }
    
    public DbSet<Cart> Carts { get; set; }
    
    public DbSet<Notification> Notifications { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderDetail> OrderDetails { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Professional> Professionals { get; set; }
    
    public DbSet<Service> Services { get; set; }
    #endregion
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(builder);

        #region Identity Entities Configuration
        builder.Entity<User>().ToTable("Users");
        builder.Entity<Role>().ToTable("Roles");
        builder.Entity<UserToken>().ToTable("Tokens");
        builder.Entity<UserRoles>().ToTable("UserRoles");
        builder.Entity<RoleClaims>().ToTable("RoleClaims");
        builder.Entity<UserClaims>().ToTable("UserClaims");
        builder.Entity<UserLogin>().ToTable("LoginAttempts");
        #endregion
    }
}