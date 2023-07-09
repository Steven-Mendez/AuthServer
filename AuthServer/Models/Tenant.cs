namespace AuthServer.Models
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Logo { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<TenantUserRoles> TenantUserRoles { get; set; }
        public Tenant()
        {
            Roles = new HashSet<Role>();
            TenantUserRoles = new HashSet<TenantUserRoles>();
        }
    }
}
