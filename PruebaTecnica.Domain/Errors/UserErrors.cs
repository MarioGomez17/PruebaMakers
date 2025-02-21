namespace PruebaTecnica.Domain.Errors
{
    public class UserErrors
    {
        public static Error NotFound = new("User.NotFound", "No existe el usuario buscado por este Id");
        public static Error InvalidCredential = new("User.InvalidCredential", "Las credenciales son incorrectas");
        public static Error AlreadyExist = new("User.AlreadyExist", "El usuario ya existe en el sistema");
    }
}
