namespace PruebaTecnica.Domain.Models
{
    public class UserRoleModel : Entity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public UserRoleModel(int Id, int UserId, int RoleId) : base(Id)
        {
            this.UserId = UserId;
            this.RoleId = RoleId;
        }
    }
}
