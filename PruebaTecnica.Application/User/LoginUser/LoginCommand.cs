using PruebaTecnica.Domain.Commands;

namespace PruebaTecnica.Application.User.LoginUser
{
    public record LoginCommand(string Email, string Password) : ICommand<string>
    { }
}
