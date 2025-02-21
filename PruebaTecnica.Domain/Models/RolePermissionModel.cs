namespace PruebaTecnica.Domain.Models
{
    public class RolePermissionModel : Entity
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public RolePermissionModel(int Id, int RoleId, int PermissionId) : base(Id)
        {
            this.RoleId = RoleId;
            this.PermissionId = PermissionId;
        }
    }
}
