using Shared.Domain.Bus.Command;

namespace Application.People.Create
{
    public class CreatePersonCommand : ICommand
    {
        public CreatePersonCommand(string id, string name, int age, char genre)
        {
            Id    = id;
            Name  = name;
            Age   = age;
            Genre = genre;
        }

        public string Id    { get; init; }
        public string Name  { get; init; }
        public char   Genre { get; init; }
        public int    Age   { get; init; }

        public void Deconstruct(out string id, out string name, out int age,
            out char genre)
        {
            id    = Id;
            name  = Name;
            age   = Age;
            genre = Genre;
        }
    }
}
