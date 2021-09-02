using Shared.Domain.Bus.Command;

namespace Application.People.Delete
{
    public class DeletePersonCommand : ICommand
    {
        public DeletePersonCommand(string id)
        {
            Id = id;
        }

        public string Id { get; init; }

        public void Deconstruct(out string id)
        {
            id = Id;
        }
    }
}
