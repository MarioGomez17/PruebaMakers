using PruebaTecnica.Application.Authentication;
using PruebaTecnica.Domain.Commands;
using PruebaTecnica.Domain.Errors;
using PruebaTecnica.Domain.Models;
using PruebaTecnica.Domain.Repositories;

namespace PruebaTecnica.Application.User.LoginUser
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IUserRepository UserRepository;
        private readonly IJWTProvider JWTProvider;
        public LoginCommandHandler(IUserRepository UserRepository, IJWTProvider JWTProvider)
        {
            this.UserRepository = UserRepository;
            this.JWTProvider = JWTProvider;
        }
        public async Task<Result<string>> Handle(LoginCommand Request, CancellationToken CancellationToken)
        {
            UserModel? FoundUser = await UserRepository.GetByEmailAsync(Request.Email, CancellationToken);
            if (FoundUser is null)
            {
                return Result.Failure<string>(UserErrors.NotFound);
            }
            if (!BCrypt.Net.BCrypt.Verify(Request.Password, FoundUser.UserPassword))
            {
                return Result.Failure<string>(UserErrors.InvalidCredential);
            }
            var Token = await JWTProvider.Generate(FoundUser);
            return Token;
        }
    }
}
