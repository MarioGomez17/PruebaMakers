namespace PruebaTecnica.Domain.Models
{
    public class UserModel : Entity
    {
        public UserModel(string UserName, string UserLastName, string UserEmail, string UserPassword) : base(new Guid())
        {
            this.UserName = UserName;
            this.UserLastName = UserLastName;
            this.UserEmail = UserEmail;
            this.UserPassword = UserPassword;
        }
        public string? UserName { get; private set; }
        public string? UserLastName { get; private set; }
        public string? UserEmail { get; private set; }
        public string? UserPassword { get; private set; }
        public List<RoleModel>? UserRole { get; private set; }
    }
}
