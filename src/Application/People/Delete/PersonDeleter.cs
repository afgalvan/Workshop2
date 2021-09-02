using System.Threading;
using System.Threading.Tasks;
using Domain.People;

namespace Application.People.Delete
{
    public class PersonDeleter
    {
        private readonly IPersonRepository _repository;

        public PersonDeleter(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(string id, CancellationToken cancellationToken)
        {
            await _repository.RemoveById(id, cancellationToken);
        }
    }
}
