using Microsoft.EntityFrameworkCore;
using TZTDate.IdentityWebApi.Data.Token.Models;
using TZTDate.IdentityWebApi.Data.User.Models;

namespace TZTDate.IdentityWebApi.Data;

public class TZTDateDbContext : DbContext
{
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<LogEntry.Models.LogEntry> LogEntries { get; set; }
    public DbSet<User.Models.User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public TZTDateDbContext(DbContextOptions<TZTDateDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        builder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        builder.Entity<User.Models.User>()
            .Property(e => e.ProfilePicPaths)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries
            )
        );
    }
}