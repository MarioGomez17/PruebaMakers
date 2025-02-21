using MediatR;

namespace PruebaTecnica.Domain.Commands
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    { }
    public interface ICommand<TRespone> : IRequest<Result<TRespone>>, IBaseCommand
    { }
    public interface IBaseCommand
    { }
}
