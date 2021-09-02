using System.Threading;
using System.Threading.Tasks;
using Domain.People;

namespace Application.People.Find
{
    public class PersonFinder
    {
        private readonly IPersonRepository _repository;

        public PersonFinder(IPersonRepository repository)
        {
            _repository = repository;
        }
#nullable enable
        public async Task<Person?> Find(string id, CancellationToken cancellation)
        {
            return await _repository.GetById(id, cancellation);
        }
    }
}
