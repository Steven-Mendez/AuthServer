using Microsoft.EntityFrameworkCore;

namespace AuthServer.Models
{
    public class AuthDBContext : DbContext
    {
        public DbSet<Permission> Permission { get; set; } = null!;
        public DbSet<Role> Role { get; set; } = null!;
        public DbSet<Tenant> Tenant { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
        public DbSet<TenantUserRoles> UserTenantRole { get; set; } = null!;

        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Permissions Primary Key
            modelBuilder.Entity<Role>()
                .HasKey(x => x.Id);

            // Tenant Primary Key
            modelBuilder.Entity<Tenant>()
                .HasKey(t => t.Id);

            // User Primary Key
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // UserTenantRole Primary Key
            modelBuilder.Entity<TenantUserRoles>()
                .HasKey(utr => new { utr.UserId, utr.TenantId, utr.RoleId });

            // Role 1:N Tenant
            modelBuilder.Entity<Role>()
                .HasOne(r => r.Tenant)
                .WithMany(t => t.Roles);

            // UserTenantRole 1:N Tenants
            modelBuilder.Entity<TenantUserRoles>()
                .HasOne(utr => utr.Tenant)
                .WithMany(t => t.TenantUserRoles)
                .HasForeignKey(utr => utr.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            // UserTenantRole 1:N User
            modelBuilder.Entity<TenantUserRoles>()
                .HasOne(utr => utr.User)
                .WithMany(t => t.TenantUserRoles)
                .HasForeignKey(utr => utr.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // UserTenantRole 1:N Role
            modelBuilder.Entity<TenantUserRoles>()
                .HasOne(utr => utr.Role)
                .WithMany(r => r.TenantUserRoles)
                .HasForeignKey(utr => utr.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
