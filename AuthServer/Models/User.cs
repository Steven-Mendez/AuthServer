namespace AuthServer.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ProfileImage { get; set; }
        public virtual ICollection<TenantUserRoles> TenantUserRoles { get; set; }
        public User()
        {
            TenantUserRoles = new HashSet<TenantUserRoles>();
        }
    }
}
