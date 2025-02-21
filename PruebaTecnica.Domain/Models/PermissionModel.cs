namespace PruebaTecnica.Domain.Models
{
    public class PermissionModel : Entity
    {
        public string? PermissionName { get; private set; }
        public PermissionModel(int Id, string PermissionName) : base(Id)
        {
            this.PermissionName = PermissionName;
        }
    }
}
