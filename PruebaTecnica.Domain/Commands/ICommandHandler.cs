﻿using MediatR;

namespace PruebaTecnica.Domain.Commands
{
    public interface ICommandHandler
    { }
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> where TCommand : ICommand
    { }
    public interface ICommandHandler<TCommand, TRespone> : IRequestHandler<TCommand, Result<TRespone>> where TCommand : ICommand<TRespone>
    { }
}
