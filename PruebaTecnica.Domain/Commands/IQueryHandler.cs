using MediatR;

namespace PruebaTecnica.Domain.Commands
{
    public interface IQueryHandler<IQuery, TResponse> : IRequestHandler<IQuery, Result<TResponse>> where IQuery : IQuery<TResponse>
    {
    }
}
