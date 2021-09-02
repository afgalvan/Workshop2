using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Domain.People;

namespace Application.People.Create
{
    public class PersonCreator
    {
        private readonly IPersonRepository _repository;

        public PersonCreator(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string id, string name, int age, char genre,
            CancellationToken cancellationToken)
        {
            Person person = new(id, name, age, MapCharToGenre(genre));
            await _repository.Save(person, cancellationToken);
        }

        private static Genre MapCharToGenre(char letter)
        {
            return char.ToUpper(letter, CultureInfo.InvariantCulture) switch
            {
                'F' => Genre.Female,
                'M' => Genre.Male,
                _ => throw new InvalidGenreException("Genero inválido.")
            };
        }
    }
}
