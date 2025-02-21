namespace PruebaTecnica.Domain.Models
{
    public class RoleModel : Entity
    {
        public RoleModel(int Id, string RoleName) : base(Id)
        {
            this.RoleName = RoleName;
        }
        public string? RoleName { get; set; }
        public List<PermissionModel>? Permissions { get; private set; }
    }
}
