using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.People;

namespace Application.People.GetAll
{
    public class PeopleGiver
    {
        private readonly IPersonRepository _repository;

        public PeopleGiver(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Person>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }
    }
}
