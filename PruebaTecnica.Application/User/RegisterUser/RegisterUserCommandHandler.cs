using PruebaTecnica.Domain.Commands;
using PruebaTecnica.Domain.Errors;
using PruebaTecnica.Domain.Repositories;

namespace PruebaTecnica.Application.User.RegisterUser
{
    public class RegisterUserCommandHandler
    {
        private readonly IUserRepository UserRepository;
        private readonly IUnitOfWork UnitOfWork;
        public RegisterUserCommandHandler(IUserRepository UserRepository, IUnitOfWork UnitOfWork)
        {
            this.UserRepository = UserRepository;
            this.UnitOfWork = UnitOfWork;
        }
        public async Task<Result<Guid>> Handle(RegisterUserCommand Request, CancellationToken CancellationToken)
        {
            var UserExist = await UserRepository.IsUserExist(Request.UserEmail);
            if (UserExist)
            {
                return Result.Failure<Guid>(UserErrors.AlreadyExist);
            }
            var PasswordHash = BCrypt.Net.BCrypt.HashPassword(Request.UserPassword);
            var NewUser = new Domain.Models.UserModel(
                Request.UserName,
                Request.UserLastName,
                Request.UserEmail,
                PasswordHash);
            UserRepository.Add(NewUser);
            await UnitOfWork.SaveChangesAsync();
            return NewUser.Id!;
        }
    }
}
