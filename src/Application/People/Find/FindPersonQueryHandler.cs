using System.Threading;
using System.Threading.Tasks;
using Domain.People;
using Shared.Domain.Bus.Query;

namespace Application.People.Find
{
    public class FindPersonQueryHandler : IQueryHandler<FindPersonQuery, Person>
    {
        private readonly PersonFinder _personFinder;

        public FindPersonQueryHandler(PersonFinder personFinder)
        {
            _personFinder = personFinder;
        }

        public async Task<Person> Handle(FindPersonQuery request,
            CancellationToken cancellationToken)
        {
            return await _personFinder.Find(request.Id, cancellationToken);
        }
    }
}
