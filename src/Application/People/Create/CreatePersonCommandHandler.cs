using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shared.Domain.Bus.Command;

namespace Application.People.Create
{
    public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand>
    {
        private readonly PersonCreator _personCreator;

        public CreatePersonCommandHandler(PersonCreator personCreator)
        {
            _personCreator = personCreator;
        }

        public async Task<Unit> Handle(CreatePersonCommand request,
            CancellationToken cancellationToken)
        {
            (string id, string name, int age, char genre) = request;
            await _personCreator.Create(id, name, age, genre, cancellationToken);
            return Unit.Value;
        }
    }
}
