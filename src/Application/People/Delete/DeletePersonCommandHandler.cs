using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shared.Domain.Bus.Command;

namespace Application.People.Delete
{
    public class DeletePersonCommandHandler : ICommandHandler<DeletePersonCommand>
    {
        private readonly PersonDeleter _personDeleter;

        public DeletePersonCommandHandler(PersonDeleter personDeleter)
        {
            _personDeleter = personDeleter;
        }

        public async Task<Unit> Handle(DeletePersonCommand request,
            CancellationToken cancellationToken)
        {
            await _personDeleter.Delete(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
