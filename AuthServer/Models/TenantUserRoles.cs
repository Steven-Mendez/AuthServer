namespace AuthServer.Models
{
    public class TenantUserRoles
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
