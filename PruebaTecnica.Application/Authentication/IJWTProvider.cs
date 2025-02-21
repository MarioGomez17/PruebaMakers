using PruebaTecnica.Domain.Models;

namespace PruebaTecnica.Application.Authentication
{
    public interface IJWTProvider
    {
        Task<string> Generate(UserModel User);
    }
}
