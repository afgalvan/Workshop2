using MediatR;

namespace Shared.Domain.Bus.Command
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }
}
