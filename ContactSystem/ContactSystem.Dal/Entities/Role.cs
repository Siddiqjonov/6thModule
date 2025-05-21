namespace ContactSystem.Dal.Entities;

public class Role
{
    public long Id { get; set; }
    public string RoleName { get; set; }

    public ICollection<UserRole> RoleUsers { get; set; }
}
