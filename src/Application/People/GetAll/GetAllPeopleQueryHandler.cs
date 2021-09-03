using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using Shared.Domain.Bus.Query;

namespace Application.People.GetAll
{
    public class GetAllPeopleQueryHandler :
        IQueryHandler<GetAllPeopleQuery, IEnumerable<PersonResponse>>
    {
        private readonly PeopleGiver _peopleGiver;

        public GetAllPeopleQueryHandler(PeopleGiver peopleGiver)
        {
            _peopleGiver = peopleGiver;
        }

        public async Task<IEnumerable<PersonResponse>> Handle(GetAllPeopleQuery request,
            CancellationToken cancellationToken)
        {
            return (await _peopleGiver.GetAll(cancellationToken))
                .Adapt<List<PersonResponse>>();
        }
    }
}
