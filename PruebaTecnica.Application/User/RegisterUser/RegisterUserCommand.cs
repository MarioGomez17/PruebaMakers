using PruebaTecnica.Domain.Commands;

namespace PruebaTecnica.Application.User.RegisterUser
{
    public sealed record RegisterUserCommand(string UserName, string UserLastName, string UserEmail, string UserPassword) : ICommand<int>
    { }
}
