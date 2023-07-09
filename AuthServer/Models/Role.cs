namespace AuthServer.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<TenantUserRoles> TenantUserRoles { get; set; }
        public Role()
        {
            Permissions = new HashSet<Permission>();
            TenantUserRoles = new HashSet<TenantUserRoles>();
        }
    }
}
