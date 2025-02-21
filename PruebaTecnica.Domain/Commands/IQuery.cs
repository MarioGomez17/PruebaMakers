using MediatR;

namespace PruebaTecnica.Domain.Commands
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
