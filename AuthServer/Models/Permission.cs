namespace AuthServer.Models
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual ICollection<Role> Roles { get; set; }
        public Permission()
        {
            Roles = new HashSet<Role>();
        }
    }
}
